using Faker;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleGenerator.Data;
using PeopleGenerator.Web.Models;
using PeopleGenerator.Web.Services;
using System.Net;
using System.Text;

namespace PeopleGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly string _connectionString;

        public PeopleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpGet("getAll")]
        public List<Person> Get() => new PeopleRepository(_connectionString).Get();

        [HttpPost("deleteAll")]
        public void DeleteAll() => new PeopleRepository(_connectionString).DeleteAll();

        //[HttpGet("generate")]
        //public IActionResult Generate(int amount)
        //{
        //    var people = FakerGenerator.GeneratePeople(amount);
        //    var csv = CsvConverter.ToCsv(people);
        //    return File(Encoding.UTF8.GetBytes(csv), "text/csv", "people.csv");
        //}

        [HttpPost("generate")]
        public void Generate(GenerateModel model)
        {
            var people = FakerGenerator.GeneratePeople(model.Amount);
            var csv = CsvConverter.ToCsv(people);
            System.IO.File.WriteAllBytes("GeneratedPeople/people", Encoding.UTF8.GetBytes(csv));
        }

        [HttpGet("getGeneratedPeople")]
        public IActionResult GetGeneratedPeople()
        {
            return File(System.IO.File.ReadAllBytes("GeneratedPeople/people"), "application/octet-stream", "people.csv");
        }

        [HttpPost("upload")]
        public void Upload(UploadModel model)
        {
            var csvBytes = Convert.FromBase64String(FixBase64(model.Base64));
            var people = CsvConverter.ToList<Person>(csvBytes);
            new PeopleRepository(_connectionString).AddRange(people);
        }

        private static string FixBase64(string base64) => base64.Substring(base64.IndexOf(',') + 1);

        
    }
}
