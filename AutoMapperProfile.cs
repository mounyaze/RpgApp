using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDto,Character>();
            CreateMap<UpdateCharacterDTO, Character>(); 
        }
    }
}