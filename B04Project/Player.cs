using System.Xml.Linq;
using System;
using System.Reflection.Emit;
using System.Linq.Expressions;

namespace B04Project
{

    public class Player
    {
        static MonsterManager monsterManager = new MonsterManager();
        static GameManager gameManager = new GameManager() ;
        public string name;
        private string chad;
        private int level;        
        private int hp;
        private int maxHp;
        private int mp;
        private int maxMp;
        private int atk;
        private int def;
        private int temAtk;
        private int temDef;
        private int totalAtk;
        private int totalDef;
        public int gold;
        public int exp;
        public int maxExp;

        public Player(string _name, string _chad, int _level, int _atk, int _def, int _temAtk, int _temDef,  int _hp, int _maxHp, int _mp, int _maxMp, int _gold, int _exp , int _maxExp)
        {
            name = _name;     //이름
            chad = _chad;     //직업?
            level = _level;   //렙
            atk = _atk;       //기본 공격력
            def = _def;       //기본 방어력
            temAtk = _temAtk; // +장비 공격력
            temDef = _temDef; // +장비 방어력
            totalAtk = _atk + _temAtk; //최종 공격력
            totalDef = _def + _temDef; //최종 방어력
            hp = _hp;        //현재 체력
            maxHp = _maxHp;  //최대 체력
            mp = _mp;        //현재 마력
            maxMp = _maxMp;  //최대 마력
            gold = _gold;    //보유 골드
            exp = _exp;      //경험치
            maxExp = _maxExp; //최대경험치
        }
        public Player(Player player) //몬스터 복제
        {
            name = player.name;
            chad = player.chad;
            level = player.level; 
            atk = player.atk; 
            def = player.def; 
            temAtk = player.temAtk; 
            temDef = player.temDef;
            totalAtk = player.atk + player.temAtk;
            totalDef = player.def + player.temDef;
            hp = player.hp;
            maxHp = player.maxHp;
            mp = player.mp;        //현재 마력
            maxMp = player.maxMp;  //최대 마력
            gold = player.gold;
            exp = player.exp;
            maxExp = player.maxExp;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Chad
        {
            get { return chad; }
            set { chad = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }        
        public int Atk
        {
            get { return atk; }
            set { atk = value; }
        }
        public int Def
        {
            get { return def; }
            set { def = value; }
        }
        public int TemAtk
        {
            get { return temAtk; }
            set { temAtk = value; }
        }
        public int TemDef
        {
            get { return temDef; }
            set { temDef = value; }
        }
        public int TotalAtk
        {
            get { return totalAtk; }
            set { totalAtk = value; }
        }
        public int TotalDef
        {
            get { return totalDef; }
            set { totalDef = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int MaxHp
        {
            get { return maxHp; }
            set { maxHp = value; }
        }
        public int Mp
        {
            get { return mp; }
            set { mp = value; }
        }
        public int MaxMp
        {
            get { return maxMp; }
            set { maxMp = value; }
        }
        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        public int MaxExp
        {
            get { return maxExp; }
            set { maxExp = value; }
        }

        public void LevelUp()
        {
            Level++;
            Atk += 1; // 공격력 증가
            Def += 1; // 방어력 증가
            MaxExp += (25 + Level * 15); // 다음 레벨까지 필요한 경험치 증가
            Exp = 0; // 현재 경험치 초기화
            Console.WriteLine($"레벨업! 현재 레벨: {Level}");
        }
        public int Maxexp(int level)
        {
            // 레벨에 따른 경험치 종류
            int[] expList = { 25 + level * 15 }; // 레벨에서 필요한 경험치

            // 레벨이 테이블 크기를 넘어갈 경우 마지막 경험치 반환
            if (level >= expList.Length)
            {
                return expList[expList.Length - 1];
            }

            return expList[level];
        }
    }
    
    public class PlayerManager
    {
        static MonsterManager monsterManager = new MonsterManager();
        static GameManager gameManager = new GameManager();
        public List<Player> statusList;

        public PlayerManager()
        {
            statusList = new List<Player>();
            statusList.Add(new Player("이름", "직업", 1, 60, 10, 0, 0, 300, 300, 10, 10, 3000, 0, 10));
        }



        public void NameChoice()
        {
            Console.WriteLine(ConsoleColors.Purple);
            Console.WriteLine("\r\n                                                                                                                                                           \r\n                                                                                                                                                           \r\n  .--.--.                                     ___                            ,---,                                                                         \r\n /  /    '. ,-.----.                        ,--.'|_                        .'  .' `\\                                                                       \r\n|  :  /`. / \\    /  \\              __  ,-.  |  | :,'                     ,---.'     \\          ,--,      ,---,                         ,---.        ,---,  \r\n;  |  |--`  |   :    |           ,' ,'/ /|  :  : ' :                     |   |  .`\\  |       ,'_ /|  ,-+-. /  |  ,----._,.            '   ,'\\   ,-+-. /  | \r\n|  :  ;_    |   | .\\ :  ,--.--.  '  | |' |.;__,'  /    ,--.--.           :   : |  '  |  .--. |  | : ,--.'|'   | /   /  ' /   ,---.   /   /   | ,--.'|'   | \r\n \\  \\    `. .   : |: | /       \\ |  |   ,'|  |   |    /       \\          |   ' '  ;  :,'_ /| :  . ||   |  ,\"' ||   :     |  /     \\ .   ; ,. :|   |  ,\"' | \r\n  `----.   \\|   |  \\ :.--.  .-. |'  :  /  :__,'| :   .--.  .-. |         '   | ;  .  ||  ' | |  . .|   | /  | ||   | .\\  . /    /  |'   | |: :|   | /  | | \r\n  __ \\  \\  ||   : .  | \\__\\/: . .|  | '     '  : |__  \\__\\/: . .         |   | :  |  '|  | ' |  | ||   | |  | |.   ; ';  |.    ' / |'   | .; :|   | |  | | \r\n /  /`--'  /:     |`-' ,\" .--.; |;  : |     |  | '.'| ,\" .--.; |         '   : | /  ; :  | : ;  ; ||   | |  |/ '   .   . |'   ;   /||   :    ||   | |  |/  \r\n'--'.     / :   : :   /  /  ,.  ||  , ;     ;  :    ;/  /  ,.  |         |   | '` ,/  '  :  `--'   \\   | |--'   `---`-'| |'   |  / | \\   \\  / |   | |--'   \r\n  `--'---'  |   | :  ;  :   .'   \\---'      |  ,   /;  :   .'   \\        ;   :  .'    :  ,      .-./   |/       .'__/\\_: ||   :    |  `----'  |   |/       \r\n            `---'.|  |  ,     .-./           ---`-' |  ,     .-./        |   ,.'       `--`----'   '---'        |   :    : \\   \\  /           '---'        \r\n              `---`   `--`---'                       `--`---'            '---'                                   \\   \\  /   `----'                         \r\n                                                                                                                  `--`-'                                   \r\n");
            Console.WriteLine(ConsoleColors.Reset);
            Console.WriteLine("\n\n\n원하시는 이름을 입력해주세요.");
            Console.Write(">>");
            string nameChoice = Console.ReadLine();
            statusList[0].Name = nameChoice;
        }
        public void JobChoice()
        {

            while (statusList[0].Chad == "직업")
            {
                Console.Clear();
                Console.WriteLine(ConsoleColors.Purple);
                Console.WriteLine("\r\n                                                                                                                                                           \r\n                                                                                                                                                           \r\n  .--.--.                                     ___                            ,---,                                                                         \r\n /  /    '. ,-.----.                        ,--.'|_                        .'  .' `\\                                                                       \r\n|  :  /`. / \\    /  \\              __  ,-.  |  | :,'                     ,---.'     \\          ,--,      ,---,                         ,---.        ,---,  \r\n;  |  |--`  |   :    |           ,' ,'/ /|  :  : ' :                     |   |  .`\\  |       ,'_ /|  ,-+-. /  |  ,----._,.            '   ,'\\   ,-+-. /  | \r\n|  :  ;_    |   | .\\ :  ,--.--.  '  | |' |.;__,'  /    ,--.--.           :   : |  '  |  .--. |  | : ,--.'|'   | /   /  ' /   ,---.   /   /   | ,--.'|'   | \r\n \\  \\    `. .   : |: | /       \\ |  |   ,'|  |   |    /       \\          |   ' '  ;  :,'_ /| :  . ||   |  ,\"' ||   :     |  /     \\ .   ; ,. :|   |  ,\"' | \r\n  `----.   \\|   |  \\ :.--.  .-. |'  :  /  :__,'| :   .--.  .-. |         '   | ;  .  ||  ' | |  . .|   | /  | ||   | .\\  . /    /  |'   | |: :|   | /  | | \r\n  __ \\  \\  ||   : .  | \\__\\/: . .|  | '     '  : |__  \\__\\/: . .         |   | :  |  '|  | ' |  | ||   | |  | |.   ; ';  |.    ' / |'   | .; :|   | |  | | \r\n /  /`--'  /:     |`-' ,\" .--.; |;  : |     |  | '.'| ,\" .--.; |         '   : | /  ; :  | : ;  ; ||   | |  |/ '   .   . |'   ;   /||   :    ||   | |  |/  \r\n'--'.     / :   : :   /  /  ,.  ||  , ;     ;  :    ;/  /  ,.  |         |   | '` ,/  '  :  `--'   \\   | |--'   `---`-'| |'   |  / | \\   \\  / |   | |--'   \r\n  `--'---'  |   | :  ;  :   .'   \\---'      |  ,   /;  :   .'   \\        ;   :  .'    :  ,      .-./   |/       .'__/\\_: ||   :    |  `----'  |   |/       \r\n            `---'.|  |  ,     .-./           ---`-' |  ,     .-./        |   ,.'       `--`----'   '---'        |   :    : \\   \\  /           '---'        \r\n              `---`   `--`---'                       `--`---'            '---'                                   \\   \\  /   `----'                         \r\n                                                                                                                  `--`-'                                   \r\n");
                Console.WriteLine(ConsoleColors.Reset);
                Console.WriteLine("\n\n\n1. 전 사. 기본공격력+3 최대체력+10");
                Console.WriteLine("2. 마법사. 최대마력+10");
                Console.WriteLine("3. 궁 수. 기본공격력+10");
                Console.WriteLine("0. 이름 다시 정하기");
                Console.WriteLine("원하시는 직업을 입력해주세요.");
                Console.Write(">>");

                int choice = 0;
                switch (ConsoleUtility.PromptMenuChoice(0, 3))
                {
                    case 0:
                        Console.Clear();
                        NameChoice();
                        break;
                    case 1:
                        Console.WriteLine("정말로" + ConsoleColors.Red + " 전사" + ConsoleColors.Reset + "의 길을 선택 하겠는가? \n1. 전사의 길을 걷기 \n0. 돌아가기\n");
                        Console.Write(">>");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.WriteLine("[ 전 사 ]의 길을 걷게 되었네. 축하하네 !!!");
                            statusList[0].Chad = "전사";
                            statusList[0].Atk += 3;
                            statusList[0].MaxHp += 20;
                            statusList[0].Hp += 20;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("다시 한번 말해주겠나?");
                            return;
                        }
                    case 2:
                        Console.WriteLine("정말로" + ConsoleColors.Red + " 마법사" + ConsoleColors.Reset + "를 선택할거야? \n1. 마법사의 길을 선택하기\n0. 돌아가기\n");
                        Console.Write(">>");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.WriteLine("[ 마법사 ]가 되었네, 축하해!!!");
                            statusList[0].Chad = "마법사";
                            statusList[0].MaxMp += 20;
                            statusList[0].Mp += 20;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("다시 한번 말해줘.");
                            return;
                        }
                    case 3:
                        Console.WriteLine("정말?" + ConsoleColors.Red + " 궁수" + ConsoleColors.Reset + "가 되고싶다고? 선택\n1. 궁수가 되기로 결심하기 \n0. 돌아가기\n");
                        Console.Write(">>");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.WriteLine("[ 궁 수 ]가 쉽지만은 않을거야.");
                            statusList[0].Chad = "궁수";
                            statusList[0].Atk += 10;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("다시 재고하는거야?");
                            return;
                        }
                }
            }
        }
    }
 }