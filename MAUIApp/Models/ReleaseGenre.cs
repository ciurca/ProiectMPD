using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MirthApp.Models
{
    public class ReleaseGenre
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Release))]
        public int ReleaseID { get; set; }
        public int GenreID { get; set; }
    }
}
