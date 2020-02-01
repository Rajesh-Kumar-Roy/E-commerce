using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bootstrap.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace Bootstrap.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DbContext db;
        public BaseRepository(DbContext db)
        {
            this.db = db;
        }

        public DbSet<T> Tables
        {
            get { return db.Set<T>(); }
        }

        public bool Add(T entity)
        {
            Tables.Add(entity);
            return db.SaveChanges()>0;
        }

        public ICollection<T> GetAll()
        {
           return Tables.ToList();
        }

        public T GetById(int? id)
        {
           return Tables.Find(id);
        }

        public bool Remove(T entity)
        {
            Tables.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
