using Microsoft.EntityFrameworkCore;

namespace TimeReportAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;

        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            _context.Database.Migrate();

            //SeedCustomer();
            //SeedProject();
        }

        //private void SeedProject()
        //{
        //    if (!_context.Projects.Any(p => p.ProjectName == "Telia customerservice"))
        //    {
        //        _context.Projects.Add(new Project
        //        {
        //            ProjectName = "Telia customerservice",
        //            Description = "Fix service labels",
        //            Customer = _context.Customers.First(c => c.Name == "Telia")
        //        });
        //    }
        //    if (!_context.Projects.Any(p => p.ProjectName == "Comviq WebApp"))
        //    {
        //        _context.Projects.Add(new Project
        //        {
        //            ProjectName = "Web Application",
        //            Description = "Fix website",
        //            Customer = _context.Customers.First(c => c.Name == "Telia")
        //        });

        //    }

        //    _context.SaveChanges();
        //}

        //private void SeedCustomer()
        //{
        //    if (!_context.Customers.Any(a => a.Name == "Telia"))
        //    {
        //        _context.Customers.Add(new Customer
        //        {
        //            Name = "Telia",
        //            Projects = new List<Project>
        //            {
        //                new Project
        //                {
        //                    ProjectName = "Telenor",
        //                    Description = "Audio"
        //                }
        //            }

        //        });
        //    }

        //    if (!_context.Customers.Any(a => a.Name == "Comviq"))
        //    {
        //        _context.Customers.Add(new Customer
        //        {
        //            Name = "Volvo",
        //            Projects = new List<Project>
        //            {
        //                new Project
        //                {
        //                    ProjectName = "PoleStar",
        //                    Description = "UI"
        //                }
        //            }

        //        });
        //    }

        //    _context.SaveChanges();
        //}
    }
}
