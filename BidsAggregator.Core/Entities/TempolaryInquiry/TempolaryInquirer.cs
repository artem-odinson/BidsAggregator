using System;
using System.Collections.Generic;

namespace BidsAggregator.Core.Entities.TempolaryInquiry
{
    public class TempolaryInquirer : EntityBase, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string FullName => $"{LastName} {FirstName} {MiddleName}";

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Street { get; set; }
        public ushort HouseNumber { get; set; }

        private List<TempolaryInquiry> _inquiries = new List<TempolaryInquiry>();
        public IReadOnlyCollection<TempolaryInquiry> Inquiries => _inquiries.AsReadOnly();

        public TempolaryInquirer() : base() { }

        protected TempolaryInquirer(long id) : base(id) { }

        public TempolaryInquiry CreateInquiry(string body)
        {
            if (string.IsNullOrWhiteSpace(body))
                throw new ArgumentNullException(nameof(body));

            var bid = new TempolaryInquiry(body);
            _inquiries.Add(bid);
            return bid;
        }
    }
}
