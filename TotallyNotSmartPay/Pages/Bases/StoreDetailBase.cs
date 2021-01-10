using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TotallyNotSmartPay.UIServices.Interfaces;

using TotallyNotSmartPayModels;

namespace TotallyNotSmartPay.Pages.Bases
{
    public class StoreDetailBase : ComponentBase
    {
        [Parameter]
        public int id { get; set; }
        [Inject]
        public IStoreInformationDataService StoreInformationDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public TotallyNotSmartPayModels.StoreInformation StoreInformation { get; set; }
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            if (id == 0)
            {
                StoreInformation = new TotallyNotSmartPayModels.StoreInformation();
            }
            else
            {
                StoreInformation = await StoreInformationDataService.GetStoreInformation(id);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (StoreInformation.Id == 0)
            {
                StoreInformation = await StoreInformationDataService.InsertNewStore(StoreInformation);
            }
            else
            {
                StoreInformation = await StoreInformationDataService.UpdateStore(StoreInformation);
            }

            if(StoreInformation == null)
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong trying to save. Refresh the page and try again.";
            }
            else
            {
                NavigationManager.NavigateTo("/storeinformation");
            }

        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }
    }
}
