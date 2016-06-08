using BookFast.Contracts.Files;
using BookFast.Proxy.Models;

namespace BookFast.Proxy
{
    public interface IFileAccessMapper
    {
        FileAccessToken MapFrom(FileAccessTokenRepresentation representation);
    }
}