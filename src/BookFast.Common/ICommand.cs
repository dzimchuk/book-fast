using System.Threading.Tasks;

namespace BookFast.Common
{
    public interface ICommand<in TModel>
    {
        Task ApplyAsync(TModel model);
    }
}