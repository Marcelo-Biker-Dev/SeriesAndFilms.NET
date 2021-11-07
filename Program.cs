using System;
using SeriesAndFilms.NET.Entities;
using SeriesAndFilms.NET.Repositories;

namespace SeriesAndFilms.NET
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static MusicAlbumRepository albumRepository = new MusicAlbumRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

			while (userOption != "X")
			{
				switch (userOption)
				{
					case "1":
					    ListSeries();
						break;
					case "2":
						InsertSerie();
						break;
					case "3":
						InsertMusicAlbum();
						break;
					case "4":
						UpdateSerie();
						break;
					case "5":
						UpdateMusicAlbum();
						break;
					case "6":
						ExcludeSerie();
						break;
					case "7":
						ExcludeMusicAlbum();
						break;
					case "8":
						CheckSerie();
						break;
					case "9":
						CheckMusicAlbum();
						break;
					case "11":
					    ListMusicAlbuns();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(userOption), "An invalid option was entered. Please try again with the shown options" );
				}
				GetUserOption();
			}

            string GetUserOption()
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to your .NET Series and Music Albuns assistant!");
                Console.WriteLine("Let me know what you want to do:");
                Console.WriteLine();
                Console.WriteLine("1- List existent series and albuns");
                Console.WriteLine("11- List existent music albuns");
                Console.WriteLine("2- Insert new serie");
                Console.WriteLine("3- Insert new album");
                Console.WriteLine("4- Update series catalog");
                Console.WriteLine("5- Update music album catalog");
                Console.WriteLine("6- Exclude a serie");
                Console.WriteLine("7- Exclude an album");
                Console.WriteLine("8- Check a serie details");
                Console.WriteLine("9- Check an album details");
                Console.WriteLine("C- Wipe out screen");
                Console.WriteLine("X- Leave .NET Series and Music Albuns");
                Console.WriteLine();

                userOption = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return userOption;
            }

			Console.WriteLine("Looking forward to see you back again.");
        }

        private static void InsertSerie()
		{
			Console.WriteLine("Insert new serie");

			foreach (int i in Enum.GetValues(typeof(SerieGenre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(SerieGenre), i));
			}
			Console.Write("Choose a Genre from the list above: ");
			int genreInput = int.Parse(Console.ReadLine());

			Console.Write("Enter a title for the serie: ");
			string titleInput = Console.ReadLine();

			Console.Write("Enter the year the serie was released: ");
			int yearInput = int.Parse(Console.ReadLine());

			Console.Write("Enter a description for the serie: ");
			string descriptionInput = Console.ReadLine();

			Serie newSerie = new Serie(id: repository.NextId(),
										genre: (SerieGenre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			repository.Insert(newSerie);
		}

        private static void InsertMusicAlbum()
		{
			Console.WriteLine("Insert new music album");

			foreach (int i in Enum.GetValues(typeof(AlbumGenre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(AlbumGenre), i));
			}
			Console.Write("Choose a Genre from the list above: ");
			int genreInput = int.Parse(Console.ReadLine());

			Console.Write("Enter a title for the album: ");
			string titleInput = Console.ReadLine();

			Console.Write("Enter the year the album was released: ");
			int yearInput = int.Parse(Console.ReadLine());

			Console.Write("Enter a description for the album: ");
			string descriptionInput = Console.ReadLine();

			MusicAlbum newAlbum = new MusicAlbum(id: repository.NextId(),
										genre: (AlbumGenre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			albumRepository.Insert(newAlbum);
		}

        private static void ListSeries()
		{
			Console.WriteLine("\nSeries:");

			var serieList = repository.List();

			if (serieList.Count == 0)
			{
				Console.WriteLine("Sorry, but there is nothing here to show.");
				return;
			}

			foreach (var serie in serieList)
			{
                var excluded = serie.getExcluded();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.getId(), serie.getTitle(), (excluded ? "excluded" : ""));
			}
		}

        private static void ListMusicAlbuns()
		{
			Console.WriteLine("\nMusic Albuns:");

			var musicList = albumRepository.List();

			if (musicList.Count == 0)
			{
				Console.WriteLine("Sorry, but there is nothing here to show.");
				return;
			}

			foreach (var album in musicList)
			{
                var excluded = album.getExcluded();
                
				Console.WriteLine("#ID {0}: - {1} {2}", album.getId(), album.getTitle(), (excluded ? "excluded" : ""));
			}
		}

        private static void UpdateSerie()
		{
			Console.Write("Enter Serie Id: ");
			int indexSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(SerieGenre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(SerieGenre), i));
			}
			Console.Write("Choose a Genre: ");
			int genreInput = int.Parse(Console.ReadLine());

			Console.Write("Enter a title for the serie: ");
			string titleInput = Console.ReadLine();

			Console.Write("Enter the year the serie was released: ");
			int yearInput = int.Parse(Console.ReadLine());

			Console.Write("Enter a description for the serie: ");
			string descriptionInput = Console.ReadLine();

			Serie updateSerie = new Serie(id: indexSerie,
										genre: (SerieGenre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			repository.Update(indexSerie, updateSerie);
		}

        private static void UpdateMusicAlbum()
		{
			Console.Write("Enter Music Album Id: ");
			int indexSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(AlbumGenre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(AlbumGenre), i));
			}
			Console.Write("Choose a Genre: ");
			int genreInput = int.Parse(Console.ReadLine());

			Console.Write("Enter a title for the album: ");
			string titleInput = Console.ReadLine();

			Console.Write("Enter the year the album was released: ");
			int yearInput = int.Parse(Console.ReadLine());

			Console.Write("Enter a description for the album: ");
			string descriptionInput = Console.ReadLine();

			MusicAlbum updateAlbum = new MusicAlbum(id: indexSerie,
										genre: (AlbumGenre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			albumRepository.Update(indexSerie, updateAlbum);
		}

        private static void CheckSerie()
		{
			Console.Write("Enter Serie Id: ");
			int indexSerie = int.Parse(Console.ReadLine());

			var serie = repository.GetById(indexSerie);

			Console.WriteLine(serie);
		}

        private static void ExcludeSerie()
		{
			Console.Write("Enter Serie Id: ");
			int indexSerie = int.Parse(Console.ReadLine());

			repository.Exclude(indexSerie);
		}

        private static void CheckMusicAlbum()
		{
			Console.Write("Enter Music Album Id: ");
			int indexAlbum = int.Parse(Console.ReadLine());

			var album = albumRepository.GetById(indexAlbum);

			Console.WriteLine(album);
		}

        private static void ExcludeMusicAlbum()
		{
			Console.Write("Enter Music Album Id: ");
			int indexAlbum = int.Parse(Console.ReadLine());

			albumRepository.Exclude(indexAlbum);
		}
    }
}
