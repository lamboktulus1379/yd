using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
       
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }
        public string Token { get; set; }
    }
}
