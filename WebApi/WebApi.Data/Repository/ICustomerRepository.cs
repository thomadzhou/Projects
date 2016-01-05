using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using System.Linq.Expressions;

namespace WebApi.Data.Repository
{
    public interface ICustomerRepository
    {
        IQueryable<Customers> GetAllCustomers();
        IQueryable<Customers> GetCustomerbyID(string id);
        IQueryable<Customers> GetCustomerbyName(string name);
        IQueryable<Customers> GetCustomer(string id,string name);

        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string id);
        bool SaveAll();
    }
}
