using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MBStest01.Models
{
    public class Day
    {
        public int DayID { get; set; }
        //public int UserID { get; set; }
        [Required]
        public User User { get; set; }
        //public int MoodID { get; set; }
        [Required]
        public Mood Mood { get; set; }
        //public int InfluenceID { get; set; }
        [Required]
        public Influence Influence { get; set; }
        //public int NoteID { get; set; }
        public Note Note { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //public List<Mood> Moods { get; set; }
        //public List<Influence> Influences { get; set; }
        //public List<Note> Notes { get; set; }
    }
}
