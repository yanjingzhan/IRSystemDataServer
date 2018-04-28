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
    public class AreaController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] Area entity)
        {
            DataContext.Area.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<Area>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]Area entity)
        {
            var query = from a in DataContext.Area
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
            return Json(new ResponseData<Area>() { Message = error });
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var error = "";
            var query = from a in DataContext.Area
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
        public IHttpActionResult Query([FromUri]string areaId = "", [FromUri]string parentId = "")
        {
            var query = from a in DataContext.Area
                        where (a.Areaid == areaId || string.IsNullOrEmpty(areaId))
                                && (a.ParentId == parentId || string.IsNullOrEmpty(parentId))
                        select a;
            var responseData = new ResponseData<IEnumerable<Area>>()
            {
                Message = "",
                Data = query
            };
            return this.Json(responseData);
        }
    }
}
