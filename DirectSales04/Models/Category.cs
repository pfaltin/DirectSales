using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectSales04.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string CategoryName { get; set; }


        [Column(TypeName = "nvarchar(256)")]
        public string Description { get; set; }

    }
}