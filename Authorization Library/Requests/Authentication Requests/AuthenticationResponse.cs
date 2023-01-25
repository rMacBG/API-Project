using API_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Requests.Authentication_Requests
{
    public class AuthenticationResponse : BaseModel
    {
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(User user, string token) 
        {

            Username = user.Username;
            Email= user.Email;
            Role= user.Role;
            Token = token;
        }
    }
}
