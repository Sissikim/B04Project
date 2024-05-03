
using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace B04Project
{    
    public class GameManager
    {
        public PlayerManager player;
        public ItemManager itemManager;
        public BattleStart battleStart;
        public MonsterManager monsterManager;

        public GameManager()
        {
            InitializeGame(); //게임 초기설정
        }

        private void InitializeGame()
        {
            player = new PlayerManager(this);
            battleStart = new BattleStart(this);
            monsterManager = new MonsterManager(this);
            itemManager = new ItemManager(this); //아이템매니저 생성자
        }

        public void StartGame()
        {
            Console.Clear();
            ConsoleUtility.PrintGameHeader();
            //player.NameChoice();
            //player.JobChoice();
            //Console.WriteLine("진행하시려면 아무키나 누르세요");
            //Console.ReadKey(); //아무키나 누르세요 같은거임.
            itemManager.MyInventory();
            MainMenu();
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("이제 전투를 시작할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("1. 상태 보기\n2. 전투 시작\n3. 인벤토리\n4. 상점\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.WriteLine($"player.statusList[0].TemAtk = {player.statusList[0].TemAtk}");
                Console.WriteLine($"itemManager.myList.Count = {itemManager.myList.Count}");
                Console.Write(">>");

                int choice = ConsoleUtility.PromptMenuChoice(1, 4);
                switch (choice)
                {
                    case 1:
                        Status();
                        break;
                    case 2:
                        battleStart.Battle();
                        break;
                    case 3:
                        itemManager.SetMyInventory();
                        break;
                    case 4:
                        itemManager.Shop();
                        break;
                }
            }
        }
        public void Status() 
        {
            player.StatusMenu();
            switch (ConsoleUtility.PromptMenuChoice(0, 0))
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
