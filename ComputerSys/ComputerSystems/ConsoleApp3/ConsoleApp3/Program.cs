using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] file = File.ReadAllBytes("C:/Users/Zver/Desktop/1.txt");



            int length, Transformedrrforbase64length;
            int blockCount;
            int padding;
            char[] Base64 = new char[64] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };
            length = file.Length;

            if ((length % 3) == 0)
            {
                padding = 0;
                blockCount = length / 3;//в случае кратности переносим ничего не делаем и считаем колово блоков которіе из 8 битных должны будут стать 6 битными
            }
            else
            {
                padding = 3 - (length % 3);
                blockCount = (length + padding) / 3;
            }

            Transformedrrforbase64length = length + padding;

            byte[] convertedto64file;
            convertedto64file = new byte[Transformedrrforbase64length];

            for (int x = 0; x < Transformedrrforbase64length; x++)
            {
                if (x < length)
                {
                    convertedto64file[x] = file[x];
                }
                else
                {
                    convertedto64file[x] = 0;
                }
            }

            byte b1, b2, b3;
            byte temp, temp1, temp2, temp3, temp4;
            byte[] buffer = new byte[blockCount * 4];
            char[] file64 = new char[blockCount * 4];

            for (int x = 0; x < blockCount; x++)
            {
                b1 = convertedto64file[x * 3];//беремо значення
                b2 = convertedto64file[x * 3 + 1];
                b3 = convertedto64file[x * 3 + 2];

                temp1 = (byte)((b1 & 252) >> 2);//зсовуэмо біти

                temp = (byte)((b1 & 3) << 4);
                temp2 = (byte)((b2 & 240) >> 4);
                temp2 += temp;

                temp = (byte)((b2 & 15) << 2);
                temp3 = (byte)((b3 & 192) >> 6);
                temp3 += temp;

                temp4 = (byte)(b3 & 63);

                buffer[x * 4] = temp1;//заповнюємо основу нашого файлу
                buffer[x * 4 + 1] = temp2;
                buffer[x * 4 + 2] = temp3;
                buffer[x * 4 + 3] = temp4;

            }

            for (int x = 0; x < blockCount * 4; x++)//трансформуємо
            {
                if ((buffer[x] >= 0) && (buffer[x] <= 63))
                {
                    file64[x] = Base64[buffer[x]];
                }
                else
                {
                    file64[x] = ' ';
                }

            }

            switch (padding)//вставляем нульові байты
            {
                case 0:
                    break;
                case 1:
                    file64[blockCount * 4 - 1] = '=';
                    break;
                case 2:
                    file64[blockCount * 4 - 1] = '=';
                    file64[blockCount * 4 - 2] = '=';
                    break;
                default:
                    break;
            }
            string s = new string(file64);
            File.WriteAllText("C:/Users/Zver/Desktop/5Base64.txt", s);
        }
    }
}

