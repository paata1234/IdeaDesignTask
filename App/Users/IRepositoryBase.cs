using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Users
{
    public interface IRepositoryBase<T> 
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
