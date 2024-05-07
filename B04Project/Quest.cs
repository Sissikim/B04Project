using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace B04Project
{
    public class Quest
    {
        public string questName { get; set; }
        public bool isChoise { get; set; }
        public bool isClear { get; set; }
        public int request { get; set; }
        public string rewardItem { get; set; }
        public int rewardGoid { get; set; }        
        public Quest(string _questName, bool _isChoise, int _request, bool _isClear, string _rewardItem, int _rewardGoid)
        {
            questName = _questName;
            isChoise = _isChoise;
            isClear = _isClear;
            request = _request;
            rewardItem = _rewardItem;
            rewardGoid = _rewardGoid;
        }
    }
    public class QuestManager
    {
        GameManager gameManager;
        List<Quest> QList;        

        public QuestManager(GameManager GM)
        { 
            gameManager = GM;

            QList =
            [
                new Quest("마을을 위협하는 미니언 처치",false, 0, false, "쓸만한 방패", 50),
                new Quest("장비를 장착해보자!",false, 0, false, "판매 테스트용", 500),
                new Quest("더욱 더 강해지기!",false, 0, false, "판매 테스트용", 500),
            ];            
        }
        public void QuestList() 
        { 
            for(int i = 0; i < QList.Count; i++) 
            {
                Console.WriteLine((i + 1) + $" .{QList[i].questName}");
            }
        }
        public void ShowQuest()
        {
            while (true)
            {
                Console.Clear();
                ConsoleUtility.ShowTitle("■ 퀘스트 ■");
                Console.WriteLine("");
                QuestList();                
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");                
                Console.WriteLine("9.강해지기 퀘확인용 강제 랩업");
                Console.WriteLine("");
                Console.WriteLine("원하시는 퀘스트를 선택하세요.");
                Console.Write(">>");
                
                switch (ConsoleUtility.PromptMenuChoice(0, 9))
                {
                    case 0:
                        gameManager.MainMenu();
                        break;
                    case 1:
                        Console.Clear();                        
                        Quests(0);
                        break;
                    case 2:
                        Console.Clear();                        
                        Quests(1);
                        break;
                    case 3:
                        Console.Clear();                        
                        Quests(2);
                        break;
                    case 9:   //강해지기 퀘 확인용                        
                        GameManager.player.statusList[0].Level += 1;
                        Console.WriteLine("[치트감지] 랩업아무키나 누르세요");
                        Console.ReadKey();
                        break;
                }
            }
        }        
        public void Quests(int _num)
        {
            QuestClear(_num);
            int num = _num;
            ConsoleUtility.ShowTitle("■ 퀘스트 ■");
            Console.WriteLine($"{QList[num].questName}");
            switch (num)
            {
                case 0:
                    Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?");
                    Console.WriteLine("마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!");
                    Console.WriteLine("모험가인 자네가 좀 처치해주게!");
                    Console.WriteLine($"- 미니언 5마리 처치 ({QList[num].request}/5)"); //BattleStart.cs 적처치시 받아와야함
                    Console.WriteLine("");
                    Console.WriteLine("- 보상-");
                    Console.WriteLine("");
                    Console.WriteLine("쓸만한 방패 x 1");
                    Console.WriteLine("50G");
                    Console.WriteLine("");
                    break;
                case 1: 
                    Console.WriteLine("이봐! 마을 근처에 장비들이 너무 많아졌다고 생각하지 않나?");
                    Console.WriteLine("마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!");
                    Console.WriteLine("모험가인 자네가 좀 장착해보게!");
                    Console.WriteLine("- 장비를 장착해보자! -");
                    Console.WriteLine("");
                    Console.WriteLine("- 보상-");
                    Console.WriteLine("");
                    Console.WriteLine("판매 테스트용, ");   
                    Console.WriteLine("500G");
                    Console.WriteLine("");
                    break;
                case 2:
                    
                    Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?");
                    Console.WriteLine("마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!");
                    Console.WriteLine("모험가인 자네가 좀 강해지게!");
                    Console.WriteLine("- 더욱 더 강해지기! -");
                    Console.WriteLine("");
                    Console.WriteLine("- 보상-");
                    Console.WriteLine("");
                    Console.Write("판매 테스트용, ");                    
                    Console.WriteLine(" 500G");
                    Console.WriteLine("");
                    break;
            }
            if (QList[num].isClear) //퀘 성공시
            {
                Console.WriteLine("1.보상 받기");
                Console.WriteLine("0.돌아가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                switch (ConsoleUtility.PromptMenuChoice(1, 2))
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine(" 보상이 정상적으로 지급되었습니다 ");
                        QuestReward(num);
                        Console.WriteLine("진행하시려면 아무키나 누르세요");
                        Console.ReadKey();
                        break;                        
                }
            }
            else if (!QList[num].isChoise) //아직 선택안했을때 나오는 것
            {
                Console.WriteLine("1. 수락");
                Console.WriteLine("0. 거절");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                switch (ConsoleUtility.PromptMenuChoice(0, 1))
                {
                    case 0:                        
                        break;
                    case 1:
                        Console.WriteLine(" 수락 하였습니다 ");
                        QList[num].isChoise = true;
                        if (QList[num].questName == "더욱 더 강해지기!")
                        { QList[num].request = GameManager.player.statusList[0].Level; }
                        Console.WriteLine("진행하시려면 아무키나 누르세요");
                        Console.ReadKey();
                        break;
                }
            }
            else //선택은 햇지만 성공은 못햇을때
            {
                Console.WriteLine(" - 퀘스트 진행중 - ");
                Console.WriteLine("진행하시려면 아무키나 누르세요");
                Console.ReadKey();
            }            
        }
        public void QuestClear(int _num) //퀘스트 성공햇는지 파악
        {
            switch (_num)
            {
                case 0:
                    if (QList[_num].isChoise && QList[_num].request >= 5) //요구조건이 5이상이면 [킬카운트]
                    { QList[_num].isClear = true; }
                    break;
                case 1:
                    if (QList[_num].isChoise && GameManager.player.statusList[0].TemAtk != 0 || GameManager.player.statusList[0].TemDef != 0) //장비공방력 0이 아니면 [장비장착햇으면]
                    { QList[_num].isClear = true; }
                    break;
                case 2:
                    if (QList[_num].isChoise && GameManager.player.statusList[0].Level > QList[2].request) //현재랩이 퀘수락시 랩보다 높으면 [랩업햇으면]
                    { QList[_num].isClear = true; }
                    break;
            }
        }
        public void QuestReward(int _num)  //보상지급
        {
            int num = _num;
            GameManager.player.statusList[0].gold += QList[num].rewardGoid;
            foreach (Item i in gameManager.itemManager.itemList) //아이템 보상
            {
                if (QList[num].rewardItem==i.Name)  //아이템보상이름 == 아이템리스트 안의 이름
                {
                    if (i.Equipment == "방패") //리스트에 방패분류라면
                    {
                        if (!i.IsBuy) { i.IsBuy = true; } //구매안된것이면 구매된것으로
                        else { GameManager.player.statusList[0].gold += i.Price; } //구매가 되어잇다면 방패판매금 만큼 돈으로 보상
                    }
                    else { i.ItemCarry += 1; } //나머지 보상은 무역품이니 걍 수량 1증가
                }
            }
            QList[num].isClear = false;
            QList[num].isChoise = false;
            if (QList[num]== QList[1]) { QList.Remove(QList[1]); }//장비 착용퀘는 1회용
        }
        
    }
}
