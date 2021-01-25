using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotallyNotSmartPay.UIServices.Interfaces;

namespace TotallyNotSmartPay.Pages.Bases
{
    public class StoreInfoGridBase : ComponentBase
    {
        [Parameter]
        public List<string> ColumnNames { get; set; }
        [Parameter]
        public List<TotallyNotSmartPayModels.StoreInformation> StoreList { get; set; }
        public bool ShowDeleted { get; set; } = false;
        public int FiltererdStoreNumber { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        IJSRuntime JS { get; set; }
        [Inject]
        public IStoreInformationDataService StoreInformationDataService { get; set; }



        public void EditStore(int id) => NavigationManager.NavigateTo($"/storeinformation/{id}");

        public async Task DeleteStore(int id)
        {
            if (await JS.InvokeAsync<bool>("confirm", "Are you sure you want to mark this store as deleted?"))
            {
                if (await JS.InvokeAsync<bool>("exampleJsFunctions.deleteStoreDisplayNumber", StoreList.Where(x => x.Id == id).FirstOrDefault().StoreNumber))
                    await StoreInformationDataService.MarkAsDeleted(id);
            }
            //StateHasChanged();
            NavigationManager.NavigateTo($"/storeinformation", forceLoad: true);
        }
    }
}
