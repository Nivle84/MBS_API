using System;
using MBStest01.Models;
using MBSAPITest01.Controllers;
using MBS_API;

namespace API_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTesterClass.AddUser();
        }
    }

    public static class MyTesterClass
    {
        private static MBSContext _context = new MBSContext();
        
        //User thisUser = new User()
        //{
        //    UserEmail = "min@mail.dk",
        //    UserPassword = "kodeord"
        //};
        
        public static void AddUser()
        {
            var user = new User
            {
                UserEmail = "min@mail.dk",
                UserPassword = "kodeord"
            };

            //var day = new Day()
            //{
                
            //}

            _context.Add(user);
            Console.ReadKey();
        }
    }

}
