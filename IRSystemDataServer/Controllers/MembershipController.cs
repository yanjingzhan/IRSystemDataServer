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
    public class MembershipController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromUri]string account, [FromUri]string password, [FromUri]long machineryId, [FromBody]Membership membership)
        {
            var loginUser = CheckUserPassword(account, password);
            var mtype = (from t in DataContext.MembershipType
                         where t.Id == membership.Type
                         select t).FirstOrDefault();
            var resp = new ResponseData<Membership>();
            if (loginUser == null || mtype == null)
            {
                resp.Message = loginUser == null ? "登录用户验证失败" : "" +
                             mtype == null ? "未找到对应的会员类型" : "";
            }
            else
            {
                //验证用户成功后，invoice增加一条记录，增加一条membership记录。
                var tran = DataContext.Database.BeginTransaction();
                try
                {
                    var m = DataContext.Membership.Add(membership);
                    await DataContext.SaveChangesAsync();
                    var invoice = new Invoice()
                    {
                        MembershipId = m.Id,
                        AdminUserId = loginUser.Id,
                        IsPaid = 0,
                        MachineryId = machineryId,
                        Price = mtype.Price
                    };
                    DataContext.Invoice.Add(invoice);
                    await DataContext.SaveChangesAsync();
                    tran.Commit();
                    resp.Data = m;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    resp.Message = ex.Message;
                    Logger.LogError("add membership error.", ex);
                }
            }
            return Json(resp);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update([FromUri]string account, [FromUri]string password, [FromUri]long machineryId, [FromBody]Membership membership)
        {
            var resp = new ResponseData<Membership>();
            var loginUser = CheckUserPassword(account,password);
            if (loginUser == null)
            {
                resp.Message = "登录用户验证失败";
            }
            else
            {
                var mQuery = from m in DataContext.Membership
                             where m.Id == membership.Id
                             select m;
                var mEntity = mQuery.FirstOrDefault();
                if (mEntity == null)
                {
                    resp.Message = "没有找到这个会员卡";
                }
                else
                {
                    Utils.CopyProperties(membership, mEntity, ID_EXCEPTION);
                    DataContext.Entry(mEntity).State = System.Data.Entity.EntityState.Modified;

                    await DataContext.SaveChangesAsync();
                    resp.Data = mEntity;
                }

            }
            return Json(resp);
        }


        [HttpGet]
        public IHttpActionResult Query([FromUri]long userid, long machineryId, sbyte isValid)
        {
            var resp = new ResponseData<IEnumerable<Membership>>();
            try
            {
                var query = from c in DataContext.Membership
                            where (userid == 0 || c.Userid == userid)
                            && (machineryId == 0 || c.MachineryId == machineryId)
                            && c.IsValid == isValid
                            select c;
                resp.Data = query;


                //Logger.Log("shitererer");
            }
            catch (Exception ex)
            {
                resp.Message = ex.Message;
                Logger.LogError("query Member ship error", ex);
            }
            return Json(resp);
        }
    }
}
