using System.Collections.Generic;

namespace BidsAggregator.Core.Entities
{

    public class Performer : EntityBase, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName} {MiddleName}";

        public string PhoneNumber { get; set; }

        public ushort PositiveRating { get; private set; }
        public ushort NegativeRating { get; private set; }

        private readonly List<InquiryBase> bids = new List<InquiryBase>();
        public IReadOnlyCollection<InquiryBase> Bids => bids.AsReadOnly();

        internal Performer() : base() { }

        protected Performer(long id) : base(id) { }
    }
}