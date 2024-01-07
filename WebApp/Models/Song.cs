﻿using System.ComponentModel.DataAnnotations;

namespace ProiectMPD.Models
{
    public class Song
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [RegularExpression(@"^([0-5]?\d):([0-5]?\d):([0-5]?\d)$", ErrorMessage = "Enter a valid Length. Format: hh:mm:ss")]
        public TimeSpan Length { get; set; }
        public int? ReleaseID { get; set; }
        public Release? Release { get; set; }
    }
}
