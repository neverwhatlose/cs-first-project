using System.Linq.Expressions;

namespace ConsoleApp1;
    public static class Program
    {
        public static void Main()
        {
            string path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("bin"));
            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine();
                
                try
                {
                    string[] file = File.ReadAllLines(path + "input.txt");
                    
                    int[] firstArray = LineToArray(file[0]);
                    int[] secondArray = LineToArray(file[1]);
                    
                    try
                    {
                        string result = CountComposition(firstArray, secondArray).ToString();
                        WriteResult(path, result);
                    }
                    catch (DifferentLengthException ex)
                    {
                        Console.WriteLine(ex.GetMessage());
                    }
                    Console.WriteLine("Result has been succesfully written to output.txt");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("input.txt is missing!");
                }

                Console.WriteLine("\nPress Q to end the program or any other button to repeat");
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
            foreach (string element in line.Split(" "))
            {
                if (int.TryParse(element, out int result))
                {
                    checkedLine += result + " ";
                }
            }

            // Подготовка готового массива
            string[] array = checkedLine.TrimEnd().Split(" ");
            int[] returnArray = new int[array.Length];
            

            for (int i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = int.Parse(array[i]);
            }

            return returnArray;
        }

        private static void WriteResult(string path, string result)
        {
            File.WriteAllText(path + "output.txt", result);
        }

        private static int CountComposition(int[] firstArr, int[] secondArr)
        {
            int sum = 0;
            if (firstArr.Length != secondArr.Length)
                throw new DifferentLengthException("Provided arrays have different length");
            for (int i = 0; i < firstArr.Length; i++)
            {
                sum += firstArr[i] * secondArr[i];
            }

            return sum;
        }
        
        private class DifferentLengthException(string message) : Exception
        {
            public string GetMessage()
            {
                return message;
            }
        }
    }
