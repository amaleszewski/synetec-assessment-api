using System;
using SynetecAssessmentApi.Application.Abstraction.Exceptions;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Domain.SeedWork;

namespace SynetecAssessmentApi.Persistence
{
    public class ResourceNotFoundException<TResource> : Exception, INotFound 
        where TResource : Entity
    {
        public ResourceNotFoundException(int key)
            : base($"Resource '{typeof(TResource).Name}' with key '{key}' not found")
        {
        }
    }
}