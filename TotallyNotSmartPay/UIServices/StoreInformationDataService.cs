using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TotallyNotSmartPay.UIServices.Interfaces;
using TotallyNotSmartPayModels;

namespace TotallyNotSmartPay.UIServices
{
    public class StoreInformationDataService : IStoreInformationDataService
    {
        private readonly HttpClient _httpClient;

        public StoreInformationDataService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<StoreInformation>> GetAllStores()
        {
            return await JsonSerializer.DeserializeAsync<List<StoreInformation>>(await _httpClient.GetStreamAsync($"api/StoreInformation"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<StoreInformation> GetStoreInformation(int id)
        {
            return await JsonSerializer.DeserializeAsync<StoreInformation>
                     (await _httpClient.GetStreamAsync($"api/StoreInformation/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            //"api/StoreInformation/{id}"
        }

        public async Task<StoreInformation> InsertNewStore(StoreInformation store)
        {
            var storeJson = new StringContent(JsonSerializer.Serialize(store), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/StoreInformation", storeJson);

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<StoreInformation>(response.Content.ReadAsStringAsync().Result,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
            }

            return null;
            //"api/StoreInformation"
        }

        public async Task<string> MarkAsDeleted(int Id)
        {
            var response = await _httpClient.DeleteAsync($"api/StoreInformation/delete/{Id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
                return response.ReasonPhrase;
            //"api/StoreInformation/delete/{id}"
        }

        public async Task<StoreInformation> UpdateStore(StoreInformation store)
        {
            var storeJson = new StringContent(JsonSerializer.Serialize(store), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/StoreInformation/{store.Id}", storeJson);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<StoreInformation>(await response.Content.ReadAsStreamAsync());
            }

            return null;
            //"api/StoreInformation/{id}"
        }
    }
}
