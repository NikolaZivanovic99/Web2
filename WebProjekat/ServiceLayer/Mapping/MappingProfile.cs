using AutoMapper;
using DataLayer.Model;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, AdminDto>().ReverseMap(); //Kazemo mu da mapira Subject na SubjectDto i obrnuto
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<Dostavljac, DostavljacDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<OrderModel, OrderDto>().ReverseMap();
            CreateMap<UserModel, AddUpdateUserDto>().ReverseMap();
            CreateMap<Admin, AddUpdateAdminDto>().ReverseMap();
        }
    }
}
