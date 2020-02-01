using System;
using System.Collections.Generic;
using System.Text;

namespace Bootstrap.Manager.IContract
{
    public interface IBaseManager<T> where T:class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T GetById(int? id);
        ICollection<T> GetByAll();
    }
}
