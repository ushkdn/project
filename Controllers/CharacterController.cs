using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Services.CharacterService;

namespace project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        public ICharacterService _characterService { get; }

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetSingle(id));
        }

        [HttpPost]
        [Route("CreateOne")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(
            AddCharacterDto newCharacter
        )
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        [Route("UpdateOne")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(
            UpdateCharacterDto updatedCharacter
        )
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
