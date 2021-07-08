using FinalFantasy.BusinessLayer;
using System;

namespace FinalFantasy
{
    class Program
    {
        public static IBusinessLayer bl = new MainBusinessLayer();
        static void Main(string[] args)
        {
            //bl.Register("Alessia");
            //Console.WriteLine("Login avvenuto? " + bl.Login("Alessia"));
            //Console.WriteLine("Login avvenuto? " + bl.Login("Giulia"));
        }
    }
}
