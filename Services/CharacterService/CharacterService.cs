using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace project.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
         private static List<Character> characters  = new List<Character>{
            new Character(),
            new Character {Id=1,Name = "Sam"}
        };

        public CharacterService(IMapper mapper)
        {
            
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            characters.Add(newCharacter);
            serviceResponse.Data=characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> Get()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data=characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetSingle(int id)
        {
            var serviceResponse = new ServiceResponse <GetCharacterDto>();
            var character =characters.FirstOrDefault(c=>c.Id==id);
            serviceResponse.Data=character;
            return serviceResponse;
        }
    }
}