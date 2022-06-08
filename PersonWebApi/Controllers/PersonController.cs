using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class PersonController : ControllerBase
    {
        private readonly IPersonBLL _personBLL;
        public PersonController(IPersonBLL personBLL)
        {
            _personBLL = personBLL;
        }

        /// <summary>
        /// Get method used for retrieving all People
        /// </summary>
        /// <returns>List of people. If any was found, empty list is returned</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetAllPersons()
        {
            return Ok(await _personBLL.GetAllPersonsAsync());
        }

        /// <summary>
        /// Get method used for retrieving person with given id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>single person</returns>
        /// <response code="200">Person was returned successfully</response>
        /// <response code="404">Person With given id doesnt exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonModel>> GetPersonById(int id)
        {
            var result = await _personBLL.GetPersonByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Post method used for adding new Person
        /// </summary>
        /// <param name="personModel">Personal data of inserted person</param>
        /// <returns>id of newly added person</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostPerson([FromBody] PersonModel personModel)
        {
            var result = await _personBLL.PostPersonAsync(personModel);
            return Created("person", new { id = result });
        }

        /// <summary>
        /// Delete method used for deleting Person with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _personBLL.DeletePersonAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Update method for updating Person with given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, PersonModel personModel)
        {
            await _personBLL.UpdatePersonAsync(id, personModel);
            return NoContent();
        }

    }
}
