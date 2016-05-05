using System.Threading.Tasks;

namespace BookFast.Proxy
{
    public interface IBookFastAPIFactory
    {
        Task<IBookFastAPI> CreateAsync();
    }
}