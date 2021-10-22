using System.Collections.Generic;

namespace SeriesAndFilms.NET.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T CheckById(int id);        
        void Insert(T entidade);        
        void Exclude(int id);        
        void Update(int id, T entidade);
        int NextId();
    }
}