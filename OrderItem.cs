using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Models
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        public decimal Quantity { get; set; }
        public bool IsDiscounted { get; set; }
        public decimal? DiscountPrice { get; set; }
    }
}
