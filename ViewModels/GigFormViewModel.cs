using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public String Venue { get; set; }

        [Required]
        [FutureDate]
        public String Date { get; set; }

        [Required]
        [ValidTime]
        public String Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Heading { get; set; }

        public string Action => (Id != 0 ? "Edit" : "Create");

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
    }
}