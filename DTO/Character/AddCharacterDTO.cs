using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.DTO.Character
{
    public class AddCharacterDto
    {
       
        public string Name  { get; set; } = "Frodo";
        public int HiPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}