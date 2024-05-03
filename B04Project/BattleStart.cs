using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B04Project;

namespace B04Project
{
    public class BattleStart
    {        
        static GameManager gameManager;
        public BattleStart(GameManager GM)
        {
            gameManager = GM;
        }         
        public void Battle()
        {          
            Console.Clear();
            ConsoleUtility.ShowTitle("[ Battle !! ]\n");

            gameManager.monsterManager.BattleMonsterMake();
            Console.WriteLine($"\n\n[ 내 정보 ]\nLv.{gameManager.player.statusList[0].Level} {gameManager.player.statusList[0].Name} ( {gameManager.player.statusList[0].Chad} )\nHP {gameManager.player.statusList[0].Hp} / {gameManager.player.statusList[0].MaxHp}");
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

        //int HitPoint = 100; // player.cs 완성되면 player.Hp 입력
        int random_attackErrorrange;

        public void BattleScene()
        {
            Console.Clear();

            while (true)
            {
                ConsoleUtility.ShowTitle("[ Battle !! ]\n");
                gameManager.monsterManager.SetMonster();
                Console.WriteLine("");
                Console.WriteLine($"[ 내 정보 ]\nLv.{gameManager.player.statusList[0].Level} {gameManager.player.statusList[0].Name} ( {gameManager.player.statusList[0].Chad} )\nHP {gameManager.player.statusList[0].Hp} / {gameManager.player.statusList[0].MaxHp}"); // player.cs 완성되면 player.Hp 입력
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
            Console.WriteLine($"{gameManager.player.statusList[0].Atk}"); // 공격력 출력

            for (int i = 0; i < gameManager.monsterManager.enemyList.Count; i++)
            {
                if (!gameManager.monsterManager.enemyList[i].IsDead)
                {
                    Console.WriteLine($"{i + 1}. Lv.{gameManager.monsterManager.enemyList[i].Level} {gameManager.monsterManager.enemyList[i].MonName}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{i + 1}. Lv.{gameManager.monsterManager.enemyList[i].Level} {gameManager.monsterManager.enemyList[i].MonName} [ Dead ]");
                    Console.ResetColor();
                }
            }

            int choice;
            do
            {
                Console.Write(">>");
                choice = ConsoleUtility.PromptMenuChoice(1, gameManager.monsterManager.enemyList.Count);

                // 선택된 몬스터가 이미 죽어있는 경우 안내 메시지 표시
                if (gameManager.monsterManager.enemyList[choice - 1].IsDead)
                {
                    Console.WriteLine("이 몬스터는 이미 죽어있습니다. 다른 몬스터를 선택해주세요.");
                }
            } while (gameManager.monsterManager.enemyList[choice - 1].IsDead); // 선택된 몬스터가 이미 죽어있는 경우 다시 선택하도록 반복

            // 선택된 몬스터에 대한 공격 처리
            PlayerAttack();
            gameManager.monsterManager.enemyList[choice - 1].MonHP -=random_attackErrorrange; // 플레이어 공격력 기입 예정

            Console.Write("\nChad의 공격! ");
            Console.Write($"Lv.{gameManager.monsterManager.enemyList[choice - 1].Level} {gameManager.monsterManager.enemyList[choice - 1].MonName}을(를) 공격하였습니다. ");
            Console.Write($" {random_attackErrorrange} ");

            if (gameManager.monsterManager.enemyList[choice - 1].MonHP > 0)
            {
                Console.WriteLine($"[ {gameManager.monsterManager.enemyList[choice - 1].MonName}의 남은 체력 : {gameManager.monsterManager.enemyList[choice - 1].MonHP} ]");
            }
            else
            {
                gameManager.monsterManager.enemyList[choice - 1].IsDead = true;
                Console.WriteLine("[ Dead ]");
            }
            Console.ReadKey();
            MonsterPhase();
        }
        public void UsePotion()
        {

        }

        public void MonsterPhase()
        {   
            for (int i = 0; i < gameManager.monsterManager.enemyList.Count; i++)
            {
                if (!gameManager.monsterManager.enemyList[i].IsDead)
                {
                    Console.Write($"\nLv.{gameManager.monsterManager.enemyList[i].Level} {gameManager.monsterManager.enemyList[i].MonName}의 공격! ");
                    Console.Write($"[ 데미지 : {gameManager.monsterManager.enemyList[i].MonPower} ] ");
                    gameManager.player.statusList[0].Hp -= gameManager.monsterManager.enemyList[i].MonPower; // player.cs 완성되면 player.Hp 입력

                    if (gameManager.player.statusList[0].Hp <= 0) { gameManager.player.statusList[0].Hp = 0; }

                    Console.WriteLine($"[ {gameManager.player.statusList[0].Name}의 남은 체력 : {gameManager.player.statusList[0].Hp} ]"); // player.cs 완성되면 player.Hp 입력
                    Console.ReadKey();
                }
            }
        }

        public void EndPhase()
        {
            bool allMonstersDead = true;
            foreach (var monster in gameManager.monsterManager.enemyList)
            {
                if (!monster.IsDead)
                {
                    allMonstersDead = false;
                    break;
                }
            }

            if (gameManager.player.statusList[0].Hp <= 0 || allMonstersDead) // player.cs 완성되면 player.Hp 입력
            {
                Console.Clear();
                ConsoleUtility.ShowTitle("[ Battle !! - Result ]\n\n");
                
                if (gameManager.player.statusList[0].Hp <= 0) // player.cs 완성되면 player.Hp 입력
                {
                    Console.WriteLine("You Lose\n\n");
                    Console.WriteLine($"Lv.1 {gameManager.player.statusList[0].Name}\nHp : {gameManager.player.statusList[0].Hp} -> Dead\n"); // player.cs 완성되면 player.Hp 입력
                    Console.Write("0. 메인 메뉴\n>>");
                    gameManager.player.statusList[0].Hp = 1;
                }
                else if (allMonstersDead)
                {
                    Console.WriteLine("Victory\n\n");
                    Console.WriteLine("던전의 모든 몬스터를 토벌하였습니다.\n");
                    Console.WriteLine($"Lv.1 {gameManager.player.statusList[0].Name}\nHp : {gameManager.player.statusList[0].Hp}\n"); // player.cs 완성되면 player.Hp 입력
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
            //int Atk = 13;
            
            Random rand = new Random();
            int error = (int)Math.Ceiling(0.1f * gameManager.player.statusList[0].Atk);
            random_attackErrorrange = rand.Next((gameManager.player.statusList[0].Atk - error),(gameManager.player.statusList[0].Atk + error + 1));
        }
    }
}
