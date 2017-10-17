using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuessItApi.Models
{
    public class HallOfFame
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int NumberOfAttempts { get; set; }
        public DateTime PlayTime { get; set; }
    }
}