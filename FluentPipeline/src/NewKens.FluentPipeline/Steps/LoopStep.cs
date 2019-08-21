using NewKens.FluentPipeline.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewKens.FluentPipeline.Steps
{
    public sealed class LoopStep<TInput, TOutput> : IStep<IEnumerable<TInput>, IEnumerable<TOutput>>
    {
        private readonly IStep<TInput, TOutput> _internalStep;

        public LoopStep(IStep<TInput, TOutput> internalStep)
            => _internalStep = internalStep;

        public async Task<IEnumerable<TOutput>> ExecuteAsync(IEnumerable<TInput> input)
        {
            var results = new List<TOutput>();

            foreach (var item in input)
            {
                var output = await _internalStep.ExecuteAsync(item);
                results.Add(output);
            }

            return results;
        }
    }
}
