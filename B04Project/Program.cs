
using System.Security.Cryptography.X509Certificates;

namespace B04Project
{

    public class GameManager
    {
        private Player player;
        public GameManager()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            player = new Player("B04", "전사", 01, 10, 5, 100, 2000);
        }

        public void StartGame()
        {
            Console.Clear();
            ConsoleUtility.PrintGameHeader();
            MainMenu();
        }

        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기\n2. 전투 시작\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int choice = ConsoleUtility.PromptMenuChoice(1, 2);
            switch (choice)
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    Battle();
                    break;
            }
            MainMenu();
        }

        private void StatusMenu()
        {
            Console.Clear();
            ConsoleUtility.ShowTitle("■ 상태보기 ■");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");

            Console.WriteLine($"Lv. {player.Lv}");
            Console.WriteLine($"Chad ( {player.Chad} )");
            Console.WriteLine($"공격력 : {player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체  력 : {player.Hp}");

            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine("");

            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            switch (ConsoleUtility.PromptMenuChoice (0, 0))
            {
                case 0:
                    MainMenu();
                    break;
            }
        }

        private void Battle()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.StartGame();
        }
    }
}
