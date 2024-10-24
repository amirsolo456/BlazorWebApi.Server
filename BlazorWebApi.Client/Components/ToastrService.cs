using Microsoft.JSInterop;
using System.Threading.Tasks;

public class ToastrService
{
    private readonly IJSRuntime _jsRuntime;

    public ToastrService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ShowSuccess(string message, string title = "")
    {
        await _jsRuntime.InvokeVoidAsync("toastrService.success", message, title);
    }

    public async Task ShowError(string message, string title = "")
    {
        await _jsRuntime.InvokeVoidAsync("toastrService.error", message, title);
    }
}
