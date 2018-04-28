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
    public class DoctorReportCategoryController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] DoctorReportCategory entity)
        {
            DataContext.DoctorReportCategory.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<DoctorReportCategory>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]DoctorReportCategory entity)
        {
            var resp = new ResponseData<DoctorReportCategory>();
            try
            {
                var query = from a in DataContext.DoctorReportCategory
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
            catch(Exception ex)
            {
                resp.Message = ex.Message;
                Logger.LogError("Update doctor report category error", ex);
            }
            return Json(resp);
        }

        [HttpGet]
        public IHttpActionResult Query([FromUri]long parentId)
        {
            var resp = new ResponseData<IEnumerable<DoctorReportCategory>>();
            try
            {
                var query = from c in DataContext.DoctorReportCategory
                            where (parentId == 0 || c.Parentid == parentId)
                            select c;
                resp.Data = query;


                //Logger.Log("shitererer");
            }
            catch (Exception ex)
            {
                resp.Message = ex.Message;
                Logger.LogError("query doctor report category error",ex);
            }
            return Json(resp);
        }
    }
}
