using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.SharedComponents.SideBars.HomeRight
{
    public class HomeRightSideBarService
    {
        //public string SelectedCategory { get; private set; }

        public event Action OnVillaOptions;
        public event Action OnBookingStep;
        public event Action OnFAQ;
        public event Action OnSupport;

        public void UpdateToVillaOptions()
        {
            OnVillaOptions?.Invoke(); // اطلاع‌رسانی به سایر کامپوننت‌ها
        }

        public void UpdateToBookingSteps()
        {
            OnBookingStep?.Invoke();
        }
        public void UpdateToFAQ()
        {
            OnFAQ?.Invoke();
        }

        public void UpdateToSupport()
        {
            OnSupport?.Invoke();
        }
    }
}
