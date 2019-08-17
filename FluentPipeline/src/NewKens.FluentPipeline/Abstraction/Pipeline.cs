using System;
using System.Threading.Tasks;

namespace NewKens.FluentPipeline.Abstraction
{
    public abstract class Pipeline<TInput, TOutput> : IStep<TInput, TOutput>
    {
        public Func<TInput, Task<TOutput>> Steps { get; protected set; }

        public Task<TOutput> ExecuteAsync(TInput input)
            => Steps(input);
    }
}
