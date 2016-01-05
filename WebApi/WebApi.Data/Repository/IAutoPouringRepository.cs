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
        IQueryable<AutoPouring> GetAllAutoPouring();
        IQueryable<AutoPouring> GetAutoPouringByResin(string resin);
        IQueryable<AutoPouring> GetAutoPouringByID(int id);
        IQueryable<AutoPouring> GetAutoPouring(string begTimes, string endTimes, string resin);
        void Insert(AutoPouring autoPouring);
        void Update(AutoPouring autoPouring);
        void Delete(int id);
        bool SaveAll();
    }
}
