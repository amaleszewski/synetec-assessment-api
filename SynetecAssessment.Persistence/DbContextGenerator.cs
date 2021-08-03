using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SynetecAssessmentApi.Persistence
{
    public class DbContextGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Set<Employee>().Any()) return;

            SeedData(context);
        }

        public static void SeedData(AppDbContext context)
        {
            var companies = new List<Company>
            {
                new Company(1, "ABC", 50000),
            };
            
            var departments = new List<Department>
            {
                new Department(1, "Finance", "The finance department for the company"),
                new Department(2, "Human Resources", "The Human Resources department for the company"),
                new Department(3, "IT", "The IT support department for the company"),
                new Department(4, "Marketing", "The Marketing department for the company")
            };

            var employees = new List<Employee>
            {
                new Employee(1, "John Smith", "Accountant (Senior)", 60000, 1, 1),
                new Employee(2, "Janet Jones", "HR Director", 90000, 1, 2),
                new Employee(3, "Robert Rinser", "IT Director", 95000, 1, 3),
                new Employee(4, "Jilly Thornton", "Marketing Manager (Senior)", 55000, 1, 4),
                new Employee(5, "Gemma Jones", "Marketing Manager (Junior)", 45000, 1, 4),
                new Employee(6, "Peter Bateman", "IT Support Engineer", 35000, 1, 3),
                new Employee(7, "Azimir Smirkov", "Creative Director", 62500, 1, 4),
                new Employee(8, "Penelope Scunthorpe", "Creative Assistant", 38750, 1, 4),
                new Employee(9, "Amil Kahn", "IT Support Engineer", 36000, 1, 3),
                new Employee(10, "Joe Masters", "IT Support Engineer", 36500, 1, 3),
                new Employee(11, "Paul Azgul", "HR Manager", 53000, 1, 2),
                new Employee(12, "Jennifer Smith", "Accountant (Junior)", 48000, 1, 1),
            };

            context.Set<Company>().AddRange(companies);
            context.Set<Department>().AddRange(departments);
            context.Set<Employee>().AddRange(employees);

            context.SaveChanges();
        }
    }
}
