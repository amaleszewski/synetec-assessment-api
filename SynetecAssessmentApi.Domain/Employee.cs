using System;
using SynetecAssessmentApi.Domain.SeedWork;

namespace SynetecAssessmentApi.Domain
{
    public class Employee : Entity
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }

        public int CompanyId { get; private set; }

        public Company Company { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

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
