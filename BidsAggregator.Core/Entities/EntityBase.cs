
namespace BidsAggregator.Core.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; private set; }

        protected EntityBase() { }

        protected EntityBase(long id) => Id = id;
    }
}
