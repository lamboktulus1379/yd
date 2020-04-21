using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class UserWithToken : User
    {
        public string Token { get; set; }

        public UserWithToken(User user)
        {
            this.Id = user.Id;
            this.EmailAddress = user.EmailAddress;
            this.UserName = user.UserName;
        }
    }
}
