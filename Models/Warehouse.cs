using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project1.Models
{
    [Table("Warehouse")]
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OperationDate { get; set; }

        [Required, StringLength(50)]
        public string DocNumber { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required, ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        [Required, ForeignKey("Unit")]
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal RealizationPrice { get; set; }
    }
}
