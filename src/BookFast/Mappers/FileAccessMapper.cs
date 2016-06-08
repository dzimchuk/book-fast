using AutoMapper;
using BookFast.Contracts.Files;
using BookFast.Controllers;
using BookFast.Representations;

namespace BookFast.Mappers
{
    internal class FileAccessMapper : IFileAccessMapper
    {
        private static readonly IMapper Mapper;

        static FileAccessMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<FileAccessToken, ImageUploadToken>();
            });

            mapperConfiguration.AssertConfigurationIsValid();
            Mapper = mapperConfiguration.CreateMapper();
        }

        public ImageUploadToken MapFrom(FileAccessToken token)
        {
            return Mapper.Map<ImageUploadToken>(token);
        }
    }
}
