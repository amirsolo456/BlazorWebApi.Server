using Blazored.LocalStorage;

namespace BlazorWebApi.Client.Components
{
    public class AuthService
    {
        private readonly ILocalStorageService _localStorage;
        public AuthService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        // بررسی وضعیت احراز هویت
        public async Task<bool> IsAuthenticated()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            return !string.IsNullOrEmpty(token);
        }

        // ذخیره توکن JWT در LocalStorage
        public async Task SetAuthenticationToken(string token)
        {
            await _localStorage.SetItemAsync("authToken", token);
        }

        // حذف توکن JWT (خروج)
        public async Task RemoveAuthenticationToken()
        {
            await _localStorage.RemoveItemAsync("authToken");
        }

        // دریافت توکن JWT از LocalStorage
        public async Task<string> GetAuthenticationToken()
        {
            return await _localStorage.GetItemAsync<string>("authToken");
        }
    }
}
