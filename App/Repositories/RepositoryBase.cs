using App.Users;
using IdeaDesignTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Appdbcontext _db { get; set; }

        public RepositoryBase(Appdbcontext db)
        {
            this._db = db;
        }

        public IEnumerable<T> FindAll()
        {
            return this._db.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._db.Set<T>().Where(expression);
        }

        public T Get(int id)
        {
            return this._db.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            this._db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._db.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._db.Set<T>().Remove(entity);
        }

    }
}
