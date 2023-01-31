using API_Models.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Models
{
    public class Book : BaseModel
    {
       
        public string Name { get; set; }
       
        public string Author { get; set; }
        public string Category { get; set; }
        [StringLength(500000)]
        public string Description { get; set; }

        public string ReleaseYear { get; set; }
        public float AverageRating { get; set; }

        [Range(1, 2500)]
        public int BookPages { get; set; }
        public int RatingCount { get; set; }
    }

}