﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B04Project;

namespace B04Project
{
    internal class BattleStart
    {        
        static GameManager gameManager;        

        public BattleStart(GameManager GM) 
        {
            gameManager = GM;
        }
        
        public void Battle()
        {
            Console.Clear();
            gameManager.itemManager.MyInventory();
            ConsoleUtility.ShowTitle("[ Battle !! ]\n");

            gameManager.monsterManager.BattleMonsterMake();
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
                    Console.Clear();                    
                    BattleScene();
                    break;
            }
        }

        public void BattleScene()
        {
            while (true)
            {
                Console.Clear();
                ConsoleUtility.ShowTitle("[ Battle !! ]\n");
                gameManager.monsterManager.SetMonster();
                Console.WriteLine("");
                gameManager.itemManager.SetPotion();
                Console.WriteLine("");
                Console.WriteLine("\n1.공격?\n2.포션?.\n0.도망?(미구현)");
                Console.Write(">>");
                switch (ConsoleUtility.PromptMenuChoice(0, 2))
                {
                    case 0:
                        gameManager.MainMenu();
                        break;
                    case 1:
                        Attack();
                        break;
                    case 2:
                        BattleUsePotion();
                        break;
                }
            }
        }
        public void Attack()
        {
            Console.WriteLine("\n공격하실 몬스터를 선택해주세요.");
            Console.Write(">>");
            switch (ConsoleUtility.PromptMenuChoice(1, 4))
            {
                case 1:
                    gameManager.monsterManager.enemyList[0].MonHP -= 10; //플레이어 공격력값을 가져와서 넣어야하는데..        
                    break;
                case 2:
                    if (gameManager.monsterManager.enemyList.Count < 2) // 적의수가 2명이 아니면
                    {
                        Console.WriteLine("잘못입력.");
                        break;
                    }
                    else
                    {
                        gameManager.monsterManager.enemyList[1].MonHP -= 10; //플레이어 공격력값을 가져와서 넣어야하는데..               
                        break;
                    }
                case 3:
                    if (gameManager.monsterManager.enemyList.Count < 3) // 적의수가 3명이 아니면
                    {
                        Console.WriteLine("잘못입력.");
                        break;
                    }
                    else
                    {
                        gameManager.monsterManager.enemyList[2].MonHP -= 10; //플레이어 공격력값을 가져와서 넣어야하는데..               
                        break;
                    }
                case 4:
                    if (gameManager.monsterManager.enemyList.Count < 4) // 적의수가 4명이 아니면
                    {
                        Console.WriteLine("잘못입력.");
                        break;
                    }
                    else
                    {
                        gameManager.monsterManager.enemyList[3].MonHP -= 10; //플레이어 공격력값을 가져와서 넣어야하는데..               
                        break;
                    }
            }
            // MonsterAttack();   //적공격턴
        }
        public void BattleUsePotion() //전투중 포션사용
        {            
            Console.WriteLine("\n사용할 포션을 선택해주세요.");
            Console.Write(">>");
            switch (ConsoleUtility.PromptMenuChoice(1, 6)) //스위치 괄호 뒷부분 이해를 못해서 포션총갯수 6으로 넣음
            {
                case 1:
                    gameManager.itemManager.UsePotion(1);
                    break;
                case 2:
                    gameManager.itemManager.UsePotion(2);
                    break;
                case 3:
                    gameManager.itemManager.UsePotion(3);
                    break;
                case 4:
                    gameManager.itemManager.UsePotion(4);
                    break;
                case 5:
                    gameManager.itemManager.UsePotion(5);
                    break;
                case 6:
                    gameManager.itemManager.UsePotion(6);
                    break;
            }
        }

        public void MonsterAttack()
        {

        }

    }
}