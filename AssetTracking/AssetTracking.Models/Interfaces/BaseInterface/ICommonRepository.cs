using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models.Interfaces
{
    public interface ICommonRepository<T> : IDisposable where T : class
    {
        bool Add(T Entity);
        bool Update(T Entity);
        bool Remove(T Entity);
        T GetById(long id);
        ICollection<T> GetAll();

        bool Add(ICollection<T> entity);
        bool Update(ICollection<T> entities);
    }
}
