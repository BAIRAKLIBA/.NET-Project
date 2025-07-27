using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Models
{
    public  class Supplier
    {
        [Key]
        public int Id { get; set; }

        public string CompanyCode { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string ContactFullName { get; set; }

        public int? CityId { get; set; }
        public virtual City City { get; set; }

        public int? ContryId { get; set; }
        public virtual Country Country { get; set; } 

        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
