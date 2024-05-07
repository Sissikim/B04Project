using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using B04Project;

namespace B04Project
{
    internal class BattleStart
    {
        public BattleStart(GameManager GM)
        {
            gameManager = GM;
        }
        static PlayerManager PlayerManager = new PlayerManager();
        static MonsterManager monsterManager = new MonsterManager();
        static GameManager gameManager;
        //static ItemManager itemManager = new ItemManager(); //아이템매니저 생성자        
        
        public void Battle()
        {
            Console.Clear();
            //itemManager.MyInventory();
            ConsoleUtility.ShowTitle("[ Battle !! ]\n");

            monsterManager.BattleMonsterMake();
            Console.WriteLine($"\n\n[ 내 정보 ]\nLv.{GameManager.player.statusList[0].Level} {GameManager.player.statusList[0].Name} ( {GameManager.player.statusList[0].Chad} )\nHP {GameManager.player.statusList[0].Hp} / {GameManager.player.statusList[0].MaxHp}");
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

        int random_attackErrorrange;

        public void BattleScene()
        {
            Console.Clear();

            while (true)
            {
                ConsoleUtility.ShowTitle("[ Battle !! ]\n");
                monsterManager.SetMonster();
                Console.WriteLine("");
                Console.WriteLine($"[ 내 정보 ]\nLv.{GameManager.player.statusList[0].Level} {GameManager.player.statusList[0].Name} ( {GameManager.player.statusList[0].Chad} )\nHP {GameManager.player.statusList[0].Hp} / {GameManager.player.statusList[0].MaxHp}"); // player.cs 완성되면 player.Hp 입력
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

            for (int i = 0; i < monsterManager.enemyList.Count; i++)
            {
                if (!monsterManager.enemyList[i].IsDead)
                {
                    Console.WriteLine($"{i + 1}. Lv.{monsterManager.enemyList[i].Level}" + ConsoleColors.Red + monsterManager.enemyList[i].MonName + ConsoleColors.Reset);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{i + 1}. Lv.{monsterManager.enemyList[i].Level} {monsterManager.enemyList[i].MonName} [ Dead ]");
                    Console.ResetColor();
                }
            }

            int choice;
            do
            {
                Console.Write(">>");
                choice = ConsoleUtility.PromptMenuChoice(1, monsterManager.enemyList.Count);

                // 선택된 몬스터가 이미 죽어있는 경우 안내 메시지 표시
                if (monsterManager.enemyList[choice - 1].IsDead)
                {
                    Console.WriteLine("이 몬스터는 이미 죽어있습니다. 다른 몬스터를 선택해주세요.");
                }
            } while (monsterManager.enemyList[choice - 1].IsDead); // 선택된 몬스터가 이미 죽어있는 경우 다시 선택하도록 반복

            // 선택된 몬스터에 대한 공격 처리
            PlayerAttack();
            monsterManager.enemyList[choice - 1].MonHP -=random_attackErrorrange;

            Console.Write("\nChad의 공격! ");
            Console.Write($"Lv.{monsterManager.enemyList[choice - 1].Level}" + ConsoleColors.Red + monsterManager.enemyList[choice - 1].MonName + ConsoleColors.Reset ,"을(를) 공격하였습니다.") ;
            Console.Write($"[ 데미지 : {random_attackErrorrange} ] ");

            if (monsterManager.enemyList[choice - 1].MonHP > 0)
            {
                Console.WriteLine($"[ {monsterManager.enemyList[choice - 1].MonName}의 남은 체력 : {monsterManager.enemyList[choice - 1].MonHP} ]");
            }
            else
            {
                monsterManager.enemyList[choice - 1].IsDead = true;
                Console.WriteLine("[ Dead ]");
                Console.WriteLine($"{monsterManager.enemyList[choice - 1].Level}의 경험치를 획득하였습니다.{GameManager.player.statusList[0].exp + monsterManager.enemyList[choice - 1].Level}/{GameManager.player.statusList[0].maxExp}");
                GameManager.player.statusList[0].exp += monsterManager.enemyList[choice - 1].Level;

                while (GameManager.player.statusList[0].exp >= GameManager.player.statusList[0].maxExp)
                {
                    GameManager.player.statusList[0].Level++;
                    GameManager.player.statusList[0].Atk += 1; // 공격력 증가
                    GameManager.player.statusList[0].Def += 1; // 방어력 증가
                    GameManager.player.statusList[0].maxExp += (25 + PlayerManager.statusList[0].Level * 15); // 다음 레벨까지 필요한 경험치 증가
                    GameManager.player.statusList[0].Exp = 0; // 현재 경험치 초기화
                    Console.WriteLine($"레벨업! 현재 레벨: {GameManager.player.statusList[0].Level}");
                }
                
            }
            Console.ReadKey();
            MonsterPhase();
        }
        

        

        public void UsePotion()
        {

        }

        public void MonsterPhase()
        {   
            for (int i = 0; i < monsterManager.enemyList.Count; i++)
            {
                if (!monsterManager.enemyList[i].IsDead)
                {
                    Console.Write($"\nLv.{monsterManager.enemyList[i].Level} {monsterManager.enemyList[i].MonName}의 공격! ");
                    Console.Write($"[ 데미지 : {monsterManager.enemyList[i].monPower} ] ");
                    GameManager.player.statusList[0].Hp -= monsterManager.enemyList[i].monPower;

                    if (GameManager.player.statusList[0].Hp <= 0)
                    {
                        GameManager.player.statusList[0].Hp = 0;
                    }
                    Console.WriteLine($"[ {GameManager.player.statusList[0].Name}의 남은 체력 : {GameManager.player.statusList[0].Hp} ]");
                    Console.ReadKey();
                }
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

            if (GameManager.player.statusList[0].Hp <= 0 || allMonstersDead)
            {
                Console.Clear();
                ConsoleUtility.ShowTitle("[ Battle !! - Result ]\n\n");
                
                if (GameManager.player.statusList[0].Hp <= 0)
                {
                    Console.WriteLine("You Lose\n\n");
                    Console.WriteLine($"Lv.1 {GameManager.player.statusList[0].Name}\nHp : {GameManager.player.statusList[0].Hp} -> Dead\n");
                    Console.Write("0. 메인 메뉴\n>>");
                    GameManager.player.statusList[0].Hp = 1;
                }
                else if (allMonstersDead)
                {
                    Console.WriteLine("Victory\n\n");
                    Console.WriteLine("던전의 모든 몬스터를 토벌하였습니다.\n");
                    Console.WriteLine($"Lv.1 {GameManager.player.statusList[0].Name}\nHp : {GameManager.player.statusList[0].Hp}\n");
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

        public void PlayerAttack()
        {
            Random rand = new Random();
            int error = (int)Math.Ceiling(0.1f * (GameManager.player.statusList[0].Atk + GameManager.player.statusList[0].TemAtk));
            random_attackErrorrange = rand.Next((GameManager.player.statusList[0].Atk + GameManager.player.statusList[0].TemAtk - error),(GameManager.player.statusList[0].Atk + GameManager.player.statusList[0].TemAtk + error + 1));
        }
    }
}
