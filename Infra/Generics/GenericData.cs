using System.Collections.Generic;
using System.Linq;
using Domain.Service;
using Infra.DataSource;
using System.Data.Entity;
using System;

namespace Infra.Generics
{
    public abstract class GenericData<T, K> : IServiceBase<T, K>
          where T : class
    {
        public void Insert(T entity)
        {
            using (DataContext dc = new DataContext())
            {
                dc.Entry(entity).State = EntityState.Added;
                dc.SaveChanges();
            }
        }

        public T Obter(K id)
        {
            using (DataContext dc = new DataContext())
            {
                return dc.Set<T>().Find(id);
            }
        }

        public ICollection<T> ObterTodos()
        {
            using (DataContext dc = new DataContext())
            {
                return dc.Set<T>().ToList();
            }
        }

        public void Remove(T entity)
        {
            using (DataContext dc = new DataContext())
            {
                dc.Entry(entity).State = EntityState.Deleted;
                dc.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (DataContext dc = new DataContext())
            {
                dc.Entry(entity).State = EntityState.Modified;
                dc.SaveChanges();
            }
        }
    }
}
