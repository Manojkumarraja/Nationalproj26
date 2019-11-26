using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace projNational23.Models
{
    public class Login
    {
        [Key]
        [Display(Name = "Login Id")]
        [Required(ErrorMessage = "Please Enter valid Login Id")]
        public string Login_Id { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
    }
}