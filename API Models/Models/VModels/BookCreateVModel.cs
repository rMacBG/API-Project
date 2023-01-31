using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Models.VModels
{
    public class BookCreateVModel
    {
        public string Name { get; set; }

       public string Author { get; set; }
        public string Category { get; set; }
        [StringLength(15000)]
        public string Description { get; set; }

        public string ReleaseYear { get; set; }
        [Range(1, 2500)]
        public int BookPages { get; set; }

    }
}
