using Microsoft.EntityFrameworkCore;
using Base.Domain.Interfaces;
using Base.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Base.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        protected DataContext Context;
        public DbSet<T> DbSet;

        public UnitOfWork()
        {

        }

        public UnitOfWork(DataContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual T GetById(int id) =>
            DbSet.Find(id);

        public virtual IEnumerable<T> GetAll() =>
            DbSet.ToList();

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> expression) =>
            DbSet.Where(expression).ToList();

        public virtual IEnumerable<T> OrderBy(Expression<Func<T, bool>> expression) =>
            DbSet.OrderBy(expression).ToList();

        public virtual IEnumerable<T> FromSql(string commandText, params object[] parameters) =>
            DbSet.FromSqlRaw(commandText, parameters).ToList();

        public virtual int Insert(T model)
        {
            DbSet.Add(model);

            return Context.SaveChanges();
        }

        public virtual bool Update(T model, int id)
        {
            var result = true;
            T entity = DbSet.Find(id);

            if (entity != null)
            {
                Context.Entry(entity).CurrentValues.SetValues(model);
                if (Context.SaveChanges() == 0)
                    result = false;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public virtual bool Delete(int id)
        {
            var result = true;
            T entity = DbSet.Find(id);

            if (entity != null)
            {
                var entry = Context.Entry(entity);
                if (entry.State == EntityState.Detached)
                    DbSet.Attach(entity);

                Context.Entry(entity).State = EntityState.Modified;
                if (Context.SaveChanges() == 0)
                    result = false;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static void Dispose()
        {
        }
    }
}
