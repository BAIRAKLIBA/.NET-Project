using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Models
{
    [Table("Suppliers")]
    public  class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string CompanyCode { get; set; }

        [Required, StringLength(100)]
        public string CompanyName { get; set; }

        [Required, StringLength(100)]
        public string CompanyFullName { get; set; }

        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        [Required]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string WebSite { get; set; }
        
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
