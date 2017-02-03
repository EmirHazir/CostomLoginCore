using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CostumLogin.Model
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="Gerekli Alan")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gerekli Alan")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gerekli Alan")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gerekli Alan")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Gerekli Alan")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password is not match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

    }
}
