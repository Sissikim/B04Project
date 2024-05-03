
using System.Security.Cryptography.X509Certificates;
using B04Project;

namespace B04Project
{

    public class GameManager
    {
        private Player player;
        MonsterManager monsterManager;
        BattleStart BattleStart;

        public GameManager()
        {
            InitializeGame(); //게임 초기설정
        }

        private void InitializeGame()
        {
            BattleStart = new BattleStart();
        }

        public void StartGame()
        {
            Console.Clear();
            ConsoleUtility.PrintGameHeader();
            StartScene();
        }

        public void StartScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이름을 입력하세요");
            Console.Write(">>");
            string Playername = Console.ReadLine();

            if (!string.IsNullOrEmpty(Playername))
            {
                player = new Player(Playername, "전사", 1, 10, 5, 100, 2000);
                Console.WriteLine($"'{Playername}' 정말 이 이름으로 하시겠습니까?");
                Console.WriteLine("1. 예    2. 아니오");
                Console.Write(">>");
                switch (ConsoleUtility.PromptMenuChoice(1, 2))
                {
                    case 1:
                        player = new Player(Playername, player.Chad, player.Lv, player.Atk, player.Def, player.Hp, player.Gold);
                        MainMenu();
                        break;
                    case 2:
                        StartScene();
                        break;
                }
            
            } //파라미터로 게임매니저에 넘기기
            else
            {
                Console.WriteLine("이름을 입력해주세요.");
                StartScene();
            }

        }

        public void MainMenu()
        {

            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기\n2. 전투 시작\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int choice = ConsoleUtility.PromptMenuChoice(1, 2);
            switch (choice)
            {
                case 1:
                    StatusMenu(player);
                    break;
                case 2:
                    BattleStart.Battle();
                    break;
            }
            MainMenu();
        }

        private void StatusMenu(Player player)
        {
            Console.Clear();
            ConsoleUtility.ShowTitle("■ 상태보기 ■");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.Write($"{ player.Name }");
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
