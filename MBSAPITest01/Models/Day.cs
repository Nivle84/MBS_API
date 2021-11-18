using System;
using System.Collections.Generic;
using System.Text;

namespace MBStest01.Models
{
    public class Day
    {
        public int DayID { get; set; }
        //public int UserID { get; set; }
        public User User { get; set; }
        //public int MoodID { get; set; }
        public Mood Mood { get; set; }
        //public int InfluenceID { get; set; }
        public Influence Influence { get; set; }
        //public int NoteID { get; set; }
        public Note Note { get; set; }
        public DateTime Date { get; set; }
    }
}
