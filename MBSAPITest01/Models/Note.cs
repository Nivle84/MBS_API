using System;
using System.Collections.Generic;
using System.Text;

namespace MBStest01.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public string NoteString { get; set; }
        public int DayID { get; set; }
        public Day Day { get; set; }
    }
}
