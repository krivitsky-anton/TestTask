using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusStart_TestTask
{
    class Program
    {

        static void MergeSortAndWriteInt(string output, params string[] input)
        {

            string[] firstData;
            for (int i = 0; i < input.Length - 1; i++)
            {
                firstData = File.ReadAllLines(input[i]);    // Слияние первых двух файлов
                if (i != 0)
                {
                    firstData = File.ReadAllLines(output);  // Слияние остальных файлов
                    File.Delete(output);

                }

                int firstDataCount = 0; // Номер элемента в 1 массиве
                foreach (var secondData in File.ReadLines(input[i + 1]))    // Данные со второго файла
                {
                    if (firstDataCount < firstData.Length - 1) //перебираем элементы 1 массива
                    {
                        while (int.Parse(firstData[firstDataCount]) < int.Parse(secondData))
                        {
                            File.AppendAllText(output, firstData[firstDataCount] + Environment.NewLine);
                            if (firstDataCount < firstData.Length - 1)
                                firstDataCount++;
                            else break;
                        }
                    }
                    File.AppendAllText(output, secondData + Environment.NewLine);
                }
                for (int j = firstDataCount; j < firstData.Length - 1; j++)
                    File.AppendAllText(output, firstData[j] + Environment.NewLine);
            }
        }



        static void Main(string[] args)
        {

            File.Delete("out.txt");
            MergeSortAndWriteInt("out.txt", "in1.txt", "in2.txt", "in3.txt");


        }
    }
}
