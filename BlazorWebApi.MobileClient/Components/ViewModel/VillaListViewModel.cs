using BlazorWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWebApi.MobileClient.Components.ViewModel
{
    public class VillaListViewModel : INotifyCollectionChanged
    {
        public IEnumerable<Villa>? Villas { get; set; }
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        private HttpClient _httpClient;
        public VillaListViewModel(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task LoadData()
        {
            try
            {
                Villas = await _httpClient.GetFromJsonAsync<IEnumerable<Villa>>("http://10.0.2.2:6170/api/Villa");

            }
            catch (Exception)
            {

                throw;
            }
            //try
            //{
            //    var options = new JsonSerializerOptions
            //    {
            //        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //    };

            //    var handler = new HttpClientHandler();
            //    handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            //    var client = new HttpClient(handler)
            //    {
            //        BaseAddress = new Uri("http://10.0.2.2:6170/") // آدرس API شما
            //    };
            //    _httpClient = client;
            //    var response = await _httpClient.GetStringAsync("api/Villa");
            //    Villas = JsonSerializer.Deserialize<IEnumerable<Villa>>(response, options);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }
    }
}
