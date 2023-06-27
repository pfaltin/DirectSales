﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DirectSales04.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public int SKU { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }


    }
}
