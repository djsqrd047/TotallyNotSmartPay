using System;
using System.Collections.Generic;
using System.Text;

using TotallyNotSmartPayModels;

namespace TotallyNotSmartPayServices.Interfaces
{
    public interface ITotallyNotSmartPayRepo
    {
        public IEnumerable<StoreInformation> GetAllStores();
        public StoreInformation GetStoreInformation(int Id);
        public bool MarkAsDeleted(int Id);
        public bool InsertNewStoreInformation(StoreInformation storeInformation);
        public bool UpdateStoreInformation(StoreInformation storeInformation);
        public bool Save();
    }
}
