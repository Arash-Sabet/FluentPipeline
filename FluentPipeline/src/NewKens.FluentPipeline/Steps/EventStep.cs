using NewKens.FluentPipeline.Abstraction;
using System;
using System.Threading.Tasks;

namespace NewKens.FluentPipeline.Steps
{
    public sealed class EventStep<TInput, TOutput> : IStep<TInput, TOutput>
    {
        public event Action<TInput> OnInput;
        public event Action<TOutput> OnOutput;

        private readonly IStep<TInput, TOutput> _innerStep;

        public EventStep(IStep<TInput, TOutput> innerStep)
            => _innerStep = innerStep;

        public async Task<TOutput> ExecuteAsync(TInput input)
        {
            var output = default(TOutput);

            try
            {
                OnInput?.Invoke(input);
                output = await _innerStep.ExecuteAsync(input);
            }
            finally
            {
                OnOutput?.Invoke(output);
            }
            return output;
        }
    }
}
