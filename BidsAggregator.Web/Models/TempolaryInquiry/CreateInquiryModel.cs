using System.ComponentModel.DataAnnotations;

namespace BidsAggregator.Web.Models.TempolaryInquiry
{
    public sealed class CreateInquiryModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]      
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]        
        [MaxLength(20)]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(70)]
        public string Street { get; set; }
        [Required]       
        public ushort HouseNumber { get; set; }

        [Required]
        [MaxLength(500)]
        public string InquiryBody { get; set; }
    }
}
