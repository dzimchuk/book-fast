using System.Threading.Tasks;

namespace BookFast.Proxy.RestClient
{
    public interface IAccessTokenProvider
    {
        Task<string> AcquireTokenAsync();
    }
}
