using API_Models.Context;
using API_Models.Mappers;
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
        

        public async Task seed(string seed)
        {
            if (await appContext.Books.AnyAsync())
            {
                return;
            }
            using var reader = new StreamReader(seed);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<BookCsvMapper>();
            for(int i = 0; i < 1000; i++) 
            { 
                csv.Read();

            }
        }
    }
}
