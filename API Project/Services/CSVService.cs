using API_Models;
using API_Models.Context;
using API_Models.Mappers;
using API_Models.Models;
using API_Models.Models.VModels;
using API_Project.Services.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace API_Project.Services
{
    public class CSVService : ICSVService
    {
        private readonly LibContext appContext;
        public CSVService(LibContext appContext)
        {
            this.appContext = appContext;
        }


        public async Task seedBooks(string seed)
        {
            if (await appContext.Books.AnyAsync())
            {
                return;
            }
            using var reader = new StreamReader(seed);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<BookCsvMapper>();
            for (int i = 0; i < 1000; i++)
            {
                csv.Read();
                var model = csv.GetRecord<FileTransferModel>();
                appContext.Add(new Book
                {
                    Name = model.Name,
                    BookAuthor = (ICollection<BookAuthor>)model.Author,
                    Description = model.Description,
                    ReleaseYear = model.ReleaseYear,
                    RatingCount = model.RatingCount,
                    AverageRating = model.AverageRating,
                    BookPages = model.BookPages,
                    Category = model.Category,

                });
                
            }
            if (await appContext.Authors.AnyAsync())
            {
                return;
            }

            csv.Context.RegisterClassMap<AuthorCsvMapper>();
            for (int j = 0; j < 1000; j++)
            {
                csv.Read();
                var model2 = csv.GetRecord<Author>();
                appContext.Add(new Author
                {
                    FullName = model2.FullName
                });
            }
            await appContext.SaveChangesAsync();
        }
        public async Task seedAuthors(string seed)
        {
           
        }
    }
}
