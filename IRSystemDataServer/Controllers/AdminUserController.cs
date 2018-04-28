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
    /// <summary>
    /// 医生，软件使用者，操作员
    /// </summary>   
    public class AdminUserController : BaseController
    {
        //public AdminUserController(InfraredSystemContext context) : base(context) { }
        public AdminUserController() : base()
        {

        }
        public string GetE()
        {
            //DataContext = new Model.Database.InfraredSystemContext();
            return "Hello World";
        }

        [HttpPost]
        public IHttpActionResult GetA(long ids, [FromBody]AdminUser entity)
        {
            //DataContext = new Model.Database.InfraredSystemContext();

            return Json(ids);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody]AdminUser entity)
        {
            entity.PasswordSalt = Guid.NewGuid().ToString();
            entity.Password = (entity.PasswordSalt + entity.Password).Md5();

            DataContext.AdminUser.Add(entity);

            //DataContext.Configuration.ValidateOnSaveEnabled = false;
            await DataContext.SaveChangesAsync();
            //DataContext.Configuration.ValidateOnSaveEnabled = true;

            return Ok(new ResponseData<AdminUser>() {  Data = entity });
        }


        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]AdminUser entity)
        {
            var query = from a in DataContext.AdminUser
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
                data.PasswordSalt = Guid.NewGuid().ToString();
                data.Password = (data.PasswordSalt + entity.Password).Md5();
                DataContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await DataContext.SaveChangesAsync();
            }
            return Json(new ResponseData<AdminUser>() { Message = error });
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var error = "";
            var query = from a in DataContext.AdminUser
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

        [HttpPost]
        public IHttpActionResult Login([FromBody]AdminUser entity)
        {
            var adminUser = CheckUserPassword(entity);
            var resp = new ResponseData<AdminUser>()
            {
                Message = adminUser == null ? "用户名或密码错误" : "",
                Data = adminUser
            };
            if (adminUser != null)
            {
                if (adminUser.IsDeleted == 1 || adminUser.IsDisabled == 1)
                {
                    resp.Message = "用户已经被禁用或删除。";
                }
            }
            return Json(resp);
        }

        [HttpGet]
        public IHttpActionResult GetUserPermissions([FromUri]long userid)
        {
            var query = from p in DataContext.Permission
                        join rolePermission in DataContext.RolePermission
                        on p.Id equals rolePermission.PermissionId
                        join adminuserRole in DataContext.AdminUserRole
                        on rolePermission.RoleId equals adminuserRole.RoleId
                        where adminuserRole.AdminUserId == userid
                        select p;

            var responseData = new ResponseData<IEnumerable<Permission>>()
            {               
                Message = "",
                Data = query.ToList()
            };
            return Json(responseData);
        }

        [HttpGet]
        public IHttpActionResult Query([FromUri]string account = "")
        {
            var query = from a in DataContext.AdminUser
                        where a.Account == account || string.IsNullOrEmpty(account)
                        select a;
            var responseData = new ResponseData<IEnumerable<AdminUser>>()
            {
                Message = "",
                Data = query
            };
            return this.Json(responseData);
        }
    }
}
