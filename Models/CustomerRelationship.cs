using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project1.Models
{
    [Table("CustomerRelationships")]
    public class CustomerRelationship
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("RelationshipType")]
        public int RelationshipTypeId { get; set; }
    
        public virtual RelationshipType RelationshipType { get; set; }

        [Required, ForeignKey("StartCustomer")]
        public int StartCustomerId { get; set; }
        public virtual Customer StartCustomer { get; set; }

        [Required, ForeignKey("EndCustomer")]
        public int EndCustomerId { get; set; }
        public virtual Customer EndCustomer { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }
    }
}
