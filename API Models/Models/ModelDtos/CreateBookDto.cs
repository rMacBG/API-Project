using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Models.ModelDtos
{
    public class CreateBookDto
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Range(1, 2500)]
        public int BookPages { get; set; }
        public string Description { get; set; }
    }
}
