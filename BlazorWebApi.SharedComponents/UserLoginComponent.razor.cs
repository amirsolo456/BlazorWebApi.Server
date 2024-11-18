using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.SharedComponents
{
    public partial class UserLoginComponent
    {
        string id= Guid.NewGuid().ToString();
        [Parameter]
        public RenderFragment? ChildContent { get; set; } = null;
        [Inject] public IJSRuntime? JSRuntime { get; set; }

        public async Task OpenModal()
        {
            await JSRuntime.InvokeVoidAsync("OpenUserLoginModal", id);
        }
    }
}
