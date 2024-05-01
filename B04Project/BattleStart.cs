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

        //public  class MonsterManager
        //{
        //    public List<Monster> monList; //전체 몬스터 리스트
        //    public List<Monster> enemyList; //전투 참여 몬스터 리스트
        //    public MonsterManager() //전체 몬스터
        //    {
        //        monList = new List<Monster>();
        //        enemyList = new List<Monster>();

        //        monList.Add(new Monster(1, "공허충", 30, 5, false));
        //        monList.Add(new Monster(1, "미니언", 30, 5, false));
        //        monList.Add(new Monster(1, "대포미니언", 30, 5, false));
        //        monList.Add(new Monster(1, "미니언2", 30, 5, false));
        //    }
        //    public void BattleMonsterMake() //전투에 쓰일 몬스터 가져오기 
        //    {
        //        int listCount = new Random().Next(0, 4); //등장수 1~4
        //        int random; //같은 몹도 나올수 잇게 하기 위함
        //        int renLevel; //몹랩에 랜덤

        //        enemyList.Clear();
        //        for (int i = 0; i <= listCount; i++)
        //        {
        //            random = new Random().Next(0, monList.Count); //전체 몬스터수
        //            renLevel = new Random().Next(0, 4); //몹랩 랜덤레벨 (Max 4) 

        //            Monster enemy = new Monster(monList[random]);

        //            enemyList.Add(enemy); //같은 몹도 나올수 잇게 하기 위함
        //            enemyList[i].Level = renLevel + 1; //몹랩에 랜덤
        //            enemyList[i].MonHP += enemyList[i].Level * 5; //몹랩당 체력 5 추가
        //            enemyList[i].MonPower += enemyList[i].Level; //몹랩당 공격력 1추가
        //            Console.WriteLine($"Lv.{enemyList[i].Level} {enemyList[i].MonName} | 체력: monHp | 공격력: {enemyList[i].MonPower}"); //battleMonList 확인용
        //        }
        //    }
        //    public void SetMonster()
        //    {
        //        for (int i = 0; i < enemyList.Count; i++)
        //        {
        //            string monHp = enemyList[i].IsDead ? "dead" : enemyList[i].MonHP.ToString(); //몹 체력이 0이면 "dead"표기

        //            Console.WriteLine($"[{i + 1}]. Lv.{enemyList[i].Level} {enemyList[i].MonName} | 체력: {monHp} | 공격력: {enemyList[i].MonPower}");


        //        }
        //        //string action = Console.ReadLine();
        //    }

            //public void TakeDamage()
            //{
            //    monHp -= Atk;
            //}
        }

        public void Battle()
        {
            Console.Clear();
            ConsoleUtility.ShowTitle("[ Battle !! ]\n");

            monsterManager.BattleMonsterMake();
            Console.WriteLine("");
            Console.WriteLine("1. 공격하기\n0. 도망치기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            switch (ConsoleUtility.PromptMenuChoice(0, 1))
            {
                case 0:
                    gameManager.MainMenu();
                    break;
                case 1:
                    BattleScene();
                    break;
            }
        }

        public void BattleScene()
        {
            Console.Clear();
            ConsoleUtility.ShowTitle("[ Battle !! ]\n");
            monsterManager.SetMonster();
            Console.WriteLine("\n공격하실 몬스터를 선택해주세요.");
            Console.Write(">>");
            Console.ReadLine();
        }
    }
}
