using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.DTO.Character;

namespace dotNet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> Characters  = new List<Character> {
            
            new  Character(),
            new Character {Id=1, Name ="Mounya"}

        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDto newCharacter)
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = Characters.Max(c => c.Id) + 1;
            Characters.Add(character);
            serviceResponse.Data = Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            try{
            var character = Characters.First(c => c.Id == id);
            if (character is null)
                 throw new Exception($"Charcter with Id '{id}' not found. ");

            Characters.Remove(character);

            serviceResponse.Data = Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            } catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {    
             var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
             var dbCharacters = await _context.characters.ToListAsync();
             serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
             return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var dbCharacter = await _context.characters.FirstOrDefaultAsync(c=> c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(dbCharacter);

            return serviceResponse;
            


        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedcharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            try{
            var character = Characters.FirstOrDefault(c => c.Id == updatedcharacter.Id);
            if (character is null)
                 throw new Exception($"Charcter with Id '{updatedcharacter.Id}' not found. ");

            _mapper.Map(updatedcharacter, character);
                 
            character.Name = updatedcharacter.Name;
            character.HiPoints = updatedcharacter.HiPoints;
            character.Strength = updatedcharacter.Strength;
            character.Defense = updatedcharacter.Defense;
            character.Intelligence = updatedcharacter.Intelligence;
            character.Class = updatedcharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
            } catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
            
        }

    }
}