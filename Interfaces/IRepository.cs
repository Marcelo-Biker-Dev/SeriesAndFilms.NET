using System.Collections.Generic;

namespace SeriesAndFilms.NET.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T GetById(int id);        
        void Insert(T element);        
        void Exclude(int id);        
        void Update(int id, T element); 
        int NextId();
    }
}