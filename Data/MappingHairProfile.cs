using AutoMapper;
using DivaHair.Data.Entities;
using DivaHair.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivaHair.Data
{
    public class MappingHairProfile : Profile
    {
        public MappingHairProfile()
        {
            CreateMap<Order, ViewHairOrder>()
                .ForMember(o => o.OrderId, exc => exc.MapFrom(o => o.Id))
                .ReverseMap();
        }
    }
}
