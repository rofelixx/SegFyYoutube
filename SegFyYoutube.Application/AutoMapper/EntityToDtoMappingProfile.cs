using AutoMapper;
using SegFyYoutube.Application.DTO;
using SegFyYoutube.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegFyYoutube.Application.AutoMapper
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<YouTube, YoutubeDto>();
        }
    }
}
