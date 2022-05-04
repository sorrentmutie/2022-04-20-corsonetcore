using Microsoft.JSInterop;

namespace BlazorHttpApi.Models;

public class MiaPrimoInterop
{
    private readonly IJSRuntime iJSRuntime;

    public MiaPrimoInterop(IJSRuntime iJSRuntime)
    {
        this.iJSRuntime = iJSRuntime;
    }

    public async ValueTask<int> MiaPrimaFunzione(string argomento)
    {
        return await iJSRuntime.InvokeAsync<int>("miaPrimaFunzione", argomento);
    }

    public async ValueTask<int> MiaTerzaFunzione(int a, int b)
    {
        return await iJSRuntime.InvokeAsync<int>("miaTerzaFunzione", a, b);
    }

    public async Task MiaQuartaFunzione(string a)
    {
        await iJSRuntime.InvokeVoidAsync("miaQuartaFunzione", a);
    }

    public async ValueTask MiaQuintaFunzione(string name)
    {
        DotNetObjectReference<HelloHelper> objRef =
            DotNetObjectReference.Create(
                new HelloHelper(name));
        await iJSRuntime.InvokeVoidAsync("miaQuintaFunzione", objRef);
    }

    public async Task ApriModale(string id)
    {
        await iJSRuntime.InvokeVoidAsync("apriModale", id);
    }

    public async Task ChiudiModale()
    {
        await iJSRuntime.InvokeVoidAsync("chiudiModale");
    }

    public async Task CreaChart(string id, int width, int height, ChartData data)
    {
        await iJSRuntime.InvokeVoidAsync("creaChart", id, width, height, data);
    }

    public async Task CreaBarChart(string id, int width, int height, ChartData data)
    {
        await iJSRuntime.InvokeVoidAsync("creaBarChart", id, width, height, data);
    }
}
