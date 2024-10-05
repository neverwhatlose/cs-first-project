﻿namespace ConsoleApp1
{
    public static class Program
    {
        public static void Main()
        {
            string path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("bin")) + "input.txt";
            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine();
                // 0 или 1: 0 - ошибки не было, 1 - была
                int exitCode = 0;
                string[] file = File.ReadAllLines(path);
                string checkedLine = "";

                int size = string.Join("", LineToArray(file[0])).Length;
                foreach (string line in file)
                {
                    checkedLine += string.Join("", LineToArray(line));
                    if (size != string.Join("", LineToArray(line)).Length)
                    {
                        exitCode = 1;
                    }
                }

                int[] input = LineToArray(checkedLine);
                if (exitCode == 0)
                {
                    Console.WriteLine(CountComposition(input));
                }

                Console.WriteLine("\nНажмите Q, чтобы завершить программу или любую другую кнопку для повторения");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Q);
        }

        /**
         * <summary>
         * Приводит строку из input.txt к массиву типа int,
         * исключая неверно введенные данные
         * </summary>
         * <param name="line">
         * Строка для приведения из input.txt
         * </param>
         * <returns>
         * Массив int[], содержащий отфильтрованный набор данных
         * </returns>
         */
        private static int[] LineToArray(string line)
        {
            // Отсеивание лишних элементов файла
            string checkedLine = "";
            foreach (char element in line.ToCharArray())
            {
                if (int.TryParse(element.ToString(), out int result))
                {
                    checkedLine += result;
                }
            }

            // Подготовка готового массива
            int[] returnArray = new int[checkedLine.ToCharArray().Length];
            char[] array = checkedLine.ToCharArray();
            for (int i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = array[i];
            }

            return returnArray;
        }

        private static int CountComposition(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
            int n = array.Length / 2;
            Console.WriteLine(n);
            int sum = 0;
            for (int i = 0; i < array.Length - n; i++)
            {
                sum += array[i] * array[i + n];
            }

            return sum;
        }
    }
}
