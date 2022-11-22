using API_Models.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Models
{
    public class Book : BaseModel
    {
       [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Invalid Author")]
        public Author Author { get; set; }
        [Required(ErrorMessage ="Invalid Year")]
        public string ReleaseYear { get; set; }
        [Range(1, 2500)]
        public int BookPages { get; set; }
        [Required(ErrorMessage ="Invalid Genre")]
        public Genre Genre { get; set; }

        [StringLength(15000)]
        public string Description { get; set; }

        public ICollection<Library> Libraries { get; set; }

    }

}