using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> Get();
        Task<ServiceResponse<GetCharacterDto>> GetSingle(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    }
}