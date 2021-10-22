using System;
using SeriesAndFilms.NET.Enum;

namespace SeriesAndFilms.NET.Entities
{
    public class Serie : EntityBase
    {
        // Atributos
		private Genre Genre { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Excluded {get; set;}

        // Métodos
		public Serie(int id, Genre genre, string title, string description, int year)
		{
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.Year = year;
            this.Excluded = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string compiled = "";
            compiled += "Genre: " + this.Genre + Environment.NewLine;
            compiled += "Title: " + this.Title + Environment.NewLine;
            compiled += "Description: " + this.Description + Environment.NewLine;
            compiled += "Year of release: " + this.Year + Environment.NewLine;
            compiled += "Excluded: " + this.Excluded;
			return compiled;
		}

        public string returnTitle()
		{
			return this.Title;
		}

		public int returnId()
		{
			return this.Id;
		}
        public bool returnExcluded()
		{
			return this.Excluded;
		}
        public void Exclude() {
            this.Excluded = true;
        }    
    }
}