using System.Xml.Linq;
using System;
using System.Numerics;

namespace B04Project
{
    public class Player
    {  
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

        public Player(string _name, string _chad, int _level, int _atk, int _def, int _temAtk, int _temDef,  int _hp, int _maxHp, int _mp, int _maxMp, int _gold)
        {
            name = _name;     //이름
            chad = _chad;     //직업?
            level = _level;   //렙
            atk = _atk;       //기본 공격력
            def = _def;       //기본 방어력
            temAtk = _temAtk; // +장비 공격력
            temDef = _temDef; // +장비 방어력
            totalAtk = _atk+ _temAtk; //최종 공격력
            totalDef = _def+ _temDef; //최종 방어력
            hp = _hp;        //현재 체력
            maxHp = _maxHp;  //최대 체력
            mp = _mp;        //현재 마력
            maxMp = _maxMp;  //최대 마력
            gold = _gold;    //보유 골드
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
    }
    
    public class PlayerManager
    {
        public List<Player> statusList;

        public PlayerManager()
        {
            statusList = new List<Player>();
            statusList.Add(new Player("이름", "직업", 1, 5, 0, 0, 0, 30, 30, 10, 10, 3000));
        }
        public void NameChoice()
        {
            Console.WriteLine("원하시는 이름을 입력해주세요.");
            Console.Write(">>");
            string nameChoice = Console.ReadLine();
            statusList[0].Name = nameChoice;
        }
        public void JobChoice()
        {

            while (statusList[0].Chad=="직업")
            {
                Console.WriteLine("1. 전 사. 기본공격력+3 최대체력+10");
                Console.WriteLine("2.마법사. 최대마력+10");
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
                        Console.WriteLine("1. 정말? 전사 선택\n0. 돌아가기\n");
                        Console.Write(">>");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.WriteLine("[ 전 사 ]가 되어버렷 !!!");
                            statusList[0].Chad = "전사";
                            statusList[0].Atk += 3;
                            statusList[0].MaxHp += 20;
                            statusList[0].Hp += 20;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 2:
                        Console.WriteLine("1. 정말? 마법사 선택\n0. 돌아가기\n");
                        Console.Write(">>");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.WriteLine("[ 마법사 ]가 되어버렷!!!");
                            statusList[0].Chad = "마법사";
                            statusList[0].MaxMp += 20;
                            statusList[0].Mp += 20;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 3:
                        Console.WriteLine("1. 정말? 궁수 선택\n0. 돌아가기\n");
                        Console.Write(">>");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.WriteLine("[ 궁 수 ]가 되어버렷!!!");
                            statusList[0].Chad = "궁수";
                            statusList[0].Atk += 10;                            
                            break;
                        }
                        else
                        {
                            break;
                        }
                }
            }
        }
        public void StatusMenu()
        {
            Console.Clear();
            ConsoleUtility.ShowTitle("■ 상태보기 ■");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            Console.WriteLine($"Lv. {statusList[0].Level}");
            Console.WriteLine($"이  름 : {statusList[0].Name}");
            Console.WriteLine($"Chad ( {statusList[0].Chad} )");
            Console.WriteLine($"체  력 : {statusList[0].Hp} / {statusList[0].MaxHp}");
            Console.WriteLine($"마  력 : {statusList[0].Mp} / {statusList[0].MaxMp}");
            Console.WriteLine("=============================");
            Console.WriteLine($"공격력 : {statusList[0].Atk} +{statusList[0].TemAtk}");
            Console.WriteLine($"방어력 :  {statusList[0].Def} +{statusList[0].TemDef}");
            Console.WriteLine("");
            Console.WriteLine($"Gold : {statusList[0].Gold} G");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");            
        }
    }
 }