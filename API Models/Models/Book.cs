using API_Models.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Models
{
    public class Book : BaseModel
    {
       
        public string Name { get; set; }
       
        public string Author { get; set; }
        
        public string ReleaseYear { get; set; }
        [Range(1, 2500)]
        public int BookPages { get; set; }
        public ICollection<Genre> Genre { get; set; }

        [StringLength(15000)]
        public string Description { get; set; }

        public ICollection<Library> Libraries { get; set; }

    }

}