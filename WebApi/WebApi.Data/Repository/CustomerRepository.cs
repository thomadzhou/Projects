using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace WebApi.Data.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private CustomersContext _ctx;
        public CustomerRepository(CustomersContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Customers> GetAllCustomers()
        {
            _ctx.Configuration.ProxyCreationEnabled = false;
            return _ctx.Customers.AsQueryable();
        }

        public IQueryable<Customers> GetCustomerbyID(string id)
        {
            _ctx.Configuration.ProxyCreationEnabled = false;
            return _ctx.Customers.Where(c => c.CustomerID.Equals(id));
        }

        public IQueryable<Customers> GetCustomerbyName(string name)
        {
            _ctx.Configuration.ProxyCreationEnabled = false;
            return _ctx.Customers.Where(c => c.CustomerID.Contains(name));
        }
        public IQueryable<Customers> GetCustomer(string id, string name)
        {
            _ctx.Configuration.ProxyCreationEnabled = false;
            if (id == null && name != null)
            {
                if (name.Contains("*"))
                {
                    Expression<Func<Customers, bool>> theName = c => c.CompanyName.Contains(name);
                    return _ctx.Customers.Where(theName).AsQueryable();
                }
                else
                {
                    Expression<Func<Customers, bool>> theName = c => c.CompanyName.Equals(name,StringComparison.CurrentCultureIgnoreCase);
                    return _ctx.Customers.Where(theName).AsQueryable();
                }
                    
            }
            else if (id != null && name == null)
            {
                Expression<Func<Customers, bool>> theName = c => c.CustomerID.Equals(id);
                return _ctx.Customers.Where(theName).AsQueryable();
            }
            else if (id != null && name != null)
            {
                if (name.Contains("*"))
                {
                    Expression<Func<Customers, bool>> theName = (c => c.CustomerID.Equals(id) && c.CompanyName.Contains(name));
                    return _ctx.Customers.Where(theName).AsQueryable();
                }
                else
                {
                    Expression<Func<Customers, bool>> theName = (c => c.CustomerID.Equals(id) && c.CompanyName.Equals(name));
                    return _ctx.Customers.Where(theName).AsQueryable();
                }
            }
            else
                return GetAllCustomers();

            //return _ctx.Customers.Find(id);
            //return _ctx.Set<Customers>().Where<Customers>(predicate).AsQueryable<Customers>();
        }

        public bool Insert(Customers customer)
        {
            try
            {
                _ctx.Customers.Add(customer);
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool Update(Customers customer)
        {
            try
            {
                //var entry = _ctx.Entry(product);
                //customer.CustomerID = CustomerID;
                _ctx.Set<Customers>().Attach(customer);
                _ctx.Entry(customer).State = EntityState.Modified;
                return true;

            }
            catch
            {

                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var objects = GetCustomerbyID(id);
                foreach (var obj in objects)
                {
                    _ctx.Set<Customers>().Remove(obj);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
