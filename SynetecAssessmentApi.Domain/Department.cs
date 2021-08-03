using System.Collections.Generic;
using SynetecAssessmentApi.Domain.SeedWork;

namespace SynetecAssessmentApi.Domain
{
    public class Department : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<Employee> Employees { get; private set; }

        public Department(
            int id,
            string title,
            string description) : base(id)
        {
            Title = title;
            Description = description;
        }
    }
}
