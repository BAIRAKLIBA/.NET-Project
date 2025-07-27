using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Models
{
    

    [Table("PhoneTypes")]
    public class PhoneType
    {
        public PhoneType()
        {
            PhoneNumbers = new HashSet<CustomerPhoneNumber>();
        }

        [Key]
        public int Id { get; set; }


        [Required, StringLength(50)]
        public string Name { get; set; }


        public virtual ICollection<CustomerPhoneNumber> PhoneNumbers { get; set; }

    }
}
