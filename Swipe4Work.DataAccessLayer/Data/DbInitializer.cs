using Swipe4Work.Domain.Models;

namespace Swipe4Work.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Roles.Any())
            {
                return; // The database has already been seeded
            }

            // Seed data
            var roles = new Role[]
            {
                new Role { Name = "Admin", Description = "Administrator role" },
                new Role { Name = "User", Description = "User role" }
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();

            var companies = new Company[]
            {
                new Company
                {
                    Name = "Tech Corp",
                    WebsiteUrl = "http://www.techcorp.com",
                    Industry = "Technology",
                    Size = "500-1000",
                    Headquarters = "San Francisco",
                    FoundedYear = 2000,
                    Description = "A leading technology company",
                    Location = "San Francisco"
                }
            };

            context.Companies.AddRange(companies);
            context.SaveChanges();

            var users = new User[]
            {
                new User
                {
                    Email = "admin@techcorp.com",
                    UserName = "admin",
                    PasswordHash = "hashedpassword",
                    UserType = "Admin",
                    FirstName = "Admin",
                    LastName = "User",
                    Headline = "Administrator",
                    Summary = "System Administrator",
                    Location = "San Francisco",
                    DateJoined = DateTimeOffset.Now,
                    LinkedInUrl = "http://linkedin.com/admin",
                    GenderIdentity = "Non-binary",
                    Pronoun = "They/Them",
                    Ethnicity = "Not Specified",
                    MobileNumber = "123-456-7890",
                    RequireVisa = false,
                    SearchStage = "Not Looking",
                    ProfilePicture = "http://profilepicture.com/admin",
                    ProfileUrl = "http://profileurl.com/admin",
                    PortfolioUrl = "http://portfoliourl.com/admin",
                    RoleId = context.Roles.First(r => r.Name == "Admin").RoleId,
                    CompanyId = context.Companies.First(c => c.Name == "Tech Corp").CompanyId,
                    IsWorking = true
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public static void Revert(ApplicationDbContext context)
        {
            var users = context.Users.Where(u => u.Email == "admin@techcorp.com").ToList();
            context.Users.RemoveRange(users);

            var companies = context.Companies.Where(c => c.Name == "Tech Corp").ToList();
            context.Companies.RemoveRange(companies);

            var roles = context.Roles.Where(r => r.Name == "Admin" || r.Name == "User").ToList();
            context.Roles.RemoveRange(roles);

            context.SaveChanges();
        }
    }
}
