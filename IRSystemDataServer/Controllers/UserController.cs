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
    public class UserController : BaseController
    {
        [HttpPost]
        public IHttpActionResult Login([FromBody]User user)
        {
            var query = from u in DataContext.User
                        where u.Name == user.Name && u.Password == user.Password
                        select u;
            var loginUser = query.FirstOrDefault();
            string error = "";
            if (loginUser == null)
            {
                error = "login failed";
            }
            return this.Json(new ResponseData<User>() { Message = error, Data = loginUser });
        }

        [HttpGet]
        public IHttpActionResult Query([FromUri]string name, string phone = "", string idcard = "")
        {
            var users = DataContext.User.Where(u => (string.IsNullOrEmpty(name) || u.Name.IndexOf(name) >= 0)
                    && (string.IsNullOrEmpty(phone) || u.Phone.StartsWith(phone))
                    && (string.IsNullOrEmpty(idcard) || u.IdCard == idcard)
                    && (u.IsDeleted.HasValue || u.IsDeleted != 1)
            );
            var rd = new ResponseData<IEnumerable<User>>()
            {
                Message = "",
                Data = users
            };
            return this.Json(rd);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var user = DataContext.User.Where(u => u.Id == id).FirstOrDefault();
            return this.Json(user);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody]User entity)
        {
            DataContext.User.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<User>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(int id, [FromBody]User value)
        {
            var query = from a in DataContext.User
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
                Utils.CopyProperties(value, data, ID_EXCEPTION);
                DataContext.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await DataContext.SaveChangesAsync();
            }
            return Json(new ResponseData<User>() { Message = error });
        }

    }
}
