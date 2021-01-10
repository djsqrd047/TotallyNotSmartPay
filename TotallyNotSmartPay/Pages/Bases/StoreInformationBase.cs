using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TotallyNotSmartPay.UIServices.Helpers;
using TotallyNotSmartPay.UIServices.Interfaces;

using TotallyNotSmartPayModels;

namespace TotallyNotSmartPay.Pages.Bases
{
    public class StoreInformationBase : ComponentBase
    {
        [Inject]
        public IStoreInformationDataService StoreInformationDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        IJSRuntime JS { get; set; }
        public List<TotallyNotSmartPayModels.StoreInformation> AllStores { get; set; }
        public List<string> Columns { get; set; }
        public bool ShowDeleted { get; set; } = false;
        public int FiltererdStoreNumber { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AllStores = await StoreInformationDataService.GetAllStores();
            Columns = Helpers.GetPropertyNames(AllStores.FirstOrDefault());
        }

        public void EditStore(int id) => NavigationManager.NavigateTo($"/storeinformation/{id}");

        public async Task DeleteStore(int id)
        {
            if (await JS.InvokeAsync<bool>("confirm", "Are you sure you want to mark this store as deleted?"))
            {
                await StoreInformationDataService.MarkAsDeleted(id);
            }
            await Task.Run(() => StateHasChanged());
        }

        public void FilterStoreByNumber(ChangeEventArgs e)
        {
            int storeNumber;
            if (int.TryParse(e.Value.ToString(), out storeNumber))
                FiltererdStoreNumber = storeNumber;
            else
                FiltererdStoreNumber = 0;
        }
    }
}
