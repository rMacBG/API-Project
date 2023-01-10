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

        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
    
        public string Password { get; set; }
    }
}
