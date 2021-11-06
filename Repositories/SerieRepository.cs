using System.Collections.Generic;
using SeriesAndFilms.NET.Entities;
using SeriesAndFilms.NET.Interfaces;

namespace SeriesAndFilms.NET.Repositories
{
    public class SerieRepository : IRepository<Serie>
	{
        private List<Serie> serieList = new List<Serie>();

		public List<Serie> List()
		{
			return serieList;
		}

		public Serie GetById(int id)
		{
			return serieList[id];
		}

		public void Insert(Serie serieObject)
		{
			serieList.Add(serieObject);
		}

		public void Exclude(int id)
		{
			serieList[id].Exclude();
		}
		
		public void Update(int id, Serie serieObject)
		{
			serieList[id] = serieObject;
		}

		public int NextId()
		{
			return serieList.Count;
		}
    }
}