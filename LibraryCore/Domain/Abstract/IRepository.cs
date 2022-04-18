using LibraryCore.Domain.Entities;
using System.Collections.Generic;

namespace LibraryCore.Domain.Abstract
{
    // generic repository interface
    public interface IRepository<T>  
    {
        int Add(T obj);
        bool Update(T obj);
        bool Delete(int id);
        T FindById(int id);
        List<T> Get();
    }
}
