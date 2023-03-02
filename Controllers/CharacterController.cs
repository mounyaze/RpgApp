global using dotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CharacterController : ControllerBase 
    {
        private static List<Character> Characters  = new List<Character> {
            new Character(),
            new Character {Id=1, Name ="Mounya"}

        };
    
        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get()
        {
            return Ok(Characters);
        }
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(Characters.FirstOrDefault(c=> c.Id == id));;
        }
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter){
            Characters.Add(newCharacter);
            return Ok(Characters);
        }
    }
}