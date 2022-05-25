using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    static class InputReader
    {
        static public void Display(this List<Student> s)
        {
            s.ForEach(x => Console.WriteLine(x));
        }
        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            int result = 0;
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            return result;
        }
        public static String ReadString(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return input;
        }
        public static DateTime ReadDate(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            DateTime result = new DateTime();
            while (!DateTime.TryParse(input, out result))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            return result;
        }
        public static float ReadFloat(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            float result = 0;
            while (!float.TryParse(input, out result))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            return result;
        }

        public static float ReadFloatInRange(string prompt, float min, float max)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            float result = 0;
            while (!float.TryParse(input, out result) || result < min || result > max)
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            return result;
        }
    }
}
