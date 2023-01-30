using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Models.VModels
{
    public class BookCsvVModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public float AverageRating { get; set; }
        public int BookPages { get; set; }
        public int RatingCount { get; set; }
    }
}
