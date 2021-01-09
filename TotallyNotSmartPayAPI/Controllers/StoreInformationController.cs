using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using TotallyNotSmartPayModels;

using TotallyNotSmartPayServices.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TotallyNotSmartPayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreInformationController : ControllerBase
    {
        private ITotallyNotSmartPayRepo _TNSPRepo;

        public StoreInformationController(ITotallyNotSmartPayRepo TNSPRepo)
        {
            _TNSPRepo = TNSPRepo ?? throw new ArgumentNullException(nameof(TNSPRepo));
        }
        // GET: api/<StoreInformationController>
        [HttpGet]
        public ActionResult<IEnumerable<StoreInformation>> GetAll()
        {
            return Ok(_TNSPRepo.GetAllStores());
        }

        // GET api/<StoreInformationController>/5
        [HttpGet("{id}", Name = "GetStoreInfo")]
        public ActionResult<StoreInformation> GetStoreInfo(int id)
        {
            var storeFromRepo = _TNSPRepo.GetStoreInformation(id);
            if (storeFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_TNSPRepo.GetStoreInformation(id));
        }

        // POST api/<StoreInformationController>
        [HttpPost]
        public ActionResult<StoreInformation> InsertStore([FromBody] StoreInformation store)
        {
            _TNSPRepo.InsertNewStoreInformation(store);
            if (_TNSPRepo.Save())
            {
                return CreatedAtRoute("GetStoreInfo",
                new { id = store.Id },
                store);
            }
            else
                return StatusCode(500);
        }

        // PUT api/<StoreInformationController>/5
        [HttpPut("{id}")]
        public ActionResult<StoreInformation> UpdateStore([FromBody] StoreInformation store)
        {
            if (_TNSPRepo.UpdateStoreInformation(store))
            {
                if (_TNSPRepo.Save())
                {
                    return CreatedAtRoute("GetStoreInfo",
                        new { id = store.Id },
                        store);
                }

                else
                {
                    return StatusCode(500);
                }
            }
            else
                return StatusCode(500);
        }

        // DELETE api/<StoreInformationController>/delete/5
        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
        {
            if (_TNSPRepo.MarkAsDeleted(id))
                return _TNSPRepo.Save();
            else
                return false;
        }
    }
}
