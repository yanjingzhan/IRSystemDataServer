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
    public class MembershipTypeController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody]MembershipType entity)
        {
            DataContext.MembershipType.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<MembershipType>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]MembershipType membershipType)
        {
            var resp = new ResponseData<MembershipType>();

            var mQuery = from m in DataContext.MembershipType
                         where m.Id == membershipType.Id
                         select m;
            var mEntity = mQuery.FirstOrDefault();
            if (mEntity == null)
            {
                resp.Message = "没有找到这个套餐类型";
            }
            else
            {
                Utils.CopyProperties(membershipType, mEntity, ID_EXCEPTION);
                DataContext.Entry(mEntity).State = System.Data.Entity.EntityState.Modified;
                await DataContext.SaveChangesAsync();
                resp.Data = membershipType;
            }
            return Json(resp);
        }

        [HttpGet]
        public IHttpActionResult Query()
        {
            var resp = new ResponseData<IEnumerable<MembershipType>>();
            try
            {
                var query = from c in DataContext.MembershipType
                            select c;
                resp.Data = query;
            }
            catch (Exception ex)
            {
                resp.Message = ex.Message;
                Logger.LogError("query Member ship Type error", ex);
            }
            return Json(resp);
        }

    }
}
