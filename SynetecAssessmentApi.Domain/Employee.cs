using System;
using SynetecAssessmentApi.Domain.SeedWork;

namespace SynetecAssessmentApi.Domain
{
    public class Employee : Entity
    {
        public string Fullname { get; private set; }
        public string JobTitle { get; private set; }
        public int Salary { get; private set; }

        public int CompanyId { get; private set; }

        public Company Company { get; private set; }
        public int DepartmentId { get; private set; }
        public Department Department { get; private set; }

        public Employee(
            int id,
            string fullname,
            string jobTitle,
            int salary,
            int companyId,
            int departmentId) :base(id)
        {
            Fullname = fullname;
            JobTitle = jobTitle;
            Salary = salary;
            CompanyId = companyId;
            DepartmentId = departmentId;
        }
    }
}
