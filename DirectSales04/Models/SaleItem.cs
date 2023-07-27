using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectSales04.Models
{
    public class SaleItem
    {
        [Key]
        public int SaleItemID { get; set; }

        [Required]
        public int SaleId { get; set; }
        [ForeignKey(nameof(SaleId))]
        public Sale? Sale { get; set; }


        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int Discount { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal SubTotal { get; set; }

        [Required]
        public ItemStatus Status { get; set; }

        public decimal getSubtotal()
        {
            decimal dscnt = (100 - Discount) / 100;
            SubTotal = (Price * Quantity) * dscnt;
            return SubTotal;
        }



    }

    public enum ItemStatus
    {
        Ordered,
        IsAcquired,
        ForDelivery,
        Delivered,
        ChargedOff,
        Cancelled
    }





}

