using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Dapper.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepository personRepository;

        public PersonController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            try
            {
                var user = await personRepository.GetPersonById(new GetPersonByIdParam { UserId = id });

                if (user != null)
                {
                    return Ok(user);
                }

                return NotFound();
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
