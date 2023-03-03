using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> Characters  = new List<Character> {
            new Character(),
            new Character {Id=1, Name ="Mounya"}

        };
        public async Task<List<Character>> AddCharacter(Character newCharacter)
        {
            Characters.Add(newCharacter);
            return Characters;
        }    

        public async Task<List<Character>> GetAllCharacters()
        {
             return Characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {

            var Character = Characters.FirstOrDefault(c=> c.Id == id);
            if(Character is not null)
                return Character;
            throw new Exception("character is not found wii3 :("); 


        }
    
    }
}