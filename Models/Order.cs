using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project1.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required, StringLength(50)]
        public string OrderNumber { get; set; }

        [Required]
        [ForeignKey("Customer")]
        [Column("CustomId")] 
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal TotalAmount { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
