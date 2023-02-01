using API_Models;
using API_Models.Context;
using API_Models.Mappers;
using API_Models.Models;
using API_Models.Models.VModels;
using API_Project.Services.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task seed(string seed)
        {
            if (await appContext.Books.AnyAsync())
            {
                return;
            }
            using var reader = new StreamReader(seed);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var random = new Random();
            csv.Context.RegisterClassMap<BookCsvMapper>();
            while (csv.Read())
            { 
                var model = csv.GetRecord<FileTransferModel>();
                appContext.Add(new Book
                {
                    Name = model.Name,
                    Author = model.Author,
                    Description = model.Description,
                    ReleaseYear = model.ReleaseYear,
                    RatingCount = model.RatingCount,
                    AverageRating = model.AverageRating,
                    BookPages = model.BookPages,
                    Category = model.Category,
                });
            }
            await appContext.SaveChangesAsync();
        }
    }
}

