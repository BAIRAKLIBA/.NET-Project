using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace project1.Models
{
    [Table("Customers")]
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            PhoneNumbers = new HashSet<CustomerPhoneNumber>();
            Relationships = new HashSet<CustomerRelationship>();
        }

        [Key]
        public int Id { get; set; }


        [Required, StringLength(50)]
        public string FirstName { get; set; }


        [Required, StringLength(50)]
        public string LastName { get; set; }


        [Required]
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }


        [Required, StringLength(11)]
        public string PersonalNumber { get; set; }
        public DateTime? BirthDate { get; set; }


        [Required, ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }


        [Required, ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }


        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CustomerPhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<CustomerRelationship> Relationships { get; set; }

        public virtual ICollection<CustomerRelationship> StartedRelationships { get; set; }
        public virtual ICollection<CustomerRelationship> EndedRelationships { get; set; }

    }
}
