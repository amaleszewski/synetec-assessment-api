using SynetecAssessmentApi.Domain.Abstraction;

namespace SynetecAssessmentApi.Domain.SeedWork
{
    public abstract class Entity : IEntity
    {
        public int Id { get; }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}
