using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B04Project;

namespace B04Project
{
    internal class BattleStart
    {
        static MonsterManager monsterManager = new MonsterManager();
        static GameManager gameManager = new GameManager(); 
        


        public void Battle()
        {
            Console.Clear();
            //itemManager.MyInventory();
            ConsoleUtility.ShowTitle("[ Battle !! ]\n");

            monsterManager.BattleMonsterMake();
            Console.WriteLine("\n\n[ 내 정보 ]\nLv.1 Chad ( 전사 )\nHP 100 / 100");
            Console.WriteLine("\n1. 공격하기\n0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            switch (ConsoleUtility.PromptMenuChoice(0, 1))
            {
                case 0:
                    gameManager.MainMenu();
                    break;
                case 1:
                    Console.Clear();
                    BattleScene();
                    break;
            }
        }

        int HitPoint = 100; // player.cs 완성되면 player.Hp 입력

        public void BattleScene()
        {
            Console.Clear();

            while (true)
            {
                ConsoleUtility.ShowTitle("[ Battle !! ]\n");
                monsterManager.SetMonster();
                Console.WriteLine("");
                Console.WriteLine($"[ 내 정보 ]\nLv.1 Chad ( 전사 )\nHP {HitPoint} / 100"); // player.cs 완성되면 player.Hp 입력
                //itemManager.SetPotion();
                Console.WriteLine("");
                Console.WriteLine("\n1. 공격\n2. 아이템 사용\n0. 나가기");
                Console.Write(">>");
                switch (ConsoleUtility.PromptMenuChoice(0, 2))
                {
                    case 0:
                        gameManager.MainMenu();
                        break;
                    case 1:
                        PlayerPhase();
                        break;
                    case 2:
                        UsePotion();
                        break;
                }
                EndPhase();
            }
        }
        public void PlayerPhase()
        {
            Console.WriteLine("\n공격하실 몬스터를 선택해주세요.");
            Console.Write(">>");
            switch (ConsoleUtility.PromptMenuChoice(1, 4))
            {
                case 1:

                    monsterManager.enemyList[0].MonHP -= 10; //플레이어 공격력 기입 예정

                    Console.Write("Chad 의 공격! ");
                    Console.Write($"Lv.{monsterManager.enemyList[0].Level}  {monsterManager.enemyList[0].monName} 을(를) 공격하였습니다. ");
                    Console.Write($"[ 데미지 : 10 ] ");

                    if (monsterManager.enemyList[0].MonHP > 0)
                    {
                        Console.WriteLine($"[ {monsterManager.enemyList[0].monName}의 남은 체력 : {monsterManager.enemyList[0].monHP} ]");
                    }
                    else
                    {
                        monsterManager.enemyList[0].isDead = true;
                        Console.WriteLine("[ Dead ]");
                    }
                    Console.ReadLine();
                    //Console.Write("\n\n1. 다음으로\n");
                    //ConsoleUtility.PromptMenuChoice(1, 1);
                    break;
                case 2:
                    if (monsterManager.enemyList.Count < 2) // 적의수가 2명이 아니면
                    {
                        Console.WriteLine("잘못입력.");
                        break;
                    }
                    else
                    {

                        monsterManager.enemyList[1].MonHP -= 10; //플레이어 공격력 기입 예정

                        Console.Write("Chad 의 공격!");
                        Console.Write($"Lv.{monsterManager.enemyList[1].Level} {monsterManager.enemyList[1].monName} 을(를) 공격하였습니다.");
                        Console.Write($"[ 데미지 : 10 ]");

                        if (monsterManager.enemyList[1].MonHP > 0)
                        {
                            Console.WriteLine($"[ {monsterManager.enemyList[1].monName}의 남은 체력 : {monsterManager.enemyList[1].monHP} ]");
                        }
                        else
                        {
                            monsterManager.enemyList[1].isDead = true;
                            Console.WriteLine("[ Dead ]");
                        }
                        Console.ReadLine();
                        //Console.Write("\n\n1. 다음으로\n");
                        //ConsoleUtility.PromptMenuChoice(1, 1);
                        break;
                    }
                case 3:
                    if (monsterManager.enemyList.Count < 3) // 적의수가 3명이 아니면
                    {
                        Console.WriteLine("잘못입력.");
                        break;
                    }
                    else
                    {

                        monsterManager.enemyList[2].MonHP -= 10; //플레이어 공격력 기입 예정

                        Console.Write("Chad 의 공격!");
                        Console.Write($"Lv.{monsterManager.enemyList[2].Level} {monsterManager.enemyList[2].monName} 을(를) 공격하였습니다.");
                        Console.Write($"[ 데미지 : 10 ]");

                        if (monsterManager.enemyList[2].MonHP > 0)
                        {
                            Console.WriteLine($"[  {monsterManager.enemyList[2].monName} 의 남은 체력 : {monsterManager.enemyList[2].monHP} ]");
                        }
                        else
                        {
                            monsterManager.enemyList[2].isDead = true;
                            Console.WriteLine("[ Dead ]");
                        }
                        Console.ReadLine();
                        //Console.Write("\n\n1. 다음으로\n");
                        //ConsoleUtility.PromptMenuChoice(1, 1);
                        break;
                    }
                case 4:
                    if (monsterManager.enemyList.Count < 4) // 적의수가 4명이 아니면
                    {
                        Console.WriteLine("잘못입력.");
                        break;
                    }
                    else
                    {

                        monsterManager.enemyList[3].MonHP -= 10; //플레이어 공격력 기입 예정

                        Console.Write("Chad 의 공격!");
                        Console.Write($"Lv.{monsterManager.enemyList[3].Level} {monsterManager.enemyList[3].monName} 을(를) 공격하였습니다.");
                        Console.Write($"[ 데미지 : 10 ]");

                        if (monsterManager.enemyList[3].MonHP > 0)
                        {
                            Console.WriteLine($"[  {monsterManager.enemyList[3].monName} 의 남은 체력 : {monsterManager.enemyList[3].monHP} ]");
                        }
                        else
                        {
                            monsterManager.enemyList[3].isDead = true;
                            Console.WriteLine("[ Dead ]");
                        }
                        Console.ReadLine();
                        //Console.Write("\n\n1. 다음으로\n");
                        //ConsoleUtility.PromptMenuChoice(1, 1);
                        break;
                    }
            }
            MonsterPhase();
        }
        public void UsePotion()
        {

        }

        public void MonsterPhase()
        {
            for (int i = 0; i < monsterManager.enemyList.Count; i++)
            {
                Console.Write($"Lv.{monsterManager.enemyList[i].Level} {monsterManager.enemyList[i].MonName}의 공격! ");
                Console.Write($"[ 데미지 : {monsterManager.enemyList[i].monPower} ] ");
                HitPoint -= monsterManager.enemyList[i].monPower; // player.cs 완성되면 player.Hp 입력

                Console.WriteLine($"[ Chad의 남은 체력 : {HitPoint} ]"); // player.cs 완성되면 player.Hp 입력
                Console.ReadLine();
                //Console.Write("\n\n1. 다음으로\n");
                //ConsoleUtility.PromptMenuChoice(1, 1);
            }
        }

        public void EndPhase()
        {
            bool allMonstersDead = true;
            foreach (var monster in monsterManager.enemyList)
            {
                if (!monster.IsDead)
                {
                    allMonstersDead = false;
                    break;
                }
            }

            if (HitPoint <= 0 || allMonstersDead) // player.cs 완성되면 player.Hp 입력
            {
                Console.Clear();
                ConsoleUtility.ShowTitle("[ Battle !! - Result ]\n\n");
                
                if (HitPoint <= 0) // player.cs 완성되면 player.Hp 입력
                {
                    Console.WriteLine("You Lose\n\n");
                    Console.WriteLine($"Lv.1 Chad\nHp : {HitPoint} -> Dead\n"); // player.cs 완성되면 player.Hp 입력
                    Console.Write("0. 메인 메뉴\n>>");
                }
                else if (allMonstersDead)
                {
                    Console.WriteLine("Victory\n\n");
                    Console.WriteLine("던전의 모든 몬스터를 토벌하였습니다.\n");
                    Console.WriteLine($"Lv.1 Chad\nHp : {HitPoint}\n"); // player.cs 완성되면 player.Hp 입력
                    Console.Write("0. 메인 메뉴\n>>");
                }
                
                
                switch (ConsoleUtility.PromptMenuChoice(0, 0))
                {
                    case 0:
                        gameManager.MainMenu();
                        break;
                }
            }
        }
    }
}
