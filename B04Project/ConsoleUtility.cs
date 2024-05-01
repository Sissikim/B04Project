
namespace B04Project
{
    internal class ConsoleUtility
    {
        public static void PrintGameHeader() //콘솔 헤더(타이틀)
        {
            //TODO: 게임 헤더 콘솔 꾸미기
        }

        internal static int PromptMenuChoice(int min, int max) //숫자 최소치, 최대치를 정해 사용하면 선택지 번호별로 프로그램cs에서 switch case문 사용 가능
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

        public static void ShowTitle(string title) //각 장면 타이틀 강조
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        public static void PrintTextHighlights(string s1, string s2, string s3 = "") //텍스트 하이라이트
        {
            Console.Write(s1);
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.WriteLine(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }
    }
}