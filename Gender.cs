using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace project1.Models
{
    [Table("Gender")]
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
