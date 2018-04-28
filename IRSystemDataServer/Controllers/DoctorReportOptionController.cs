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
    public class DoctorReportOptionController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] DoctorReportOption entity)
        {
            DataContext.DoctorReportOption.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<DoctorReportOption>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]DoctorReportOption entity)
        {
            var resp = new ResponseData<DoctorReportOption>();
            try
            {
                var query = from a in DataContext.DoctorReportOption
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
                Logger.LogError("Update Doctor Report Option error", ex);
            }
            return Json(resp);
        }

        [HttpGet]
        public IHttpActionResult Query([FromUri]long catetoryId)
        {
            var resp = new ResponseData<IEnumerable<DoctorReportOption>>();
            try
            {
                var query = from c in DataContext.DoctorReportOption
                            where (catetoryId == 0 || c.CategoryId == catetoryId)
                            select c;
                resp.Data = query;


                //Logger.Log("shitererer");
            }
            catch (Exception ex)
            {
                resp.Message = ex.Message;
                Logger.LogError("query Doctor Report Option error", ex);
            }
            return Json(resp);
        }

    }
}
