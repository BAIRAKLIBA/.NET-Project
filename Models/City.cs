using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace project1.Models
{
    [Table("Cities")]
    public class City
    {
        public City()
        {
            Customers = new HashSet<Customer>();
            Suppliers = new HashSet<Supplier>();
        }
        //This is comment
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
