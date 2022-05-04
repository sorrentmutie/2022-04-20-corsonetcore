using BlazorHttpApi.Models;
using System.Net.Http.Json;

namespace BlazorHttpApi.Services;

public class ReqResService : IReqResService
{
    private readonly IHttpClientFactory httpClientFactory;
    private CancellationTokenSource cancellationTokenSource;

    public ReqResService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public void CancelRequest()
    {
        cancellationTokenSource.Cancel();
    }

    public async Task<ReqResResponse> GetResponse()
    {
        var httpClient = httpClientFactory.CreateClient("reqres");
        cancellationTokenSource = new CancellationTokenSource();

        using var response = await httpClient.GetAsync(
            "users?page=2&delay=10", HttpCompletionOption.ResponseHeadersRead, 
            cancellationTokenSource.Token);
        if(response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ReqResResponse>();
        } else
        {
            return null;
        }
    }

    public async Task<ReqResCreateResponse> PostNewUser(ReqResRequest request)
    {
        var httpClient = httpClientFactory.CreateClient("reqres");
        using var response = await httpClient.PostAsJsonAsync<ReqResRequest>(
            "users", request);
        if(response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ReqResCreateResponse>();
        } else
        {
            return null;
        }

    }
}
