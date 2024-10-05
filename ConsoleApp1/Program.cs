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
                // 0 или 1: 0 - ошибки не было, 1 - была
                string[] file = File.ReadAllLines(path + "input.txt");

                int[] firstArray = LineToArray(file[0]);
                int[] secondArray = LineToArray(file[1]);

                Console.WriteLine(string.Join(" ", firstArray));
                Console.WriteLine(string.Join(" ", secondArray));
                
                
                try
                {
                    string result = CountComposition(firstArray, secondArray).ToString();
                    WriteResult(path, result);
                }
                catch (DifferentLengthException ex)
                {
                    Console.WriteLine(ex.GetMessage());
                    
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
            foreach (char element in line)
            {
                if (int.TryParse(element.ToString(), out int result))
                {
                    checkedLine += result;
                }
            }

            // Подготовка готового массива
            int[] returnArray = new int[checkedLine.Length];
            char[] array = checkedLine.ToCharArray();

            for (int i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = int.Parse(array[i].ToString());
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
