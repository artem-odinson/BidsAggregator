using BidsAggregator.Core.Entities;
using System.Collections.Generic;

namespace BidsAggregator.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase, IAggregateRoot
    {

        TEntity GetEntry(long entryId);
        IEnumerable<TEntity> GetEntries();        

        void Add(TEntity entry);
        void Update(TEntity entry);
        void Delete(long entryId);

        TEntity GetEntry(ISpecification<TEntity> spec);
        IEnumerable<TEntity> GetEntries(ISpecification<TEntity> spec);
    }
}
