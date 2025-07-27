using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Models
{
    [Table("Warehouse")]
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public DateTime OperationDate { get; set; }
        public string DocNumber { get; set; }

        public int ProductId { get; set; }
        public virtual ProductCategory Product { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit {get ;set;}

        public decimal Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? RealizationPrice { get; set; }
    }
}
