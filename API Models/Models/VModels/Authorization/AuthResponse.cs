using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Models.VModels.Authorization
{
    public class AuthResponse
    {
 
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
    }
}
