using System.Xml.Schema;

namespace ConsoleApp1
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
                string[] file = File.ReadAllLines(path);

                int[] firstArray = LineToArray(file[0]);
                int[] secondArray = LineToArray(file[1]);

                Console.WriteLine(string.Join(" ", firstArray));
                Console.WriteLine(string.Join(" ", secondArray));

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
            foreach (char element in line)
            {
                Console.WriteLine("lta: " + element);
                if (int.TryParse(element.ToString(), out int result))
                {
                    Console.WriteLine($"parsed element: {element}");
                    checkedLine += result;
                    Console.WriteLine($"checkedLine: {checkedLine}");
                }
            }

            Console.WriteLine("---");

            // Подготовка готового массива
            int[] returnArray = new int[checkedLine.Length];
            char[] array = checkedLine.ToCharArray();

            Console.WriteLine($"line: {checkedLine}\nreturnArray: {string.Join(" ", returnArray)}\narray: {string.Join(" ", array)}");
            for (int i = 0; i < returnArray.Length; i++)
            {
                Console.WriteLine($"returnArray[i]: {returnArray[i]}\narray[i]: {array[i]}");
                returnArray[i] = int.Parse(array[i].ToString());
                Console.WriteLine($"returnArray[i] (changed): {returnArray[i]}");
            }

            Console.WriteLine($"returnArray: {string.Join(" ", returnArray)}");
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
