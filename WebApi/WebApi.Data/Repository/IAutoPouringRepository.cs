using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using System.Linq.Expressions;


namespace WebApi.Data.Repository
{
    public interface IAutoPouringRepository
    {
        IQueryable<wapi_w_autopour_batches> GetAllAutoPouring();
        IQueryable<wapi_w_autopour_batches> GetAutoPouringByResin(string resin);
        IQueryable<wapi_w_autopour_batches> GetAutoPouringByID(int id);
        IQueryable<wapi_w_autopour_batches> GetAutoPouring(string begTimes, string endTimes, string resin);
        void Insert(wapi_w_autopour_batches autoPouring);
        void Update(wapi_w_autopour_batches autoPouring);
        void Delete(int id);
        bool SaveAll();
    }
}
