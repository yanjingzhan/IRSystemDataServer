using IRSystemDataServer.Helpers;
using IRSystemDataServer.Model.Database;
using IRSystemDataServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IRSystemDataServer.Controllers
{
    public class AdminUserRoleController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody]AdminUserRole entity)
        {
            DataContext.AdminUserRole.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<AdminUserRole>() { Data = entity });
        }


        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]AdminUserRole entity)
        {
            var query = from a in DataContext.AdminUserRole
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
            return Json(new ResponseData<AdminUserRole>() {  Message = error });
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var error = "";
            var query = from a in DataContext.AdminUserRole
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
        public IHttpActionResult Query([FromUri]int adminUserId = 0, int roleId = 0)
        {
            var query = from a in DataContext.AdminUserRole
                        where (a.AdminUserId == adminUserId || adminUserId == 0)
                                && (a.RoleId == roleId || roleId == 0)
                        select a;
            var responseData = new ResponseData<IEnumerable<AdminUserRole>>()
            {               
                Message = "",
                Data = query
            };
            return this.Json(responseData);
        }
    }
}
