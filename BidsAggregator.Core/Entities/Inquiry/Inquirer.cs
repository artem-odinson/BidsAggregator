using System.Collections.Generic;

namespace BidsAggregator.Core.Entities.Inquiry
{
    public class Inquirer : EntityBase, IAggregateRoot
    {        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string Street { get; set; }
        public ushort HouseNumber { get; set; }

        public ushort? Porch { get; set; }
        public ushort? ApartmentNumber { get; set; }

        private readonly List<Inquiry> _inquiries = new List<Inquiry>();
        public IReadOnlyCollection<Inquiry> Inquiries => _inquiries.AsReadOnly();

        internal Inquirer() : base() { }

        protected Inquirer(long id) : base(id) { }

        public void CreateInquiry(IEnumerable<string> taskBodies)
        {
            var bid = new Inquiry();
            bid.AddTasks(taskBodies);
            _inquiries.Add(bid);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }
    }
}
