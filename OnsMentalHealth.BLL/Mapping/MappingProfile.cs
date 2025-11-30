using AutoMapper;
using OnsMentalHealth.BLL.DTOs;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateReactionDto, Reaction>();
            CreateMap<UpdateReactionDto, Reaction>();
            CreateMap<Reaction, ReactionResponseDto>();
        }
    }
}
