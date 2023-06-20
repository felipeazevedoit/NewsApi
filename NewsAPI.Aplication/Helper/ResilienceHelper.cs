
using Polly;

namespace NewsAPI.Aplication.Helper
{

    public static class ResilienceHelper
    {
        public static async Task<T> ExecuteWithResilience<T>(Func<Task<T>> action, int retryCount = 3)
        {
            var retryPolicy = Policy.Handle<Exception>()
                .RetryAsync(retryCount, onRetry: (ex, retryAttempt) =>
                {
                    Console.WriteLine($"Retrying due to exception: {ex.Message}. Retry attempt: {retryAttempt}");
                });

            var circuitBreakerPolicy = Policy.Handle<Exception>()
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30),
                    onBreak: (ex, breakDelay) =>
                    {
                        Console.WriteLine($"Circuit breaker opened due to exception: {ex.Message}. Delay: {breakDelay.TotalSeconds} seconds.");
                    },
                    onReset: () =>
                    {
                        Console.WriteLine("Circuit breaker reset.");
                    });

            //var fallbackPolicy = Policy<T>.Handle<Exception>()
            //    .FallbackAsync(default(T), async (ex, context, cancellationToken) =>
            //    {
            //        Console.WriteLine($"Fallback executed due to exception: {ex.Exception}");
            //        await Task.CompletedTask;
            //    });

            var policyWrap = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy).WrapAsync(null);

            return await policyWrap.ExecuteAsync(action);
        }
    }
}
