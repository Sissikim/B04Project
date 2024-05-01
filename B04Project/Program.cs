
using System.Security.Cryptography.X509Certificates;
using B04Project;

namespace B04Project
{
    public static class ConsoleColors
    {
        public const string Reset = "\x1b[0m";
        public const string Black = "\x1b[30m";
        public const string Red = "\x1b[31m";
        public const string Green = "\x1b[32m";
        public const string Yellow = "\x1b[33m";
        public const string Blue = "\x1b[34m";
        public const string Purple = "\x1b[35m";
        public const string Cyan = "\x1b[36m";
        public const string White = "\x1b[37m";
    }
    public class GameManager
    {
        static Player player;
        static MonsterManager monsterManager;
        static BattleStart BattleStart;
        
        public GameManager()
        {
            InitializeGame(); //게임 초기설정
        }

        public void InitializeGame()
        {
            player = new Player("B04", "전사", 01, 10, 5, 100, 2000); //상태창에 띄워질 초기수치
            BattleStart = new BattleStart();
        }

        public void StartGame()
        {
            Console.Clear();
            ConsoleUtility.PrintGameHeader();
            MainMenu();
            
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(ConsoleColors.Purple);
            Console.WriteLine("\r\n                                                                                                                                                           \r\n                                                                                                                                                           \r\n  .--.--.                                     ___                            ,---,                                                                         \r\n /  /    '. ,-.----.                        ,--.'|_                        .'  .' `\\                                                                       \r\n|  :  /`. / \\    /  \\              __  ,-.  |  | :,'                     ,---.'     \\          ,--,      ,---,                         ,---.        ,---,  \r\n;  |  |--`  |   :    |           ,' ,'/ /|  :  : ' :                     |   |  .`\\  |       ,'_ /|  ,-+-. /  |  ,----._,.            '   ,'\\   ,-+-. /  | \r\n|  :  ;_    |   | .\\ :  ,--.--.  '  | |' |.;__,'  /    ,--.--.           :   : |  '  |  .--. |  | : ,--.'|'   | /   /  ' /   ,---.   /   /   | ,--.'|'   | \r\n \\  \\    `. .   : |: | /       \\ |  |   ,'|  |   |    /       \\          |   ' '  ;  :,'_ /| :  . ||   |  ,\"' ||   :     |  /     \\ .   ; ,. :|   |  ,\"' | \r\n  `----.   \\|   |  \\ :.--.  .-. |'  :  /  :__,'| :   .--.  .-. |         '   | ;  .  ||  ' | |  . .|   | /  | ||   | .\\  . /    /  |'   | |: :|   | /  | | \r\n  __ \\  \\  ||   : .  | \\__\\/: . .|  | '     '  : |__  \\__\\/: . .         |   | :  |  '|  | ' |  | ||   | |  | |.   ; ';  |.    ' / |'   | .; :|   | |  | | \r\n /  /`--'  /:     |`-' ,\" .--.; |;  : |     |  | '.'| ,\" .--.; |         '   : | /  ; :  | : ;  ; ||   | |  |/ '   .   . |'   ;   /||   :    ||   | |  |/  \r\n'--'.     / :   : :   /  /  ,.  ||  , ;     ;  :    ;/  /  ,.  |         |   | '` ,/  '  :  `--'   \\   | |--'   `---`-'| |'   |  / | \\   \\  / |   | |--'   \r\n  `--'---'  |   | :  ;  :   .'   \\---'      |  ,   /;  :   .'   \\        ;   :  .'    :  ,      .-./   |/       .'__/\\_: ||   :    |  `----'  |   |/       \r\n            `---'.|  |  ,     .-./           ---`-' |  ,     .-./        |   ,.'       `--`----'   '---'        |   :    : \\   \\  /           '---'        \r\n              `---`   `--`---'                       `--`---'            '---'                                   \\   \\  /   `----'                         \r\n                                                                                                                  `--`-'                                   \r\n");
            Console.WriteLine(ConsoleColors.Reset);
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine();
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
                    BattleStart.Battle();
                    break;
            }
            MainMenu();
        }

        public void StatusMenu()
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
