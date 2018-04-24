using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("dividend ");
            Int32 dividend = Int32.Parse(Console.ReadLine());
            string bsdividend = ToBinary(dividend);
            Console.WriteLine("divisor ");
            Int32 divisor = Int32.Parse(Console.ReadLine());
            string bsdivisor = ToBinary(divisor);
            string quotient = "";
            if (dividend < divisor)
            {
                Console.WriteLine("Quotient=0     Remainder=" + dividend);
            }
            else
            {
                int i = 0;
                string c = bsdividend;
                do
                {
                    try
                    {
                        c = bsdividend.Remove(i);
                    }
                    catch (Exception e) { c = bsdividend; }
                    if (BinToInt(c) < divisor)
                    {
                        quotient = quotient + "0";
                    }
                    else
                    {
                        quotient = quotient + "1";
                        bsdividend = ToBinary(BinToInt(bsdividend) - (BinToInt(bsdivisor) << 16 - i));
                    }
                    i++;
                }
                while (i <= 16);
                Console.WriteLine("Quotient = " + BinToInt(quotient) + "Remainder" + BinToInt(bsdividend));
            }
            Console.ReadKey();
        }

        static int BinToInt(string binaryNumber)
        {
            int multiplier = 1;
            int converted = 0;
            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                int t = System.Convert.ToInt16(binaryNumber[i].ToString());
                converted = converted + (t * multiplier);
                multiplier = multiplier * 2;
            }
            return converted;
        }

        static string ToBinary(int Decimal)
        {
            int BinaryHolder;
            string BinaryResult = "";
            while (Decimal > 0)
            {
                BinaryHolder = Decimal % 2;
                BinaryResult += BinaryHolder;
                Decimal = Decimal / 2;
            }
            char[] BinaryArray = BinaryResult.ToCharArray();
            Array.Reverse(BinaryArray);
            BinaryResult = new string(BinaryArray);
            do
            {
                BinaryResult = BinaryResult.Insert(0, "0");
            }
            while (BinaryResult.Length < 16);
            return BinaryResult;
        }
    }
}
