using AutoMapper;
using BookFast.Contracts.Files;
using BookFast.Proxy.Models;
using System;

namespace BookFast.Proxy.Mappers
{
    internal class FileAccessMapper : IFileAccessMapper
    {
        private static readonly IMapper Mapper;

        static FileAccessMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<string, AccessPermission>().ConvertUsing(permission => (AccessPermission)Enum.Parse(typeof(AccessPermission), permission));
                configuration.CreateMap<FileAccessTokenRepresentation, FileAccessToken>();
            });

            mapperConfiguration.AssertConfigurationIsValid();
            Mapper = mapperConfiguration.CreateMapper();
        }

        public FileAccessToken MapFrom(FileAccessTokenRepresentation representation)
        {
            return Mapper.Map<FileAccessToken>(representation);
        }
    }
}
