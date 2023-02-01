using API_Models.Models;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Models
{
    public class Book : BaseModel
    {

        public string Name { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;   
        public string Category { get; set; } = string.Empty;
        [StringLength(500000)]
        public string Description { get; set; } = string.Empty;  
        public string ReleaseYear { get; set; } = string.Empty;
        public float AverageRating { get; set; }
        [Range(1, 2500)]

        public int BookPages { get; set; }
       
        public int RatingCount { get; set; }
        //title,authors,categories,description,published_year,average_rating,num_pages,ratings_count
    }

}