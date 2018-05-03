using System;

namespace Roman_Numeral_Msft
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Converting LXXXIX to its numeric value");
            RomanNumeralInterpreter("LXXXIX");
            Console.WriteLine();

            Console.WriteLine("Converting XCVIII to its numeric value");
            RomanNumeralInterpreter("XCVIII");
            Console.WriteLine();

            Console.WriteLine("Converting XCIX to its numeric value");
            RomanNumeralInterpreter("XCIX");
            Console.WriteLine();

            Console.WriteLine("Converting XCVIII to its numeric value");
            RomanNumeralInterpreter("XXX");
            Console.ReadKey();

        }

        static int GetValue(char c)
        {
            if (c == 'I') return 1; //int I = 1
            if (c == 'V') return 5;  //int V = 5
            if (c == 'X') return 10; //int X = 10
            if (c == 'L') return 50; //int L = 50
            if (c == 'C') return 100; //int C = 100
            if (c == 'D') return 500; //int D = 500
            if (c == 'M') return 1000; //int M = 1000
            return -1;
        }

        //given a string containing a Roman numeral, return the integer value
        static int RomanNumeralInterpreter(string romans)
        {
            //declaring empty variable to sum up the value of Roman numerals
            int sum = 0;

            //if I'm given an empty string
            if (romans == " ") 
            {
                //return 0
                Console.WriteLine("Please enter a valid combination of Roman numeral characters");
                return 0;
            }

            //scan from right to left (starting at the end)
            for (int i = romans.Length-1; i >= 0; i--)
            {
                Console.WriteLine("The sum is {0}.", sum);
                //converting current value to numeric value
                int num1 = GetValue(romans[i]);

                //attempting to prevent out of bound exceptions when comparing value at 1 with value at i - 1
                //this if statement addresses situations where the first letter has a value 
                if (i - 1 >= 0)
                {
                    //converting left Roman numeral to numeric value
                    int num2 = GetValue(romans[i-1]);
                    //if current value is less than or equal to current value
                    if (num1 <= num2)
                    {
                        sum += num1;
                    }
                    //if left value is less than value at i, subtract left value from value at i
                    else
                    {
                        sum += num1 - num2;
                        i--;
                    } 
                }
                //the following is for situations where the first/leftmost letter has a value greater than or equal to the letter directly to the right
                else
                {
                    //looking back to the value to the right of i
                    if (num1 < GetValue(romans[i+1]))
                    {
                        sum -= num1;
                    }
                    else
                    {
                        sum += num1;

                    }
                }
            }
            //output total value
            Console.WriteLine("{0} is the total.", sum);
            return sum;

        }
    }
}
