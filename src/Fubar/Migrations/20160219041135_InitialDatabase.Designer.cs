using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Fubar.Models;

namespace Fubar.Migrations
{
    [DbContext(typeof(TicketContext))]
    [Migration("20160219041135_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Fubar.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Fubar.Models.Priority", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Fubar.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Fubar.Models.Severity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Fubar.Models.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInformation");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("DateSubmitted");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("PriorityId");

                    b.Property<int>("ProductId");

                    b.Property<int>("SeverityId");

                    b.Property<string>("StepsToReproduce");

                    b.Property<string>("Summary");

                    b.Property<int>("UserId");

                    b.Property<string>("Version");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Fubar.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Fubar.Models.Ticket", b =>
                {
                    b.HasOne("Fubar.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Fubar.Models.Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("Fubar.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Fubar.Models.Severity")
                        .WithMany()
                        .HasForeignKey("SeverityId");

                    b.HasOne("Fubar.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
