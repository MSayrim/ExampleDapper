using Example.CORE.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.CORE.Repository.Abstract.Base
{
    public interface IRepository<T> where T:IBaseEntity
    {
        //Gets
        Task<List<T>> GetAll();
        Task<T> GetByID(Guid ID);
        Task<T> FirstByDefault(Expression<Func<T, bool>> expression);
        Task<List<T>>Get(Expression<Func<T, bool>> expression);
        //Find
        Task<bool> Any(Expression<Func<T, bool>> expression);

        //Create-Delete-Update
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);

        Task Save();
    }
}
