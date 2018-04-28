using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using IRSystemDataServer.Helpers;
using IRSystemDataServer.Model.Database;
using IRSystemDataServer.Models;

namespace IRSystemDataServer.Controllers
{
    public class DoctorMachineryController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] DoctorMachinery entity)
        {
            DataContext.DoctorMachinery.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<DoctorMachinery>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]DoctorMachinery entity)
        {
            var query = from a in DataContext.DoctorMachinery
                        where a.Id == id
                        select a;
            var error = "";
            var data = query.FirstOrDefault();
            if (data == null)
            {
                error = $"data {id} not found";
            }
            else
            {
                Utils.CopyProperties(entity, data, ID_EXCEPTION);
                DataContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await DataContext.SaveChangesAsync();
            }
            return Json(new ResponseData<DoctorMachinery>() { Message = error });
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var error = "";
            var query = from a in DataContext.DoctorMachinery
                        where a.Id == id
                        select a;
            var data = query.FirstOrDefault();
            if (data != null)
            {
                DataContext.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                await DataContext.SaveChangesAsync();
            }
            else
            {
                error = $"data {id} not found.";
            }
            return Json(new ResponseData<int> { Message = error, Data = id });
        }

        [HttpGet]
        public IHttpActionResult Query([FromUri]long doctorid = 0, [FromUri]long machineid = 0)
        {
            var query = from a in DataContext.DoctorMachinery
                        where (a.DoctorId == doctorid || doctorid == 0)
                                && (a.MachineId == machineid || machineid == 0)
                        select a;

            var responseData = new ResponseData<IEnumerable<DoctorMachinery>>()
            {
                Message = "",
                Data = query
            };
            return this.Json(responseData);
        }

    }
}
