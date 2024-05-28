using Faker;
using PeopleGenerator.Data;

namespace PeopleGenerator.Web.Services
{
    internal static class FakerGenerator
    {
        public static List<Person> GeneratePeople(int amount)
        {
            return GeneratePeople(new List<Person>(), amount);
        }

        private static List<Person> GeneratePeople(List<Person> people, int amount)
        {
            var firstName = Name.First();
            people.Add(new()
            {
                FirstName = firstName,
                LastName = Name.Last(),
                Age = RandomNumber.Next(1, 120),
                Address = Address.StreetAddress(),
                Email = Internet.Email(firstName)
            });
            if (amount != 1)
            {
                GeneratePeople(people, amount - 1);
            }
            return people;
        }
    }
}
