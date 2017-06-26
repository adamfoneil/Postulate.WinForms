using Postulate.Orm.Abstract;
using Postulate.Orm.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
    public class Customer : Record<int>
    {
        [ForeignKey(typeof(Organization))]
        public int OrganizationId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        
        [DefaultExpression("0")]
        public bool IsTaxExempt { get; set; }

        [DefaultExpression("1")]
        public bool SendNewsletter { get; set; }
    }
}
