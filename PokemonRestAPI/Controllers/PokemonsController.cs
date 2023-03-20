using Microsoft.AspNetCore.Mvc;
using PokemonRestAPI.Repositories;
using PokemonLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonRestAPI.Controllers
{
    [Route("api/[controller]")]
    //URI: api/pokemons - [controller] tager namespace navnet og fjerner "controller"
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private IPokemonsRepository _repository;

        public PokemonsController(IPokemonsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Pokemons?namefilter=har
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Pokemon>> GetAll([FromQuery]string? namefilter, [FromQuery] int? amount, [FromQuery]int? minlevel, [FromQuery]int? minpokedex)
        {
            List<Pokemon> result = _repository.GetAll(namefilter, amount, minlevel, minpokedex);
            if (result.Count < 1)
            {
                return NoContent(); //NotFound er også ok
            }
            Response.Headers.Add("TotalAmount", "" + result.Count());
            return Ok(result);
        }

        // GET api/<PokemonsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Pokemon?> Get(int id)
        {
            Pokemon? foundPokemon = _repository.GetById(id);
            if (foundPokemon == null)
            {
                return NotFound();
            }
            return Ok(foundPokemon);
        }

        // POST api/<PokemonsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Pokemon> Post([FromBody] Pokemon newPokemon)
        {
            try
            {
                Pokemon createdPokemon = _repository.AddPokemon(newPokemon);
                return Created($"api/pokemons/{createdPokemon.Id}", newPokemon);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PokemonsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Pokemon?> Put(int id, [FromBody] Pokemon update)
        {
            try
            {
                Pokemon? updatePokemon = _repository.UpdatePokemon(id, update);
                if (updatePokemon == null)
                {
                    return NotFound();
                }
                return Ok(updatePokemon);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<PokemonsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Pokemon?> Delete(int id)
        {
            if (_repository.GetById(id) == null)
            {
                return NotFound();
            }
            Pokemon? deletePokemon = _repository.GetById(id);
            string deletePokemonName = deletePokemon.Name;
            _repository.DeletePokemon(id);
            return Ok($"{deletePokemonName} was deleted");
        }
    }
}
