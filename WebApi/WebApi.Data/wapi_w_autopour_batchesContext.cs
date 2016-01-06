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
    public class wapi_w_autopour_batchesContext : DbContext
    {
        /// 不自動建立數據庫

        static wapi_w_autopour_batchesContext()
        {
            Database.SetInitializer<wapi_w_autopour_batchesContext>(null);
        }  
        public wapi_w_autopour_batchesContext()
            : base("name=conn")
        {
        }
        public DbSet<wapi_w_autopour_batches> wapi_w_autopour_batches { get; set; }

        ///移除將table名自動變複數的功能
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
