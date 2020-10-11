using Bogus;
using DataModels;
using MockData.Models;

namespace MockData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PersonContext())
            {
                var persons = FakePerson().Generate(5000);
                db.People.AddRange(persons);
                db.SaveChanges();
            }
        }

        static Faker<PersonModel> FakePerson()
        {
            return new Faker<PersonModel>()
                .RuleFor(u => u.FirstName, (f,u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(u => u.JobArea, (f, u) => f.Name.JobArea())
                .RuleFor(u => u.JobDescriptor, (f, u) => f.Name.JobDescriptor())
                .RuleFor(u => u.JobTitle, (f, u) => f.Name.JobTitle())
                .RuleFor(u => u.JobType, (f, u) => f.Name.JobType());
        }
    }


}
