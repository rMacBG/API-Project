using API_Models.Models;

namespace API_Models
{
    public class Category : BaseModel
    {
        public ICollection<Category> CategoryNames { get; set; }
        public Book Book { get; set; }

    }
}