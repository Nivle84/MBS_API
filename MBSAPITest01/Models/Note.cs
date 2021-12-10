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
		public int UserID { get; set; }
        public string NoteString { get; set; }
		//[Required]
		public virtual Day Day { get; set; }
		public virtual User User { get; set; }
	}
}
