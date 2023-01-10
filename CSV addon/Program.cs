using API_Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace CSV_addon
{
    public class Program
    {
       public static void Main(string[] args) { 

            var fileName = @"<C:\Users\vlady\source\repos\src\API Project\CSV addon\CSV\books.csv>";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };
            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var reader = new StreamReader(fs, Encoding.UTF8)) 
                using (var csv = new CsvReader(reader, configuration))
                {
                    var data = csv.GetRecords<Book>();
                    foreach (var book in data)
                    {

                    }
                }
            }
        }
    }
}