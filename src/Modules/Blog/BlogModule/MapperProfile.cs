using AutoMapper;
using BlogModule.Domain;
using BlogModule.Services.DTOs.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModule
{
   public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, BlogCategoryDto>().ReverseMap();
        }
    }
}
