using System;
using System.Collections.Generic;
using System.Text;

namespace MockUserInput
{
    public class ActualKeyboardInput : IUserKeyboardInput
    {
        public double getDoubleValue(string prompt)
        {
            double number;
            bool result;
            do
            {
                Console.Write(prompt);
                var V = readLn();
                result = Double.TryParse(V, out number);
                if (!result)
                {
                    Console.WriteLine("Invalid number, try again ");
                }
            } while (!result);
            return number;
        }

        public int getIntValue(string prompt)
        {
            int number;
            bool result;
            do
            {
                Console.Write(prompt);
                var V = readLn();
                result = int.TryParse(V, out number);
                if (!result)
                {
                    Console.WriteLine("Invalid number, try again ");
                }
            } while (!result);
            return number;
        }

        public string read(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public char readKey()
        {
            var ch = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return ch;
        }

        public string readLn()
        {
            return Console.ReadLine();
        }

        public string readLn(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();

        }
    }
}


