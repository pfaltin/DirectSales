using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectSales04.Models
{
    public class Client
{
    [Key]
    public int ClientId { get; set; }
    
    [Required]
     [Column(TypeName = "nvarchar(128)")]
    public string Title { get; set; }
    
    [Required]
     [Column(TypeName = "nvarchar(16)")]
    public string OIB { get; set; }

    [Required]
     [Column(TypeName = "nvarchar(128)")]
    public string Email { get; set; }
    
     [Column(TypeName = "nvarchar(128)")]
    public string Phone { get; set; }
    
    [Column(TypeName = "ntext")]
    public string Remarks { get; set; }

    [Required]    
    [Column(TypeName = "nvarchar(128)")]
    public string Street { get; set; }

    [Required]
     [Column(TypeName = "nvarchar(32)")]
    public string City { get; set; }
    
    [Required]
     [Column(TypeName = "nvarchar(32)")]
    public string Country { get; set; }
    
    [Required]
     [Column(TypeName = "nvarchar(16)")]
    public string PostalCode { get; set; }

}

}