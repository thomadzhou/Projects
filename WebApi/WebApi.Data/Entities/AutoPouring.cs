using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//添加主鍵引用
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities
{
    public class AutoPouring
    {
        [Key]
        public int SpcID { get; set; }
        public DateTime SampleTimes { get; set; }
        public string ResinNo { get; set; }
        public decimal SetRate { get; set; }
        public string Aname { get; set; }
        public decimal A { get; set; }
        public string Bname { get; set; }
        public decimal B { get; set; }
        public string Cname { get; set; }
        public decimal C { get; set; }
        public string Dname { get; set; }
        public decimal D { get; set; }
        public string Ename { get; set; }
        public decimal E { get; set; }
        public string Fname { get; set; }
        public decimal F { get; set; }
        public string Gname { get; set; }
        public decimal G { get; set; }
        public string Hname { get; set; }
        public decimal H { get; set; }
        public string Iname { get; set; }
        public decimal I { get; set; }
        public string Jname { get; set; }
        public decimal J { get; set; }
        public decimal TotalRate { get; set; }
    }
}
