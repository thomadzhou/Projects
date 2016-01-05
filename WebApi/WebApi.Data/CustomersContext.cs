using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApi.Data.Entities;

namespace WebApi.Data
{
    public class CustomersContext:DbContext
    {
        ///public CustomersContext(string connString)
        public CustomersContext()
            : base("name=conn")
        { 
        }
        public DbSet<Customers> Customers { get; set; }
    }
}
