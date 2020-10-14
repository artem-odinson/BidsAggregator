using BidsAggregator.Core.Entities;
using BidsAggregator.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BidsAggregator.Infrastructure.Data
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        protected DbContext Context { get; }

        public RepositoryBase(BidsAggregatorContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Context = context;
        }

        public TEntity GetEntry(long entryId)
        {
            TEntity entity = Context.Set<TEntity>().Find(entryId);
            if (entity == null)
                throw new NullReferenceException($"Entity of type {typeof(TEntity).Name} with Id {entryId} is not found");

            return entity;
        }

        public IEnumerable<TEntity> GetEntries() => 
            Context.Set<TEntity>().ToList();

        public void Add(TEntity entry) => 
            Context.Set<TEntity>().Add(entry);
       

        public void Update(TEntity entry) => 
            Context.Entry(entry).State = EntityState.Modified;

        public void Delete(long entryId)
        {
            DbSet<TEntity> entries = Context.Set<TEntity>();
            TEntity entity = entries.Find(entryId);
            if (entity == null)
                throw new NullReferenceException($"Entity of type {typeof(TEntity).Name} with Id {entryId} is not found");

            entries.Remove(entity);
        }

        public TEntity GetEntry(ISpecification<TEntity> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(Context.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            return queryableResultWithIncludes.SingleOrDefault(spec.Criteria);
        }

        public IEnumerable<TEntity> GetEntries(ISpecification<TEntity> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(Context.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            return queryableResultWithIncludes.Where(spec.Criteria).ToList();
        }
    }
}
