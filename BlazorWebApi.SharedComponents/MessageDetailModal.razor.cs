using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWebApi.SharedComponents
{
    public partial class MessageDetailModal
    {
        [Parameter]
        public int? MessageID { get; set; }

        [Parameter]
        public int? IDGroup { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }= null;
        string Id = Guid.NewGuid().ToString();
        [Inject] public IJSRuntime? JSRuntime { get; set; }

        public async Task OpenModal()
        {
            await JSRuntime.InvokeVoidAsync("OpenModalDynamic", Id);
        }
    }
}
