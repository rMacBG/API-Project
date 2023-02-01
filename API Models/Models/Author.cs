using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Models
{
    public class Author : BaseModel
    {
        
        public string FullName { get; set; }
        
        public Book book { get; set; }
        
    }
}
