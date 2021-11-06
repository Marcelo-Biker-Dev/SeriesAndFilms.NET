using System;
using SeriesAndFilms.NET.Entities;
using SeriesAndFilms.NET.Repositories;

namespace SeriesAndFilms.NET
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
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
						UpdateSerie();
						break;
					case "4":
						ExcludeSerie();
						break;
					case "5":
						CheckSerie();
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
                Console.WriteLine("Welcome to your .NET Series and Films assistant!");
                Console.WriteLine("Let me know what you want to do:");
                Console.WriteLine();
                Console.WriteLine("1- List existent series");
                Console.WriteLine("2- Insert new serie");
                Console.WriteLine("3- Update series catalog");
                Console.WriteLine("4- Exclude a serie");
                Console.WriteLine("5- Check a serie details");
                Console.WriteLine("C- Wipe out screen");
                Console.WriteLine("X- Leave .NET Series and Films");
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

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
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
										genre: (Genre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			repository.Insert(newSerie);
		}
        private static void ListSeries()
		{
			Console.WriteLine("List series");

			var list = repository.List();

			if (list.Count == 0)
			{
				Console.WriteLine("Sorry, but there is nothing here to show.");
				return;
			}

			foreach (var serie in list)
			{
                var excluded = serie.getExcluded();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.getId(), serie.getTitle(), (excluded ? "excluded" : ""));
			}
		}

        private static void UpdateSerie()
		{
			Console.Write("Enter Serie Id: ");
			int indexSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
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
										genre: (Genre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			repository.Update(indexSerie, updateSerie);
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
    }
}
