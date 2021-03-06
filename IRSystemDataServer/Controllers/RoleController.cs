﻿using System;
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
    public class RoleController : BaseController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody]Role entity)
        {
            DataContext.Role.Add(entity);
            await DataContext.SaveChangesAsync();

            return Json(new ResponseData<Role>() { Data = entity });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(long id, [FromBody]Role entity)
        {
            var resp = new ResponseData<Role>();
            try
            {
                var query = from a in DataContext.Role
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
                Logger.LogError("Update Role error", ex);
            }
            return Json(resp);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var error = "";
            var query = from a in DataContext.Role
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
        public IHttpActionResult Query([FromUri]string name)
        {
            var query = from a in DataContext.Role
                        where (a.Name == name || string.IsNullOrEmpty(name))
                        select a;
            var responseData = new ResponseData<IEnumerable<Role>>()
            {
                Message = "",
                Data = query
            };
            return this.Json(responseData);
        }
    }
}
