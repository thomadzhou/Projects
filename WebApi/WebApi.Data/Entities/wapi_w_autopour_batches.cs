using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//添加主鍵引用
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities
{
    public class wapi_w_autopour_batches
    {
        [Key]
        public int ID { get; set; }
        public int organization_id { get; set; }
        public int machine_no { get; set; }
        public string batch_job { get; set; }
        public string batch_item_name { get; set; }
        public string batch_item_std { get; set; }
        public string batch_item_desc { get; set; }
        public double batch_qty { get; set; }
        public DateTime stop_time { get; set; }
        public string pipe_A_name { get; set; }
        public double pipe_A_qty { get; set; }
        public string pipe_B_name { get; set; }
        public double pipe_B_qty { get; set; }
        public string pipe_C_name { get; set; }
        public double pipe_C_qty { get; set; }
        public string pipe_D_name { get; set; }
        public double pipe_D_qty { get; set; }
        public string pipe_E_name { get; set; }
        public double pipe_E_qty { get; set; }
        public string pipe_F_name { get; set; }
        public double pipe_F_qty { get; set; }
        public string pipe_G_name { get; set; }
        public double pipe_G_qty { get; set; }
        public string pipe_H_name { get; set; }
        public double pipe_H_qty { get; set; }
        public string pipe_I_name { get; set; }
        public double pipe_I_qty { get; set; }
        public string pipe_J_name { get; set; }
        public double pipe_J_qty { get; set; }
        public string pipe_K_name { get; set; }
        public double pipe_K_qty { get; set; }

    }
}
