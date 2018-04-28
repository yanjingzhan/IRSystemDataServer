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
    public class ApointmentController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] Apointment entity)
        {
            DataContext.Apointment.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<Apointment>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]Apointment entity)
        {
            var query = from a in DataContext.Apointment
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
            return Json(new ResponseData<Apointment>() { Message = error });
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var error = "";
            var query = from a in DataContext.Apointment
                        where a.Id == id
                        select a;
            var data = query.FirstOrDefault();
            if (data != null)
            {
                data.State = 3;
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
        public IHttpActionResult Query([FromUri]DateTime apointmentTime, int state = 1, int userId = 0, int machineryId = 0)
        {
            var query = from a in DataContext.Apointment
                        where (a.UserId == userId || userId == 0)
                                && (a.MachineryId == machineryId || machineryId == 0)
                               && a.State == state
                               && (apointmentTime == DateTime.MinValue || a.ApointmentTime == apointmentTime)
                        select a;

            var responseData = new ResponseData<IEnumerable<Apointment>>()
            {
                Message = "",
                Data = query
            };
            return this.Json(responseData);
        }

        [HttpGet, ActionName("querybyname")]
        public async Task<IHttpActionResult> QueryByNameAndDate([FromUri] DateTime? apointmentTime, int state = 1, string patientName = "", int machineryId = 0
            , string phoneNumber = "", string idCardNumber = ""
            )
        {
            return await Task.FromResult(DoQueryByNameAndDate(apointmentTime, state, patientName, machineryId, phoneNumber));
        }

        private IHttpActionResult DoQueryByNameAndDate(DateTime? apointmentTime, int state = 1, string patientName = "", int machineryId = 0
            , string phoneNumber = "", string idCardNumber = "")
        {

            var query = from a in DataContext.Apointment
                        join p in DataContext.User
                        on a.UserId equals p.Id
                        where
                        (p.Name.Contains(patientName) || string.IsNullOrEmpty(patientName))
                               && (a.MachineryId == machineryId)
                               && a.State != state                             
                               && (!apointmentTime.HasValue || a.ApointmentTime.Value.Date == apointmentTime.Value.Date)
                               && (string.IsNullOrEmpty(phoneNumber) || p.Phone.StartsWith(phoneNumber))
                               && (string.IsNullOrEmpty(idCardNumber) || p.IdCard.StartsWith(idCardNumber))
                        orderby a.ApointmentTime descending
                        select new
                        {
                            a.AdminUserId,
                            a.ApointmentTime,
                            a.CreateTime,
                            ApointmentId = a.Id,
                            a.MachineryId,
                            a.ModifiedTime,
                            a.State,
                            a.UserId,
                            p.Name,
                            p.IsMale,
                            p.Birthday,
                            p.IdCard,
                            p.Phone
                        }
                        //select a;
                        ;
            var responseData = new ResponseData<IEnumerable<dynamic>>()
            {
                Message = "",
                Data = query.Take(20)
            };
            return this.Json(responseData);
        }

    }
}
