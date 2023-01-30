using API_Models.Models.VModels;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Mappers
{
    public class BookCsvMapper : ClassMap<FileTransferModel>
    {
        public BookCsvMapper() 
        {
            Map(m => m.Name).Name("title");
            Map(m => m.BookAuthor).Name("authors");
            Map(m => m.Description).Name("description");
            Map(m => m.ReleaseYear).Name("published_year");
            Map(m=> m.Category).Name("categories");
            Map(m => m.BookPages).Name("num_pages");
            Map(m => m.AverageRating).Name("average_rating");
            Map(m => m.RatingCount).Name("ratings_count");

        }
    }
}
