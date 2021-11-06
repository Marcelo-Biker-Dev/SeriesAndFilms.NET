using System.Collections.Generic;
using SeriesAndFilms.NET.Entities;
using SeriesAndFilms.NET.Interfaces;

namespace SeriesAndFilms.NET.Repositories
{
    public class MusicAlbumRepository : IRepository<MusicAlbum>
    {
                private List<MusicAlbum> albumList = new List<MusicAlbum>();

		public List<MusicAlbum> List()
		{
			return albumList;
		}

		public MusicAlbum GetById(int id)
		{
			return albumList[id];
		}

		public void Insert(MusicAlbum MusicAlbumObject)
		{
			albumList.Add(MusicAlbumObject);
		}

		public void Exclude(int id)
		{
			albumList[id].Exclude();
		}
		
		public void Update(int id, MusicAlbum MusicAlbumObject)
		{
			albumList[id] = MusicAlbumObject;
		}

		public int NextId()
		{
			return albumList.Count;
		}
    }
}