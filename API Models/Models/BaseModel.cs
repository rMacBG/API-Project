
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        
    } 

    }

