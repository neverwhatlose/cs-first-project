namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            //string path = "/Users/mac/projects/c sharp projects/ConsoleApp1/ConsoleApp1/input.txt";
            string path = "~/input.txt";
            string[] read = File.ReadAllLines(path);
            foreach (string s in read)
            {

            }
        }
    }
}
