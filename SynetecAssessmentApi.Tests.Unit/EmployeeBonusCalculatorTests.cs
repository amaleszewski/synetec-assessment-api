using System;
using FluentAssertions;
using SynetecAssessmentApi.Domain.Services;
using Xunit;

namespace SynetecAssessmentApi.Tests.Unit
{
    public class EmployeeBonusCalculatorTests
    {
        private readonly EmployeeBonusCalculator _employeeBonusCalculator;

        public EmployeeBonusCalculatorTests()
        {
            _employeeBonusCalculator = new EmployeeBonusCalculator();
        }

        [Theory]
        [InlineData(1500, 10000, 123456, 18518.40)]
        [InlineData(60000, 724300, 50000, 4141.93)]
        [InlineData(74320, 420530, 72000, 12724.51)]
        [InlineData(85000, 1200000, 140000, 9916.67)]
        [InlineData(0, 20000, 140000, 0)]
        [InlineData(0, 0, 0, 0)]
        public void Calculate_ReturnsProperValue(int salary, int totalCompanyWages, int companyBonusPool, decimal expectedBonus)
        {
            var result = _employeeBonusCalculator.Calculate(salary, totalCompanyWages, companyBonusPool);

            result.Should().Be(expectedBonus);
        }

        [Fact]
        public void Calculate_TotalCompanyWagesEqualsZero_ShouldNotThrowDivideByZeroException()
        {
            Func<decimal> act = () => _employeeBonusCalculator.Calculate(60000, 0, 0);

            act.Should().NotThrow<DivideByZeroException>();
        }
    }
}