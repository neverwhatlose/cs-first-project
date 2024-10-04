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
                string[] file = File.ReadAllLines(path);
                string checkedLine = "";

                foreach (string line in file)
                {
                    checkedLine += string.Join(" ", LineToArray(line)) + " ";
                }

                Console.WriteLine(checkedLine);

                int[] input = LineToArray(checkedLine);

                for (int i = 0; i < input.Length; i++)
                {

                }

                double a = 4.0;
                Console.WriteLine(a/0 + " ");

                Console.WriteLine("\nНажмите Q, чтобы завершить программу или любую другую кнопку для повторения");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Q);
        }

        private static int[] LineToArray(string line)
        {
            int count = 0;
            string[] array = line.Split(" ");
            int[] returnArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (int.TryParse(array[i], out int num))
                {
                    returnArray[i] = num;
                    count += 1;
                }
            }

            return returnArray[..count];
        }

        // private static int CountComposition(int[] array)
        // {
        //     return 0;
        // }
    }
}
