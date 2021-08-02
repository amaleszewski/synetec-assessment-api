using System.Collections.Generic;
using SynetecAssessmentApi.Domain.SeedWork;

namespace SynetecAssessmentApi.Domain
{
    public class Company : AggregateRoot
    {
        private readonly List<Employee> _employees = new List<Employee>();
        
        public Company(int id, string name, int annualBonusPool) : base(id)
        {
            Name = name;
            AnnualBonusPool = annualBonusPool;
        }

        public string Name { get; private set; }

        public int AnnualBonusPool { get; private set; }

        public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();
    }
}