using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Models.Models.ModelDtos
{
    public class BookDto
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public string ReleaseYear { get; set; }
        public int BookPages { get; set; }
        public ICollection<Genre> Genre { get; set; }

        [StringLength(15000)]
        public string Description { get; set; }

        public ICollection<Library> Libraries { get; set; }
    }
}
