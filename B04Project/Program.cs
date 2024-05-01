
using System.Security.Cryptography.X509Certificates;

namespace B04Project
{

    public class GameManager
    {
        private Player player;
        static ItemManager itemManager;
        static BattleStart battleStart;

        public GameManager()
        {
            InitializeGame(); //게임 초기설정
        }

        private void InitializeGame()
        {
            player = new Player("B04", "전사", 01, 10, 5, 100, 2000); //상태창에 띄워질 초기수치            
            itemManager= new ItemManager(); //아이템매니저 생성자
            battleStart= new BattleStart();

        }

        public void StartGame()
        {
            Console.Clear();
            ConsoleUtility.PrintGameHeader();
            MainMenu();            
        }

        public void MainMenu()
        {
            itemManager.MyInventory();
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기\n2. 전투 시작\n3. 인벤토리\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int choice = ConsoleUtility.PromptMenuChoice(1, 3);
            switch (choice)
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    battleStart.Battle();
                    break;
                case 3:
                    Inventory();
                    break;
            }            
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
        public void Inventory()
        {
            Console.Clear();
            ConsoleUtility.ShowTitle("■ 인벤토리 ■");
            Console.WriteLine("");
            itemManager.SetMyInventory();
            Console.WriteLine("");
            Console.WriteLine("1. 착용하기\n0. 도망치기");

            switch (ConsoleUtility.PromptMenuChoice(0, 1))
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    Console.Clear();
                    itemManager.SetEquipmenty();
                    itemManager.MyInventory();//장비장착으로 아이템정보값 변경.>> 다시호출 아이템리스트 갱신
                    // 아이템으로 인한 플레이어 능력치 또한 변경되니 요기서 호출해서 갱신
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
