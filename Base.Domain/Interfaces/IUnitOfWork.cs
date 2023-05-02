using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Base.Domain.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> expression);
        IEnumerable<T> OrderBy(Expression<Func<T, bool>> expression);
        IEnumerable<T> FromSql(string commandText, params object[] parameters);
        int Insert(T model);
        bool Update(T model, int id);
        bool Delete(int id);
    }
}
