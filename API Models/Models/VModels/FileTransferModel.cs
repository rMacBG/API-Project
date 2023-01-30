using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Models.VModels
{
    public class FileTransferModel
    {
        public string Name { get; set; }

        public Author Author { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public float AverageRating { get; set; }
        public int BookPages { get; set; }
        public int RatingCount { get; set; }
    }
}
