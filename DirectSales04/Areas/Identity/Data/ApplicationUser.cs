using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DirectSales04.Areas.Identity.Data
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }


    }
}
