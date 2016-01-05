using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.Globalization;
using System.Data.Objects.SqlClient;
using System.Data.Objects;

namespace WebApi.Data.Repository
{
    public class AutoPouringRepository:IAutoPouringRepository
    {
        private AutoPouringContext _apc;
        public AutoPouringRepository(AutoPouringContext apc)
        {
            _apc=apc;
        }
        public IQueryable<AutoPouring> GetAllAutoPouring()
        {
            _apc.Configuration.ProxyCreationEnabled = false;
            return _apc.AutoPouring.AsQueryable();
        }
        public IQueryable<AutoPouring> GetAutoPouringByID(int id)
        {
            _apc.Configuration.ProxyCreationEnabled = false;
            return _apc.AutoPouring.Where(a => a.SpcID.Equals(id));
        }
        public IQueryable<AutoPouring> GetAutoPouringByResin(string resin)
        {
            _apc.Configuration.ProxyCreationEnabled = false;
            return _apc.AutoPouring.Where(a => a.ResinNo.Contains(resin) || resin ==null);
        }
        public IQueryable<AutoPouring> GetAutoPouring(string begTimes, string endTimes, string resin)
        {
            _apc.Configuration.ProxyCreationEnabled = false;
            DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            DateTime begtime, endtime;
            begtime = Convert.ToDateTime(begTimes, dtFormat);//DateTime.Parse(begTimes);
            //begtime = DateTime.Parse(begTimes);
            endtime = Convert.ToDateTime(endTimes, dtFormat);//DateTime.Parse(endTimes); 

           // Expression<Func<AutoPouring, bool>> sqlstr = a => (Convert.ToDateTime(a.SampleTimes.ToShortDateString(),dtFormat)>=begtime)
           //                  && (Convert.ToDateTime(a.SampleTimes.ToShortDateString(), dtFormat) <= endtime)
            //                 && (a.ResinNo.Contains(resin) || resin == null);

            ///ef6中使用DbFunctions解決日期比較問題,使用System.Data.Objects.SqlClient.SqlFunctions會報錯
            var query = from a in _apc.AutoPouring
                        where (DbFunctions.TruncateTime(a.SampleTimes)>=begtime || begtime==null)
                           && (DbFunctions.TruncateTime(a.SampleTimes)<=endtime|| endtime==null)
                           //&&   DbFunctions.DiffDays(a.SampleTimes,endtime)<=0  DbFunctions.
                           && (a.ResinNo.Contains(resin) || resin == null)
                        select a;
               return query;
  
            //Expression<Func<AutoPouring, bool>> theName = (a => a.SampleTimes.ToString("yyyy-MM-dd HH:mm:ss")> begTimes && a.ResinNo.Contains(resin));
            //var query = _apc.AutoPouring.Where(sqlstr.Compile()).AsQueryable();

        }
        public void Insert(AutoPouring autoPouring)
        {

            _apc.AutoPouring.Add(autoPouring);

        }
        public void Update(AutoPouring autoPouring)
        {
            try
            {
                _apc.Set<AutoPouring>().Attach(autoPouring);
                _apc.Entry(autoPouring).State = EntityState.Modified;
                //return true;

            }
            catch
            {

                //throw new HttpRequestException(HttpStatusCode..ToString());
            }
        
        }
        public void Delete(int id)
        {
            try
            {

                _apc.AutoPouring.Remove(_apc.AutoPouring.Find(id));

            }
            catch
            {
                //return false;
            }
        
        }
        public bool SaveAll()
        {
            return _apc.SaveChanges() > 0;
        }

    }
}
