using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SegFyYoutube.Application.AutoMapper;
using System;

namespace SegFyYoutube.WebApi.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(EntityToDtoMappingProfile), typeof(DtoToEntityMappingProfile));
        }
    }
}
