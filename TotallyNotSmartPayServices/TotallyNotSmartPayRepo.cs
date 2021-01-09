using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TotallyNotSmartPayDbContext;

using TotallyNotSmartPayModels;

using TotallyNotSmartPayServices.Interfaces;

namespace TotallyNotSmartPayServices
{
    public class TotallyNotSmartPayRepo : ITotallyNotSmartPayRepo
    {
        private MyDbContext _context;
        public TotallyNotSmartPayRepo(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<StoreInformation> GetAllStores()
        {
            return _context.StoreInformation.ToList();
        }

        public StoreInformation GetStoreInformation(int Id)
        {
            return _context.StoreInformation.Where(x => x.Id == Id).FirstOrDefault();
        }

        public bool InsertNewStoreInformation(StoreInformation storeInformation)
        {
            bool saved;
            try
            {
                if (storeInformation == null)
                {
                    saved = false;
                    throw new ArgumentNullException(nameof(storeInformation));
                }
                else
                {
                    _context.StoreInformation.Add(storeInformation);
                    saved = true;
                }

            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }

            return saved;
        }

        public bool MarkAsDeleted(int Id)
        {
            bool saved = false;
            try
            {
                if (Id == null)
                {
                    saved = false;
                    throw new ArgumentNullException(nameof(Id));
                }
                else
                {
                    var storeToDelete = _context.StoreInformation.Where(x => x.Id == Id).FirstOrDefault();
                    storeToDelete.IsDeleted = true;
                    saved = UpdateStoreInformation(storeToDelete); 
                }
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }

            return saved;

            
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }



        public bool UpdateStoreInformation(StoreInformation storeInformation)
        {
            bool saved = false;
            try
            {
                if (storeInformation == null)
                {
                    saved = false;
                    throw new ArgumentNullException(nameof(storeInformation));
                }
                else
                {
                    var storeToUpdate = GetStoreInformation(storeInformation.Id);
                    storeToUpdate.StoreNumber = storeInformation.StoreNumber;
                    storeToUpdate.Address = storeInformation.Address;
                    storeToUpdate.SINId = storeInformation.SINId;
                    storeToUpdate.VINId = storeInformation.VINId;
                    storeToUpdate.RINId = storeInformation.RINId;
                    storeToUpdate.IsDeleted = storeInformation.IsDeleted;
                    saved = true;
                }
            }
            catch (Exception ex)
            {
                //log exception
                return false;
            }

            return saved;
        }
    }
}
