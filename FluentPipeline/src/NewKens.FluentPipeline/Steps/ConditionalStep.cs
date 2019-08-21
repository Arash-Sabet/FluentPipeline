using NewKens.FluentPipeline.Abstraction;
using System;
using System.Threading.Tasks;

namespace NewKens.FluentPipeline.Steps
{
    public sealed class ConditionalStep<TInput, TOutput> : IStep<TInput, TOutput>
            where TInput : TOutput
    {
        private readonly IStep<TInput, TOutput> _step;
        private readonly Func<TInput, bool> _conditionMet;

        public ConditionalStep(Func<TInput, bool> condition, IStep<TInput, TOutput> step)
        {
            _conditionMet = condition;
            _step = step;
        }

        public async Task<TOutput> ExecuteAsync(TInput input)
        {
            if (_conditionMet(input))
            {
                return await _step.ExecuteAsync(input);
            }
            else
            {
                return input;
            }
        }
    }
}
