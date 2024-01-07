using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MirthApp.Models
{
    public class Release
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Language { get; set; }
        public string? Artwork { get; set; }
        public string? Label { get; set; }
        public int? Year { get; set; }

        // Artist
        [ForeignKey(typeof(Artist))]
        public int? ArtistId { get; set; }

        [ManyToOne]
        public Artist? SelectedArtist { get; set;}
    }
}
