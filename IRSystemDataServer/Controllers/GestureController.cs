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
    public class GestureController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] Gesture entity)
        {
            DataContext.Gesture.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<Gesture>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]Gesture entity)
        {
            var resp = new ResponseData<Gesture>();
            try
            {
                var query = from a in DataContext.Gesture
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
            var query = from a in DataContext.Gesture
                        where a.Id == id
                        select a;
            var data = query.FirstOrDefault();
            if (data != null)
            {
                data.IsActive = 0;
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
        public IHttpActionResult Query([FromUri]sbyte? gender)
        {
            var resp = new ResponseData<IEnumerable<Gesture>>();
            try
            {
                var query = from c in DataContext.Gesture
                            where (!gender.HasValue || c.Gender == gender)
                            select c;
                resp.Data = query;


                //Logger.Log("shitererer");
            }
            catch (Exception ex)
            {
                resp.Message = ex.Message;
                Logger.LogError("query Gesture error", ex);
            }
            return Json(resp);
        }

    }
}
