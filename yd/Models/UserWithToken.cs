using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yd.Models;

namespace BookStoresWebAPI.Models
{
    public class UserWithToken : User
    {

        public string Token { get; set; }

        public UserWithToken(User user)
        {

            this.EmailAddress = user.EmailAddress;
            this.UserName = user.UserName;
        }
            
    }
}