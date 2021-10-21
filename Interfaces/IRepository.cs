using System.Collections.Generic;

namespace SeriesAndFilms.NET.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Lista();
        T ChooseById(int id);        
        void Insert(T entidade);        
        void Delete(int id);        
        void Update(int id, T entidade);
        int NextId();
    }
}