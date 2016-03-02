using AutoMapper;
using Fubar.Models;
using Fubar.Services;
using Fubar.ViewModels;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Threading.Tasks;

namespace Fubar
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config => 
            {
#if !DEBUG
                config.Filters.Add(new RequireHttpsAttribute());
#endif
            })
                .AddJsonOptions(opt => 
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            services.AddIdentity<FubarUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                        ctx.Response.StatusCode == (int)HttpStatusCode.OK)
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        return Task.FromResult(0);
                    }
                };
            })
            .AddEntityFrameworkStores<TicketContext>();

            services.AddLogging();

            var connection = Configuration["AppSettings:SqliteConnectionString"];

            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<TicketContext>(options => options.UseSqlite(connection));

            services.AddTransient<TicketContextSeedData>();
            services.AddScoped<IFubarRepository, FubarRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IResolutionRepository, ResolutionRepository>();
            services.AddScoped<ISeverityRepository, SeverityRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddScoped<IMailService, MailService>();
            //services.AddScoped<ITicketRepository, TicketRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, TicketContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Information);

            app.UseStaticFiles();

            app.UseIdentity();

            Mapper.Initialize(config =>
            {
                config.CreateMap<Ticket, TicketViewModel>().ReverseMap();
                config.CreateMap<Category, CategoryViewModel>().ReverseMap();
                config.CreateMap<Priority, PriorityViewModel>().ReverseMap();
                config.CreateMap<Product, ProductViewModel>().ReverseMap();
                config.CreateMap<Resolution, ResolutionViewModel>().ReverseMap();
                config.CreateMap<Severity, SeverityViewModel>().ReverseMap();
                config.CreateMap<Status, StatusViewModel>().ReverseMap();
            }); ;

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });
            await seeder.EnsureSeedDataAsync();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
