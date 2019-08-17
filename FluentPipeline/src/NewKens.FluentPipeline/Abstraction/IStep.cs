using System.Threading.Tasks;

namespace NewKens.FluentPipeline.Abstraction
{
    public interface IStep<in TInput, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }
}
