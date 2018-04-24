using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string BinaryHolder = "0";
            Console.WriteLine("multiplicand");
            Int16 x = Int16.Parse(Console.ReadLine());
            string Multiplicand = ToBinary(x);
            Console.WriteLine("multiplier");
            Int16 y = Int16.Parse(Console.ReadLine());
            string Multiplier = ToBinary(y);
            string AbsoluteResult = "00000000000000000000000000000000";


            for (int i = 0; i < 16; i++)
            {
                if (Multiplier.Substring(Multiplier.Length - i - 1, 1) == "0")
                {
                    AbsoluteResult = AbsoluteResult.Remove(AbsoluteResult.Length - 1, 1);
                    AbsoluteResult = AbsoluteResult.Insert(0, "0");
                }
                else
                {
                    for (int j = 15; j >= 0; j--)
                    {
                        if (AbsoluteResult.Substring(j, 1) == "0")
                        {
                            AbsoluteResult = AbsoluteResult.Remove(j, 1);
                            if (Multiplicand.Substring(j, 1) == "0")
                            {
                                if (BinaryHolder == "0")
                                {
                                    AbsoluteResult = AbsoluteResult.Insert(j, "0");
                                }
                                else
                                {
                                    AbsoluteResult = AbsoluteResult.Insert(j, "1");
                                    BinaryHolder = "0";
                                }
                            }
                            else
                            {
                                if (BinaryHolder == "0")
                                {
                                    AbsoluteResult = AbsoluteResult.Insert(j, "1");
                                }
                                else
                                {
                                    AbsoluteResult = AbsoluteResult.Insert(j, "0");
                                    BinaryHolder = "1";
                                }
                            }
                        }
                        else
                        {
                            AbsoluteResult = AbsoluteResult.Remove(j, 1);
                            if (Multiplicand.Substring(j, 1) == "0")
                            {
                                if (BinaryHolder == "0")
                                {
                                    AbsoluteResult = AbsoluteResult.Insert(j, "1");
                                }
                                else
                                {
                                    AbsoluteResult = AbsoluteResult.Insert(j, "0");
                                    BinaryHolder = "1";
                                }
                            }
                            else
                            {
                                if (BinaryHolder == "0")
                                {
                                    AbsoluteResult = AbsoluteResult.Insert(j, "0");
                                    BinaryHolder = "1";
                                }
                                else
                                {
                                    AbsoluteResult = AbsoluteResult.Insert(j, "1");
                                    BinaryHolder = "1";
                                }
                            }
                        }
                    }
                    AbsoluteResult = AbsoluteResult = AbsoluteResult.Remove(AbsoluteResult.Length - 1, 1);
                    AbsoluteResult = AbsoluteResult.Insert(0, "0");
                }
            }
            Console.WriteLine("результат в двійковій формі" + "\n" + AbsoluteResult + "\n" + "правильний результат=" + (x * y) + "\n" + "переведений результат=" + BinToInt(AbsoluteResult));
            Console.ReadLine();

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
            char [] BinaryArray = BinaryResult.ToCharArray();
            Array.Reverse(BinaryArray);
            BinaryResult = new string(BinaryArray);
            do
            {
                BinaryResult = BinaryResult.Insert(0, "0");
            }
            while (BinaryResult.Length < 16);
            Console.WriteLine(BinaryResult);
            return BinaryResult;
        }
    }
}
