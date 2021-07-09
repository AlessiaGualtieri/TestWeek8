using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy
{
    public class Helper
    {

        public static int ReadInt(int min, int max)
        {
            int choice;
            bool success;
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out choice);
                if (!success || choice < min || choice > max)
                    Console.Write("Input not correct. Try again: ");
            } while (!success || choice < min || choice > max);

            return choice;
        }
    }
}
