using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var di = new Dictionary<char, double>();
            int sum = 0;
            foreach (char c in File.ReadAllText("C:/Users/Zver/Desktop/1.txt"))
                if (di.ContainsKey(c))
                {
                    di[c]++;
                    sum++;
                }
                else
                {
                    di.Add(c, 1);
                    sum++;
                }
            foreach (var kp in di)
            //if (kp.Key != Convert.ToChar(13) & kp.Key != Convert.ToChar(10))
            {
                Console.WriteLine("Символ " + kp.Key + " зустрічається " +kp.Value +"/"+ sum + " часто");

            }
            double H = 0;
            int m = 0;
            foreach (var kp in di)
            {
                //H = Math.Log(sum / kp.Value, 2);
                
                H = H + (double)(kp.Value / sum) * Math.Log(2 , sum / kp.Value);
                m++;
            }
            FileInfo file = new FileInfo("C:/Users/Zver/Desktop/1.txt");
            Console.WriteLine("H=" + H + "\n" + "m=" + m + "\n" + "full information=" + sum * H+"filesize="+ file.Length);
            Console.ReadKey();
        }
    }
}
