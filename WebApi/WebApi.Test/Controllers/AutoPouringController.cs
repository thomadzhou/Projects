using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Data.Repository;
using System.Globalization;

namespace WebApi.Test.Controllers
{
    public class AutoPouringController : ApiController
    {
        IAutoPouringRepository repository = new AutoPouringRepository(new AutoPouringContext());
        public List<AutoPouring> GetAll()
        {
            return repository.GetAllAutoPouring().ToList();
        }

        public List<AutoPouring> GetAutoPouringByID(int id)
        {
            List<AutoPouring> items = repository.GetAutoPouringByID(id).ToList();
            if (items == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            return items;
            //return repository.GetCustomerbyID(id).ToList();
        }
        public List<AutoPouring> GetAutoPouringByResin(string resin)
        {
            List<AutoPouring> items = repository.GetAutoPouringByResin(resin).ToList();
            if (items == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            return items;
            //return repository.GetCustomerbyID(id).ToList();
        }

        public List<AutoPouring> GetAutoPouring([FromUri]string begTimes, [FromUri]string endTimes, [FromUri]string resin)
        {
            try
            {
                List<AutoPouring> items = repository.GetAutoPouring(begTimes, endTimes, resin).ToList();
                if (items == null)
                    throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
                return items;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString(), ex);
            }
        }
        public HttpResponseMessage Post([FromBody]AutoPouring autopouring)
        {
            if (autopouring == null)
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "無法讀取數據!");

            try
            {
                repository.Insert(autopouring);
                if(repository.SaveAll())
                    return Request.CreateResponse(HttpStatusCode.Created, "新增xxxx成功!");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "無法新增數據!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Put(int id, [FromBody]AutoPouring autopouring)
        {
            try
            {
                autopouring.SpcID = id;
                repository.Update(autopouring);
                if (repository.SaveAll())
                    return Request.CreateResponse(HttpStatusCode.OK, "更改數據成功!");
                else
                    return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                //var customer = repository.GetCustomerbyID(id);
                //if (customer == null)
                //    return Request.CreateResponse(HttpStatusCode.NotFound);
                repository.Delete(id);
                if (repository.SaveAll())
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "刪除失敗");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        } 
    }
}
