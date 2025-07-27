using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public decimal? TotalAmount { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
