using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bootstrap.Manager.IContract;
using Bootstrap.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace Bootstrap.Manager.Base
{
    public class BaseManager<T>:IBaseManager<T> where T:class
    {

        private IBaseRepository<T> _baseRepository;

        public BaseManager(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool Add(T entity)
        {
            return _baseRepository.Add(entity);
        }

        public bool Update(T entity)
        {
            return _baseRepository.Update(entity);

        }

        public bool Remove(T entity)
        {
            return _baseRepository.Remove(entity);
        }

        public T GetById(int? id)
        {
            return _baseRepository.GetById(id);
        }

        public ICollection<T> GetByAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
