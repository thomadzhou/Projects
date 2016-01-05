using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Data.Repository;

namespace WebApi.Test.Controllers
{
    public class CustomersController : ApiController
    {
        ICustomerRepository repository = new CustomerRepository(new CustomersContext());
        public List<Customers> GetAll()
        {
            
            return repository.GetAllCustomers().ToList();
        }
        public List<Customers> GetCustomer(string id, string name)
        {
            try
            {
                List<Customers> items = repository.GetCustomer(id, name).ToList();
                if (items == null)
                    throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
                return items;
                //return repository.GetCustomer(id, name).ToList();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString(), ex);
            }
        }
        public List<Customers> GetCustomerbyID(string id)
        {
            List<Customers> items = repository.GetCustomerbyID(id).ToList();
            if (items == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            return items;
            //return repository.GetCustomerbyID(id).ToList();
        }

        /// <summary>
        /// 這個沒有使用到
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Customers> GetCustomerbyName(string name)
        {
            return repository.GetCustomerbyName(name).ToList();
        }
        public HttpResponseMessage Post([FromBody]Customers customer)
        {
            if (customer == null)
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "無法讀取數據!");

            try
            {
                if (repository.Insert(customer) && repository.SaveAll())
                    return Request.CreateResponse(HttpStatusCode.Created,"新增數據成功!");
                else
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"無法新增數據!");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(string id, [FromBody]Customers customer)
        {
            try
            {
                customer.CustomerID = id;
                if (repository.Update(customer) && repository.SaveAll())
                    return Request.CreateResponse(HttpStatusCode.OK,"更改數據成功!");
                else
                    return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); 
            }
        }

        public HttpResponseMessage Delete(string id)
        {
            try
            {
                var customer = repository.GetCustomerbyID(id);
                if (customer == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                if (repository.Delete(id) && repository.SaveAll())
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest,"刪除失敗");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,ex);
            }
        } 
    }
}
