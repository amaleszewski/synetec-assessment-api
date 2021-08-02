using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Domain.SeedWork;

namespace SynetecAssessmentApi.Persistence
{
	public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
		where TAggregateRoot : AggregateRoot
	{
		protected readonly DbContext Context;
		protected readonly IMapper Mapper;

		protected Repository(DbContext context, IMapper mapper)
		{
			Context = context;
			Mapper = mapper;
		}

		protected IQueryable<TAggregateRoot> ReadWriteEntitySet => WithIncludes(Context.Set<TAggregateRoot>());

		protected IQueryable<TAggregateRoot> ReadOnlyEntitySet => Context.Set<TAggregateRoot>().AsNoTracking();

		/// <summary>
		/// Throws error if the specified item does not exist 
		/// </summary>
		/// <param name="key">The unique identifier</param>
		/// <param name="cancellationToken">The cancellation token</param>
		/// <returns>Entity</returns>
		public Task<TAggregateRoot> GetAsync(
			int key, CancellationToken cancellationToken)
		{
			Expression<Func<TAggregateRoot, bool>> predicate = a => a.Id.Equals(key);
			
			var task = ReadWriteEntitySet.SingleAsync(predicate, cancellationToken);

			return MapExceptionAsync<TAggregateRoot, TAggregateRoot>(task, key);
		}

		public Task<TResponse> GetAsync<TResponse>(int key, CancellationToken cancellationToken) where TResponse : IResponse
		{
			Expression<Func<TAggregateRoot, bool>> predicate = a => a.Id.Equals(key);
			
			var task = Mapper.ProjectTo<TResponse>(ReadOnlyEntitySet.Where(predicate)).SingleAsync(cancellationToken);
			
			return MapExceptionAsync<TAggregateRoot, TResponse>(task, key);
		}
		
		public Task<List<TResponse>> GetAllAsync<TResponse>(CancellationToken cancellationToken) where TResponse : IResponse
		{
			return Mapper.ProjectTo<TResponse>(ReadOnlyEntitySet).ToListAsync(cancellationToken);
		}

		public TAggregateRoot Add(TAggregateRoot root)
		{
			if (root == null)
			{
				throw new ArgumentNullException(nameof(root));
			}

			return Context.Add(root).Entity;
		}

		public TAggregateRoot Update(TAggregateRoot root)
		{
			if (Context.Entry(root).State == EntityState.Added)
			{
				return root;
			}

			Context.Entry(root).State = EntityState.Modified;

			return root;
		}

		public TAggregateRoot Delete(TAggregateRoot root)
		{
			return Context.Set<TAggregateRoot>().Remove(root).Entity;
		}

		protected virtual IQueryable<TAggregateRoot> WithIncludes(DbSet<TAggregateRoot> set)
		{
			return set;
		}

		protected Task<TResult> MapExceptionAsync<TEntity, TResult>(Task<TResult> task, int key = default)
			where TEntity : Entity
		{
			if (task == null)
			{
				throw new ArgumentNullException(nameof(task));
			}

			var tcs = new TaskCompletionSource<TResult>();

			task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
			task.ContinueWith(t => tcs.TrySetResult(t.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

			task.ContinueWith(
				t =>
				{
					if (t.Exception!.GetBaseException() is InvalidOperationException exception)
					{
						switch (exception.TargetSite.Name)
						{
							case "ThrowNoElementsException":
							case "MoveNext":
								return tcs.TrySetException(new ResourceNotFoundException<TEntity>(key));
						}
					}

					return tcs.TrySetException(t.Exception);
				},
				TaskContinuationOptions.OnlyOnFaulted);

			return tcs.Task;
		}
	}
}
