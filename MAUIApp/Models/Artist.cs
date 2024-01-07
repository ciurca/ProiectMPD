using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirthApp.Models
{
    public class Artist
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }

        [OneToMany]
        public List<Release>? Releases { get; set; }
    }
}
