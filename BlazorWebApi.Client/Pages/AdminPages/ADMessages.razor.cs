using BlazorWebApi.Client.Shared;

namespace BlazorWebApi.Client.Pages.AdminPages
{
    public partial class ADMessages
    {
        MessageModal messageModal;
        MessageDetailModal messageDetailModal;
        public async Task Openmodal()
        {
            await messageModal.OpenModal();
        }

        public async Task OpenMessageDetailModal()
        {
            await messageDetailModal.OpenModal();
        }
    }
}
