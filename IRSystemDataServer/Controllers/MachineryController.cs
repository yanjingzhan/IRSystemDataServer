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
    public class MachineryController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] Machinery entity)
        {
            DataContext.Machinery.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<Machinery>() { Data = entity });
        }


        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]Machinery entity)
        {
            var resp = new ResponseData<Machinery>();
            try
            {
                var query = from a in DataContext.Machinery
                            where a.Id == id
                            select a;
                var error = "";
                var data = query.FirstOrDefault();
                if (data == null)
                {
                    error = $"data {id} not found";
                    resp.Message = error;
                }
                else
                {
                    Utils.CopyProperties(entity, data, ID_EXCEPTION);
                    DataContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    await DataContext.SaveChangesAsync();
                    resp.Data = data;
                }
            }
            catch (Exception ex)
            {
                resp.Message = ex.Message;
                Logger.LogError("Update Gesture error", ex);
            }
            return Json(resp);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var error = "";
            var query = from a in DataContext.Machinery
                        where a.Id == id
                        select a;
            var data = query.FirstOrDefault();
            if (data != null)
            {
                data.IsDeleted = 1;
                DataContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await DataContext.SaveChangesAsync();
            }
            else
            {
                error = $"data {id} not found.";
            }
            return Json(new ResponseData<int> { Message = error, Data = id });
        }

        [HttpGet]
        public IHttpActionResult Query([FromUri]string machineCode)
        {
            var resp = new ResponseData<IEnumerable<Machinery>>();
            try
            {
                var query = from a in DataContext.Machinery
                            where (!string.IsNullOrWhiteSpace(machineCode) || a.Machinecode == machineCode)
                            
                            select a;
                resp.Data = query;
            }
            catch (Exception ex)
            {
                resp.Message = ex.Message;
                Logger.LogError("query Machinery error", ex);
            }


            var t =  Microsoft.Extensions.Configuration.ConfigurationBuilder().
            return Json(resp);

                        
        }

    }
}
