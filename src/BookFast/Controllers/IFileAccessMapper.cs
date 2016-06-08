using BookFast.Contracts.Files;
using BookFast.Representations;

namespace BookFast.Controllers
{
    public interface IFileAccessMapper
    {
        ImageUploadToken MapFrom(FileAccessToken token);
    }
}