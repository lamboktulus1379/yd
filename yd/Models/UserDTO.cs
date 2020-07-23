using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
