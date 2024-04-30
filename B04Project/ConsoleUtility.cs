
namespace B04Project
{
    internal class ConsoleUtility
    {
        public static void PrintGameHeader()
        {

        }

        internal static int PromptMenuChoice(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("올바른 입력이 아닙니다.");
                }
            }
        }

        public static void ShowTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        public static void PrintTextHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.WriteLine(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }
    }
}