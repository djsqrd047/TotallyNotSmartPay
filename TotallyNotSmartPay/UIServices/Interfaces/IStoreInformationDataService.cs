using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotallyNotSmartPayModels;

namespace TotallyNotSmartPay.UIServices.Interfaces
{
    public interface IStoreInformationDataService
    {
        Task<string> MarkAsDeleted(int Id);
        Task<StoreInformation> GetStoreInformation(int id);
        Task<StoreInformation> UpdateStore(StoreInformation store);
        Task<List<StoreInformation>> GetAllStores();
        Task<StoreInformation> InsertNewStore(StoreInformation store);
    }
}
