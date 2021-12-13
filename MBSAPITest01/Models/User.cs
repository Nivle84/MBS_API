using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MBStest01.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; }
		public List<Note> Notes { get; set; }
	}
}
