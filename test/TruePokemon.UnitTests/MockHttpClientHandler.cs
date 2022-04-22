using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TruePokemon.UnitTests;

public class MockHttpClientHandler : DelegatingHandler
{
    private readonly Dictionary<Uri, HttpResponseMessage> _mockResponses = new();

    public void AddMockResponse(Uri uri, HttpResponseMessage responseMessage)
    {
        _mockResponses.Add(uri, responseMessage);
    }

    public void AddMockResponse(Uri uri, HttpStatusCode statusCode, string responseContent)
    {
        HttpResponseMessage responseMessage = new HttpResponseMessage(statusCode);
        responseMessage.Content = new StringContent(responseContent);
            
        _mockResponses.Add(uri, responseMessage);
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {
        if (_mockResponses.ContainsKey(request.RequestUri))
        {
            return await Task.FromResult(_mockResponses[request.RequestUri]);
        }

        return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request });
    }
}