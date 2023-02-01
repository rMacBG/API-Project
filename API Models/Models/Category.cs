using API_Models.Models;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Models
{
    public class Category : BaseModel
    {
        
        public string CategoryNames { get; set; }

        public Book MyProperty { get; set; }

    }
}