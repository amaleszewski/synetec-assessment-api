using SynetecAssessmentApi.Domain.Abstraction;

namespace SynetecAssessmentApi.Domain.SeedWork
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        protected AggregateRoot(int id) : base(id)
        {
        }
    }
}