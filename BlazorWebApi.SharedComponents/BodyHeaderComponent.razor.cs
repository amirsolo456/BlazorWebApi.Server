using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.SharedComponents
{
    public partial class BodyHeaderComponent
    {
        UserLoginComponent userLoginComponent;
        public async Task Openmodal()
        {

            await userLoginComponent.OpenModal();
        }
    }
}
