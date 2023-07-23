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


    public class ApplicationUserViewModel
    {

        [StringLength(50)]
        public string FirstName { get; set; }


        [StringLength(50)]
        public string LastName { get; set; }


        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string PhoneNumber { get; set; }


        [StringLength(400)]
        public string Id { get; set; }

    }
}
