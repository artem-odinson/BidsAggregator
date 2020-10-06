using BidsAggregator.Core.Entities;
using BidsAggregator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BidsAggregator.Core.Specifications
{
    public class SpecificationBase<TEntety> : ISpecification<TEntety> where TEntety : EntityBase
    {
        public Expression<Func<TEntety, bool>> Criteria { get; }

        public List<Expression<Func<TEntety, object>>> Includes { get; } = new List<Expression<Func<TEntety, object>>>();

        public SpecificationBase(Expression<Func<TEntety, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected virtual void AddInclude(Expression<Func<TEntety, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
      
    }
}
