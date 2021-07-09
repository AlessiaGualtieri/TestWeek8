using FinalFantasy.BusinessLayer;
using System;

namespace FinalFantasy
{
    class Program
    {
        public static IBusinessLayer bl = new MainBusinessLayer();
        static void Main(string[] args)
        {
            Gaming.LoginMenu();
        }
    }
}
