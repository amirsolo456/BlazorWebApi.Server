using BlazorWebApi.SharedComponents;

namespace BlazorWebApi.Client.Shared
{
    public partial class Header
    {
        UserLoginComponent userLoginComponent;
        public async Task Openmodal()
        {

            await userLoginComponent.OpenModal();
        }
    }
}
