using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MBStest01.Models
{
    public class Note
    {
        //public int NoteID { get; set; }
        [Key, ForeignKey("Day")]
		public int DayID { get; set; }
        [Required]
		[ForeignKey("User")]
		public int UserID { get; set; }
        public string NoteString { get; set; }
		//[Required]
		public Day Day { get; set; }
		public User User { get; set; }
	}
}
