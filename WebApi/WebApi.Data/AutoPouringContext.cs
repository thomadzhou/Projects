using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApi.Data.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApi.Data
{
    public class AutoPouringContext : DbContext
    {
        /// 不自動建立數據庫

        static AutoPouringContext()
        {
            Database.SetInitializer<AutoPouringContext>(null);
        }  
        public AutoPouringContext()
            : base("name=conn")
        {
        }
        public DbSet<AutoPouring> AutoPouring { get; set; }

        ///移除將table名自動變複數的功能
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
