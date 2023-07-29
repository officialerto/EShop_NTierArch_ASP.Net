using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "It should be a Maximum of 50 Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Surname")]
        [StringLength(50, ErrorMessage = "It should be a Maximum of 50 Characters")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please Fill in the Correct Format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Username")]
        [StringLength(50, ErrorMessage = "It should be a Maximum of 50 Characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Password")]
        [StringLength(10, ErrorMessage = "It should be a Maximum of 10 Characters")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [Display(Name = "Repassword")]
        [StringLength(10, ErrorMessage = "It should be a Maximum of 10 Characters")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords Do Not Match")]
        public string RePassword { get; set; }

        [StringLength(10, ErrorMessage = "It should be a Maximum of 10 Characters")]
        public string Role { get; set; }

    }
}
