﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B04Project
{
    
    public class Monster
    {
        public int level;
        public string monName;
        public int monHP;
        public int monPower;
        public bool isDead;

        public Monster(int _level, string _monName, int _monHP, int _monPower, bool _isDead)
        {
            level = _level; //렙
            monName = _monName; //몹이름
            monHP = _monHP; //체력
            monPower = _monPower; // 공격력
            isDead = _isDead; //생존 여부
        }
        public Monster(Monster monster) //몬스터 복제
        {
            level=monster.level;
            monName = monster.monName; //몹이름
            monHP = monster.monHP; //체력
            monPower = monster.monPower; // 공격력
            isDead = monster.isDead; //생존 여부
            
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public string MonName
        {
            get { return monName; }
            set { monName = value; }
        }
        public int MonHP
        {
            get { return monHP; }
            set { monHP = value; }
        }
        public int MonPower
        {
            get { return monPower; }
            set { monPower = value; }
        }
        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }
        public bool DeadCheck() //생사 여부 확인용
        {
            if (monHP <= 0)
            {
                monHP = 0;
                isDead = true;
                //경험치를 여기서 줘야할듯
            }
            return isDead;
        }
    }
    public class MonsterManager
    {
        
        public List<Monster> monList; //전체 몬스터 리스트
        public List<Monster> enemyList; //전투 참여 몬스터 리스트
        public MonsterManager() //전체 몬스터
        {
            monList = new List<Monster>();
            enemyList = new List<Monster>();

            monList.Add(new Monster(1, "공허충", 2, 2, false));
            monList.Add(new Monster(1, "미니언", 2, 3, false));
            monList.Add(new Monster(1, "대포미니언", 2, 4, false));
            monList.Add(new Monster(1, "슈퍼미니언", 2, 7, false));
        }
        public List<Monster> BattleMonsterMake() //전투에 쓰일 몬스터 가져오기 
        {
            int listCount = new Random().Next(0, 4); //등장수 1~4
            int random; //같은 몹도 나올수 잇게 하기 위함
            int renLevel; //몹랩에 랜덤 - 몹랩==경험치
           
            enemyList.Clear();
            for (int i = 0; i <= listCount; i++)
            {
                random = new Random().Next(0, monList.Count); //전체 몬스터수
                renLevel = new Random().Next(0, 4); //몹랩 랜덤레벨 (Max 4) 

                Monster enemy = new Monster(monList[random]);

                enemyList.Add(enemy); //같은 몹도 나올수 잇게 하기 위함
                enemyList[i].Level = renLevel + 1; //몹랩에 랜덤
                enemyList[i].MonHP += enemyList[i].Level * 5; //몹랩당 체력 5 추가
                enemyList[i].MonPower += enemyList[i].Level; //몹랩당 공격력 1추가
                Console.WriteLine($"Lv.{enemyList[i].Level}"  + ConsoleColors.Red + enemyList[i].MonName + ConsoleColors.Reset); //battleMonList 확인용
            }
            return enemyList;
        }
        public void SetMonster()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                string monHp = enemyList[i].IsDead ? "Dead" : enemyList[i].MonHP.ToString(); //몹 체력이 0이면 "dead"표기

                Console.WriteLine($"[{i + 1}] Lv.{enemyList[i].Level}" + ConsoleColors.Red + enemyList[i].MonName + ConsoleColors.Reset +" | 체력: " + monHp + "| 공격력: " + enemyList[i].MonPower);
            }
            //string action = Console.ReadLine();
        }
    }
}
