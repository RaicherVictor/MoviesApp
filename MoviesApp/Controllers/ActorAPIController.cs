using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Services;
using MoviesApp.Services.Dto;

namespace MoviesApp.Controllers {
    [Route("api/actor")]
    [ApiController]
    public class ActorApiController : ControllerBase {
        private readonly IServiceActor _service;

        public ActorApiController(IServiceActor service) {
            _service = service;
        }

        [HttpGet] 
        [ProducesResponseType(200, Type = typeof(IEnumerable<ActorDto>))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ActorDto>> GetActor() {
            return Ok(_service.GetActors());
        }

        [HttpGet("{id}")] 
        [ProducesResponseType(200, Type = typeof(ActorDto))]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id) {
            var actor = _service.Get(id);
            if (actor == null) return NotFound();
            return Ok(actor);
        }

        [HttpPost] 
        public ActionResult<ActorDto> PostActor(ActorDto inputDto) {
            var actor = _service.Add(inputDto);
            return CreatedAtAction("GetById", new { id = actor.Id }, actor);
        }

        [HttpPut("{id}")] 
        public IActionResult UpdateActor(int id, ActorDto editDto) {
            var actor = _service.Update(editDto);

            if (actor == null) {
                return BadRequest();
            }

            return Ok(actor);
        }

        [HttpDelete("{id}")]
        public ActionResult<ActorDto> DeleteActor(int id) {
            var actor = _service.Delete(id);
            if (actor == null) return NotFound();
            return Ok(actor);
        }
    }
}