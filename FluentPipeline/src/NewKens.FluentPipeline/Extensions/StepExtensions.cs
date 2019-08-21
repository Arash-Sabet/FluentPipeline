using NewKens.FluentPipeline.Abstraction;
using NewKens.FluentPipeline.Steps;
using System;
using System.Threading.Tasks;

namespace NewKens.FluentPipeline.Extensions
{
    public static class StepExtensions
    {
        public static Task<TOutput> Step<TInput, TOutput>(this TInput input, IStep<TInput, TOutput> step)
            => step.ExecuteAsync(input);

        public static Task<TOutput> Step<TInput, TOutput>(this TInput input, IStep<TInput, TOutput> step, Action<TInput> inputEvent = null, Action<TOutput> outputEvent = null)
        {
            if (inputEvent != null || outputEvent != null)
            {
                var eventDecorator = new EventStep<TInput, TOutput>(step);
                eventDecorator.OnInput += inputEvent;
                eventDecorator.OnOutput += outputEvent;
                return eventDecorator.ExecuteAsync(input);
            }

            return step.ExecuteAsync(input);
        }
    }
}
