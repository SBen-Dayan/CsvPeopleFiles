using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Globalization;
using PeopleGenerator.Data;

namespace PeopleGenerator.Web.Services
{
    internal static class CsvConverter
    {
        public static string ToCsv<T>(List<T> list)
        {
            var writer = new StringWriter();
            var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
            csvWriter.WriteRecords(list);
            return writer.ToString();
        }

        public static List<T> ToList<T>(byte[] csvBytes)
        {
            using var memoryStream = new MemoryStream(csvBytes);
            using var reader = new StreamReader(memoryStream);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csvReader.GetRecords<T>().ToList();
        }
    }
}
