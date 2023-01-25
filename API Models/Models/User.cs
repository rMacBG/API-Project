using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Models.Models
{
    public class User : BaseModel
    {

        
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
      
    }
}
