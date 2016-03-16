using System.Threading.Tasks;

namespace BookFast.Common
{
    public interface IQuery<in TModel, TResult>
    {
        Task<TResult> ExecuteAsync(TModel model);
    }
}