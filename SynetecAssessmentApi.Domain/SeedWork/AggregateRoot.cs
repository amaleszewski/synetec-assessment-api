using SynetecAssessmentApi.Domain.Abstraction;

namespace SynetecAssessmentApi.Domain.SeedWork
{
    public class AggregateRoot : Entity, IAggregateRoot
    {
        protected AggregateRoot(int id) : base(id)
        {
        }
    }
}