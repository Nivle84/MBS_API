using System;
using MBStest01.Models;
using MBSAPITest01.Controllers;
using MBS_API;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace API_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyTesterClass.AddUser();
            //MyTesterClass.BuildLists();
            MyTesterClass tester = new MyTesterClass();

            
        }
    }

    public class MyTesterClass
    {
        private static MBSContext _context = new MBSContext();

        public static ICollection<Influence> _Influences;// = (ICollection<Influence>)_context.Influences;
        public static ICollection<Mood> _Moods;// = (ICollection<Mood>)_context.Moods;

        //public User _user = _context.FindAsync<User>(3).Result;
        //public Influence _influence = _Influences.



		public MyTesterClass()
		{
            _Influences = (ICollection<Influence>)_context.Influences;
            _Moods = (ICollection<Mood>)_context.Moods;
            //_user = _context.FindAsync<User>(3).Result;
        }

  //      public void BuildLists()
		//{
  //          _Influences = (ICollection<Influence>)_context.Influences;
  //          _Moods = (ICollection<Mood>)_context.Moods; 
  //          _user = _context.FindAsync<User>(3).Result;
		//}
        public static void AddUser()
        {
            var user = new User
            {
                UserEmail = "min@mail.dk",
                UserPassword = "kodeord"
            };

            _context.Add(user);
            Console.ReadKey();
        }
    }

}
