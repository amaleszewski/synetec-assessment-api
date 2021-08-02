using SynetecAssessmentApi.Domain.Abstraction;

namespace SynetecAssessmentApi.Domain.SeedWork
{
    public class AggregateRoot : Entity, IAggregateRoot
    {
        public AggregateRoot(int id) : base(id)
        {
        }
    }
}