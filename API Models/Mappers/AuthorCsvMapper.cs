using API_Models.Models.VModels.CsvModels;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Mappers
{
    public class AuthorCsvMapper : ClassMap<AuthorCsvVModel>
    {
        public AuthorCsvMapper()
        {
            Map(m => m.FullName).Name("authors");
        }
    }
}
