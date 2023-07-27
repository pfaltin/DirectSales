using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectSales04.Models
{

    public class Sale
    {
        [Key]
        public int SalesId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client? Client { get; set; }


        [Required]
        public DateTime Date { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string? Remarks { get; set; }

    }




}
