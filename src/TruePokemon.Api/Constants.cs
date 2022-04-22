using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace TruePokemon.Application;

public static class Constants
{
    internal static readonly IAsyncPolicy<HttpResponseMessage> DefaultRetryPolicy =
        HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1),
                retryCount: 5));
}