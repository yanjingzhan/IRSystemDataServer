using IRSystemDataServer.Helpers;
using IRSystemDataServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace IRSystemDataServer.Controllers
{
    public class BaseController : ApiController
    {
        //public BaseController(Model.Database.InfraredSystemContext dataContext)
        //{
        //    DataContext = dataContext;
        //}


        public BaseController()
        {
            //DataContext = new Model.Database.InfraredSystemContext();
        }

        public readonly static LogHelper Logger = new LogHelper();
        //public Model.Database.InfraredSystemContext DataContext { get; set; }
        public readonly static Model.Database.InfraredSystemContext DataContext = new Model.Database.InfraredSystemContext();
        //public Model1 DataContext = new Model1();

        public readonly static string[] ID_EXCEPTION = new string[] { "id" };

        /// <summary>
        /// 验证密码，正确返回adminuser对象，错误返回null
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [NonAction]
        public IRSystemDataServer.Model.Database.AdminUser CheckUserPassword(IRSystemDataServer.Model.Database.AdminUser entity)
        {
            var query = from a in DataContext.AdminUser
                        where a.Account == entity.Account
                        select a;
            var data = query.FirstOrDefault();
            if (data != null)
            {
                var saltedPass = data.PasswordSalt + entity.Password;

                if (saltedPass.Md5() == data.Password && data.IsDeleted != 1 && data.IsDisabled != 1)
                {
                    Utils.CopyProperties(data, entity, new string[] { "password", "passwordsalt" });// keep pwd and salt secret
                    // password correct
                    return entity;
                }
            }
            return null;
        }

        /// <summary>
        /// 验证密码，正确返回adminuser对象，错误返回null
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [NonAction]
        public IRSystemDataServer.Model.Database.AdminUser CheckUserPassword(string account,string password)
        {
            var query = from a in DataContext.AdminUser
                        where a.Account == account
                        select a;
            var data = query.FirstOrDefault();
            if (data != null)
            {
                var saltedPass = data.PasswordSalt + password;

                if (saltedPass.Md5() == data.Password && data.IsDeleted != 1 && data.IsDisabled != 1)
                {
                    //Utils.CopyProperties(data, entity, new string[] { "password", "passwordsalt" });// keep pwd and salt secret
                    // password correct
                    return data;
                }
            }
            return null;
        }


    }
}