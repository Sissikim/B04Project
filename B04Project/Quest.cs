using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace B04Project
{
    internal class Quest
    {
        GameManager gameManager;
        public Quest(GameManager GM)
        {
            gameManager = GM;
        }
        public void ShowQuest()
        {
            while (true)
            {
                Console.Clear();
                ConsoleUtility.ShowTitle("■ 퀘스트 ■");
                Console.WriteLine("");
                Console.WriteLine("1.마을을 위협하는 미니언 처치");
                Console.WriteLine("2.장비를 장착해보자");
                Console.WriteLine("3.더욱 더 강해지기!");
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 퀘스트를 선택하세요.");
                Console.Write(">>");

                switch (ConsoleUtility.PromptMenuChoice(0, 3))
                {
                    case 0:
                        gameManager.MainMenu();
                        break;
                    case 1:
                        Quests(0);
                        break;
                    case 2:
                        Quests(1);
                        break;
                    case 3:
                        Quests(2);
                        break;
                }
            }
        }
        public void Quests(int _num)
        {
            int num = _num;
            switch (num)
            {
                case 0:
                    ConsoleUtility.ShowTitle("■ 퀘스트 ■");
                    Console.WriteLine("마을을 위협하는 미니언 처치");
                    Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?");
                    Console.WriteLine("마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!");
                    Console.WriteLine("모험가인 자네가 좀 처치해주게!");
                    Console.WriteLine("- 미니언 5마리 처치 (0/5)");
                    Console.WriteLine("- 보상-");
                    Console.WriteLine("쓸만한 방패 x 1");
                    Console.WriteLine("5G");
                    Console.WriteLine("1. 수락");
                    Console.WriteLine("2. 거절");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                    break;
                case 1:
                    ConsoleUtility.ShowTitle("■ 퀘스트 ■");
                    Console.WriteLine("마을을 위협하는 미니언 처치");
                    Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?");
                    Console.WriteLine("마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!");
                    Console.WriteLine("모험가인 자네가 좀 처치해주게!");
                    Console.WriteLine("- 미니언 5마리 처치 (0/5)");
                    Console.WriteLine("- 보상-");
                    Console.WriteLine("쓸만한 방패 x 1");
                    Console.WriteLine("5G");
                    Console.WriteLine("1. 수락");
                    Console.WriteLine("2. 거절");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                    break;
                case 2:
                    ConsoleUtility.ShowTitle("■ 퀘스트 ■");
                    Console.WriteLine("마을을 위협하는 미니언 처치");
                    Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?");
                    Console.WriteLine("마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!");
                    Console.WriteLine("모험가인 자네가 좀 처치해주게!");
                    Console.WriteLine("- 미니언 5마리 처치 (0/5)");
                    Console.WriteLine("- 보상-");
                    Console.WriteLine("쓸만한 방패 x 1");
                    Console.WriteLine("5G");
                    Console.WriteLine("1. 수락");
                    Console.WriteLine("2. 거절");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                    break;
            }
            switch (ConsoleUtility.PromptMenuChoice(1, 2))
            {
                case 1:
                    ChoiseQuest(num);
                    break;
                case 2:
                    break;
            }

            void ChoiseQuest(int _num)
            {
                int num = _num;
                switch (num)
                {
                    case 0:
                        if (num==0) // 플레이어 경험치값이 10 이상이면 클리어 [미구현: 플레이어 경험치값이 없음]
                        {
                            QuestClaer(0);
                        }
                        
                        break;
                    case 1:
                        if (GameManager.player.statusList[0].TemAtk != 0 || GameManager.player.statusList[0].TemDef != 0) 
                        {
                            QuestClaer(1);
                        }
                        break;
                    case 2:
                        if (GameManager.player.statusList[0].Level != 1)
                        {
                            QuestClaer(2);
                        }
                        break;
                }
            }
            void QuestClaer(int _num)
            {
                switch (num)
                {
                    case 0:
                        foreach (Item i in gameManager.itemManager.myList) 
                        {
                            if (i.Name == "수련자 갑옷")  //이름이 "수련자 갑옷"인 아이템의
                            {
                                if (!i.IsBuy) // 구매여부가 
                                {

                                }
                                else 
                                { 

                                }
                            }
                        }                        
                        break;
                    case 1:
                        
                        break;
                    case 2:

                        break;
                }
            }
        }
    }
}
