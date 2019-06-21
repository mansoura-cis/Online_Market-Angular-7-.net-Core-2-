using System;
using System.ComponentModel.DataAnnotations;

namespace market{
    
   public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name ="User Name")]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }



}