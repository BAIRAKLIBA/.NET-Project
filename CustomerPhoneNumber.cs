using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Models
{
    [Table("CustomersPhoneNumbers")]
    public class CustomerPhoneNumber
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("PhoneType")]
        public int PhoneTypeId { get; set; }
        public virtual PhoneType PhoneType { get; set; }

        [StringLength(9)]
        public string PhoneNumber { get; set; }

        public bool IsMain { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
