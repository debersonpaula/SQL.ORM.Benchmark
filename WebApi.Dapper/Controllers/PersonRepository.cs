using Dapper;
using DataModels;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dapper.Controllers
{
    public class PersonRepository
    {
        private readonly MSSQLConnectionFactory _database;

        public PersonRepository(MSSQLConnectionFactory database)
        {
            _database = database;
        }

        public async Task<PersonModel> GetPersonById(GetPersonByIdParam param)
        {
            var db = _database.GetConnection();

            var person = await db.QueryAsync<PersonModel>(
                "SELECT UserId, FirstName, LastName, JobArea, JobDescriptor, JobTitle, JobType " +
                "FROM DB_BENCHMARK.dbo.TB_PERSON " +
                "WHERE UserId=@UserId",
                new DynamicParameters(param));

            return person.FirstOrDefault();
        }
    }
}
