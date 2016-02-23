using System;
using System.Linq;

namespace Fubar.Models
{
    public class TicketContextSeedData
    {
        private TicketContext _context;

        public TicketContextSeedData(TicketContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Severities.Any())
            {
                // Add new Severity data
                var sev1 = new Severity()
                {
                    Name = "Major"
                };
                _context.Severities.Add(sev1);
                var sev2 = new Severity()
                {
                    Name = "Minor"
                };
                _context.Severities.Add(sev2);
                var sev3 = new Severity()
                {
                    Name = "Trivial"
                };
                _context.Severities.Add(sev3);
            }

            if (!_context.Categories.Any())
            {
                // Add new Category data
                var cat1 = new Category()
                {
                    Name = "Bug"
                };
                _context.Categories.Add(cat1);
                var cat2 = new Category()
                {
                    Name = "Feature Request"
                };
                _context.Categories.Add(cat2);
                var cat3 = new Category()
                {
                    Name = "Other"
                };
                _context.Categories.Add(cat3);
            }
            if (!_context.Priorities.Any())
            {
                // Add new Priority data
                var p1 = new Priority()
                {
                    Name = "Normal"
                };
                _context.Priorities.Add(p1);
                var p2 = new Priority()
                {
                    Name = "High"
                };
                _context.Priorities.Add(p2);
                var p3 = new Priority()
                {
                    Name = "Urgent"
                };
                _context.Priorities.Add(p3);
            }
            if (!_context.Products.Any())
            {
                // Add new Product data
                var p1 = new Product()
                {
                    Name = "Timber!"
                };
                _context.Products.Add(p1);
                var p2 = new Product()
                {
                    Name = "Woody"
                };
                _context.Products.Add(p2);
                var p3 = new Product()
                {
                    Name = "Chipper"
                };
                _context.Products.Add(p3);
            }
            if (!_context.Statuses.Any())
            {
                // Add new Statuses
                var stat1 = new Status()
                {
                    Name = "Unconfirmed"
                };
                _context.Statuses.Add(stat1);
                var stat2 = new Status()
                {
                    Name = "Confirmed"
                };
                _context.Statuses.Add(stat2);
                var stat3 = new Status()
                {
                    Name = "In Progress"
                };
                _context.Statuses.Add(stat3);
                var stat4 = new Status()
                {
                    Name = "Resolved"
                };
                _context.Statuses.Add(stat4);
                var stat5 = new Status()
                {
                    Name = "Verified"
                };
                _context.Statuses.Add(stat5);
            }
            if (!_context.Resolutions.Any())
            {
                // Add new Resolutions
                var res1 = new Resolution()
                {
                    Name = "Fixed"
                };
                _context.Resolutions.Add(res1);
                var res2 = new Resolution()
                {
                    Name = "Invalid"
                };
                _context.Resolutions.Add(res2);
                var res3 = new Resolution()
                {
                    Name = "Will not fix"
                };
                _context.Resolutions.Add(res3);
                var res4 = new Resolution()
                {
                    Name = "Duplicate"
                };
                _context.Resolutions.Add(res4);
                var res5 = new Resolution()
                {
                    Name = "Works for me"
                };
                _context.Resolutions.Add(res5);
            }
            _context.SaveChanges();

            if (!_context.Tickets.Any())
            {
                // Add new Ticket
                var tck1 = new Ticket()
                {
                    Summary = "Demo ticket",
                    Description = "This is a simple demo ticket.",
                    CategoryId = 1,
                    SeverityId = 1,
                    PriorityId = 1,
                    //ResolutionId
                    StatusId = 5,
                    Version = "1.2.0.5",
                    ProductId = 1,
                    StepsToReproduce = "1. Try this. 2. Do that. 3. Pick this one.",
                    AdditionalInformation = "This is extra info about this problem.",
                    DateSubmitted = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow
                };
                _context.Tickets.Add(tck1);
                var tck2 = new Ticket()
                {
                    Summary = "Demo ticket - Fixed",
                    Description = "This is a simple demo ticket that has been resolved.",
                    CategoryId = 1,
                    SeverityId = 3,
                    PriorityId = 2,
                    ResolutionId = 3,
                    StatusId = 3,
                    Version = "1.2.0.5",
                    ProductId = 1,
                    StepsToReproduce = "1. Try this. 2. Do that. 3. Pick this one.",
                    AdditionalInformation = "This is extra info about this problem.",
                    DateSubmitted = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow
                };
                _context.Tickets.Add(tck2);
            }
            _context.SaveChanges();
        }
    }
}
// https://app.pluralsight.com/player?course=aspdotnet-5-ef7-bootstrap-angular-web-app&author=shawn-wildermuth&name=aspdotnet-5-ef7-bootstrap-angular-web-app-m6&clip=5&mode=live  ...3:48