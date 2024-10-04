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

                Console.WriteLine("\nНажмите Q, чтобы завершить программу или любую другую кнопку для повторения");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Q);
        }

        private static int[] LineToArray(string line)
        {
            // Отсеивание лишних элементов файла
            string checkedLine = "";
            foreach (string element in line.Split(" "))
            {
                if (int.TryParse(element, out int result))
                {
                    checkedLine += result;
                }
            }

            // Подготовка готового массива
            int[] returnArray = new int[checkedLine.Split(" ").Length];
            string[] array = checkedLine.Split("");
            for (int i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = int.Parse(array[i]);
            }

            return returnArray;
        }

        // private static int CountComposition(int[] array)
        // {
        //     return 0;
        // }
    }
}
