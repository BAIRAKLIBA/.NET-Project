using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Models
{
    [Table("CustomerRelationships")]
    public class CustomerRelationship
    {
        [Key]
        public int Id { get; set; }

        public int RelationshipTypeId { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }

        public int StartCustomerId { get; set; }
        public virtual Customer StartCustomer { get; set; }

        public int EndCustomerId { get; set; }
        public virtual Customer EndCustomer { get; set; }

        public string Comment { get; set; }
    }
}
