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
        


        public void Battle()
        {
            Console.Clear();
            ConsoleUtility.ShowTitle(" Battle! ");

            monsterManager.BattleMonsterMake();
            Console.WriteLine("");
            Console.WriteLine("1. 공격하기\n0. 도망치기");
            Console.ReadLine();
        }

        public void Battlesin()
        {
            ConsoleUtility.ShowTitle(" Battle! ");
            monsterManager.SetMonster();
        }
    }
}
