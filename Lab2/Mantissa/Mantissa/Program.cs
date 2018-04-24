using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arithmetic_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int mantissaMultiplicand, mantissaMultiplier;
            int znakMultiplicand, znakMultiplier;
            int expMultiplicand, expMultiplier;
            Console.WriteLine("insert Multipclicand");
            byte[] multiplicandBit = BitConverter.GetBytes(float.Parse(Console.ReadLine()));
            int resMultiplicand = BitConverter.ToInt32(multiplicandBit, 0);
            const int bias = 127;
            znakMultiplicand = resMultiplicand & Convert.ToInt32("10000000000000000000000000000000", 2);//читає перший символ
            expMultiplicand = resMultiplicand & Convert.ToInt32("01111111100000000000000000000000", 2);
            expMultiplicand >>= 23;
            mantissaMultiplicand = resMultiplicand & Convert.ToInt32("00000000011111111111111111111111", 2) | Convert.ToInt32("00000000100000000000000000000000", 2);
            Console.WriteLine(" znak = " + Convert.ToString(znakMultiplicand, 2) + " e = " + Convert.ToString(expMultiplicand, 2) + " Mantissa = " + Convert.ToString(mantissaMultiplicand, 2));
            Console.WriteLine("insert Multiplier");
            byte[] multiplierBit = BitConverter.GetBytes(float.Parse(Console.ReadLine()));
            int resMultiplier = BitConverter.ToInt32(multiplierBit, 0);
            znakMultiplier = resMultiplier & Convert.ToInt32("10000000000000000000000000000000", 2);
            expMultiplier = resMultiplier & Convert.ToInt32("01111111100000000000000000000000", 2);
            expMultiplier >>= 23;
            mantissaMultiplier = resMultiplier & Convert.ToInt32("00000000011111111111111111111111", 2) | Convert.ToInt32("00000000100000000000000000000000", 2);
            Console.WriteLine("znak = " + Convert.ToString(znakMultiplier, 2) + " e = " + Convert.ToString(expMultiplier, 2) + " Mantissa = " + Convert.ToString(mantissaMultiplier, 2));
            int exponent = expMultiplicand + expMultiplier - bias;
            int significand = znakMultiplicand ^ znakMultiplier;
            long mantisaLong = ShiftRight(mantissaMultiplicand, mantissaMultiplier);
            int mantisa = 0;
            if ((mantisaLong & 0x800000000000) == 0x800000000000)/*проверка битов*/
            {
                Console.WriteLine("Exponent = " + exponent + " +1");
                exponent++;
            }
            else
                mantisaLong <<= 1;
            for (int i = 0; i < 24; i++) /*результат мантисы*/
            {
                if ((mantisaLong & 0x1000000) == 0x1000000)
                {
                    mantisa |= 0x800000;
                }
                if (i == 23)
                    break;
                mantisa >>= 1;
                mantisaLong >>= 1;
            }
            mantisa &= ~(1 << 23);/*сброс уявной единицы*/
            Console.WriteLine("result");
            Console.WriteLine(Convert.ToString(significand, 2) + " " + Convert.ToString(exponent, 2) + " " + Convert.ToString(mantisa, 2));
            int res = significand | (exponent << 23) | mantisa;
            byte[] b = BitConverter.GetBytes(res);
            Console.WriteLine(BitConverter.ToSingle(b, 0));
            Console.ReadKey();
        }
        public static long ShiftRight(int multiplicand, int multiplier)
        {
            bool isMultiplierNegative = multiplier < 0;
            if (isMultiplierNegative)
                multiplier = ~multiplier + 1;
            long shiftedMultiplicand = multiplicand;
            long product = 0;
            shiftedMultiplicand <<= 32;
            for (int i = 0; i < 32; i++)
            {
                if ((multiplier & 1) == 1)
                    product += shiftedMultiplicand;
                product >>= 1;
                multiplier >>= 1;
            }
            if (isMultiplierNegative)
                product = ~product + 1;
            return product;
        }

    }
}