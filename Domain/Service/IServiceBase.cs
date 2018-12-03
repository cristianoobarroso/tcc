using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
   public interface IServiceBase<T,K>
        where T : class
    {
        void Insert(T entity);
        void Remove(T entity);
        void Update(T entity);
        ICollection<T> ObterTodos();
        T Obter(K id);
    }
}
