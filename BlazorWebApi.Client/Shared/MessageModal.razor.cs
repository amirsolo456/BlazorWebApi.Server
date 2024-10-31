using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWebApi.Client.Shared
{
    public partial class MessageModal
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        string id = Guid.NewGuid().ToString();
        [Inject] public IJSRuntime? jSRuntime { get; set; }

        public async Task OpenModal()
        {
            await jSRuntime.InvokeVoidAsync("OpenModalByID", id);
        }

    }
}
