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
    public class InfraredDataController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] InfraredData entity)
        {
            DataContext.InfraredData.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<InfraredData>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]InfraredData entity)
        {
            var resp = new ResponseData<InfraredData>();
            try
            {
                var query = from a in DataContext.InfraredData
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
            var query = from a in DataContext.InfraredData
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
        public IHttpActionResult Query([FromUri]long apointmentId, long userid, DateTime date)
        {
            var resp = new ResponseData<IEnumerable<InfraredData>>();
            try
            {
                var query = from a in DataContext.InfraredData
                            where (userid == 0 || a.UserId == userid)
                            && (date.Date == DateTime.MinValue || (a.CreateTime > date.Date && a.CreateTime < date.Date.AddDays(1)))
                            && (apointmentId == 0 || a.ApointmentId == apointmentId)
                            select a;
                resp.Data = query;


                //Logger.Log("shitererer");
            }
            catch (Exception ex)
            {
                resp.Message = ex.Message;
                Logger.LogError("query Infrared Datas error", ex);
            }
            return Json(resp);
        }
    }
}
