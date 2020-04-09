using AutoMapper;
using SegFyYoutube.Application.DTO;
using SegFyYoutube.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegFyYoutube.Application.AutoMapper
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<YoutubeDto, YouTube>();
        }
    }
}
