using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using B04Project;

namespace B04Project
{

    public class Item
    {
        public int level;
        private string itemName;
        private string equipment;
        private bool isEquipment;
        private string type;
        private int itemValue;
        private string info;
        private int price;
        private bool isBuy;
        private int itemCarry;
        private int maxItemCarry;

        public Item(int _level, string _itemName, string _equipment, bool _isEquipment, string _type, int _itemValue, string _info, int _price, bool _isBuy) //장비+무역
        {
            level = _level; //렙 강화횟수?
            itemName = _itemName; //이름
            isEquipment = _isEquipment; //장비 착용여부
            equipment = _equipment; //장비 장착 부위(무기,장비,무역...소모?)
            type = _type;  //아이템 능력(공격역,방어력,회복력)
            itemValue = _itemValue; // 아이템능력치
            info = _info;   // 소개
            price = _price; //가격
            isBuy = _isBuy; //구매 여부
        }
        public Item(int _num, string _itemName, string _equipment, string _type, int _itemValue, string _info, int _price, int _itemCarry, int _maxItemCarry) //소모품 아이템 생성자
        {
            level = _num; //호출 할수가 없어서 만든 주소값 같은것..
            itemName = _itemName; //이름
            equipment = _equipment; //장비 부위(소모)
            type = _type;  //아이템 능력(회복력,)
            itemValue = _itemValue; // 아이템능력치
            info = _info;   // 소개
            price = _price; //가격 
            itemCarry = _itemCarry; //소지 갯수
            maxItemCarry = _maxItemCarry;//최대소지 갯수
        }

        public Item(Item item) //복제
        {
            level = item.level;
            itemName = item.itemName;
            isEquipment = item.isEquipment;
            equipment = item.equipment;
            type = item.type;
            itemValue = item.itemValue;
            info = item.info;
            price = item.price;
            isBuy = item.isBuy;
            itemCarry = item.itemCarry; //소지 갯수
            maxItemCarry = item.maxItemCarry;//최대소지 갯수
        }


        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public string Name
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public bool IsEquipment
        {
            get { return isEquipment; }
            set { isEquipment = value; }
        }
        public string Equipment
        {
            get { return equipment; }
            set { equipment = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int ItemValue
        {
            get { return itemValue; }
            set { itemValue = value; }
        }
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public bool IsBuy
        {
            get { return isBuy; }
            set { isBuy = value; }
        }
        public int ItemCarry
        {
            get { return itemCarry; }
            set { itemCarry = value; }
        }
        public int MaxItemCarry
        {
            get { return maxItemCarry; }
            set { maxItemCarry = value; }
        }

    }
    public class ItemManager
    {
        static GameManager gameManager;

        public List<Item> itemList; //전체 아이템 리스트
        public List<Item> myList; //내 보유한 리스트

        public ItemManager(GameManager GM) //전체 아이템
        {
            gameManager = GM;
            myList = new List<Item>();
            itemList =
            [
                new Item(0, "낡은 검    ", "무기", false, "공격력", 2, "낡은 검 입니다.", 500, true),
                new Item(0, "청동 도끼  ", "무기", false, "공격력", 5, "청동 도끼 입니다.", 2000, true),
                new Item(0, "스파르타의 창", "무기", false, "공격력", 7, "전설의 창입니다.", 3500, false),
                new Item(0, "수련자 갑옷 ", "장비", false, "방어력", 5, "수련용 갑옷입니다.", 500, true),
                new Item(0, "무쇠갑옷    ", "장비", false, "방어력", 9, "튼튼한 갑옷입니다.", 2000, true),
                new Item(0, "스파르타의 갑옷", "장비", false, "방어력", 15, "전설의 갑옷입니다.", 3500, false),
                new Item(0, "쓸만한 방패  ", "방패", false, "방어력", 5, "쓸만한 방패 입니다.", 500, false),
                new Item(0, "구매 테스트용", "무역", "무역", 0, "잡탬.", 100, 0, 99),
                new Item(0, "판매 테스트용", "무역", "무역", 0, "잡탬.", 100, 0, 99),
                new Item(0, "소량 회복포션", "소모", "체력", 25, "25체력 회복약.", 100, 1, 10),
                new Item(0, "중량 회복포션", "소모", "체력", 50, "50체력 회복약.", 300, 0, 5),
                new Item(0, "대량 회복포션", "소모", "체력", 100, "100체력 회복약.", 1000, 1, 2),
                new Item(0, "소량 마나포션", "소모", "마력", 10, "10마력 회복약.", 100, 0, 10),
                new Item(0, "중량 마나포션", "소모", "마력", 25, "25마력 회복약.", 300, 0, 5),
                new Item(0, "대량 마나포션", "소모", "마력", 50, "50마력 회복약.", 1000, 0, 2),                
            ];     
        }
        public void MyInventory() //내인벤토리
        {
            myList.Clear(); //초기화 (사실 왜 하는진 모름.)
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].IsBuy)  //구매한 아이템 이라면
                {
                    Item myItem = new Item(itemList[i]); //해당아이템 복사
                    myList.Add(myItem);
                }
                if (itemList[i].ItemCarry != 0) //포션,무역 류 소지갯수가 1이상 이라면
                {
                    Item myItem = new Item(itemList[i]); //해당아이템 복사
                    myList.Add(myItem);
                }
            }
        }
        public void SetMyInventory() //내인벤토리 표시
        {
            while (true)
            {
                Console.Clear();
                ConsoleUtility.ShowTitle("■ 인벤토리 ■");
                Console.WriteLine("");                
                for (int i = 0; i < myList.Count; i++)
                {
                    string isEquipment = myList[i].IsEquipment ? "E" : "X"; //착용된 장비면 "E" 아니면 "X"
                    if (myList[i].Equipment == "무역") // 장비군이 무역탬이면 [강화,공격력,착용여부 등 표시 할 필요 없어서]
                    { Console.WriteLine($"{myList[i].Name}| {myList[i].Equipment} | {myList[i].Info} | ({myList[i].ItemCarry}/{myList[i].MaxItemCarry}) | {myList[i].Price}G"); }
                    else if (myList[i].Equipment == "소모") //장비군이 소모탬이면 [강화,착용여부 등 표시 할 필요 없어서]
                    { Console.WriteLine($"{myList[i].Name}| {myList[i].Equipment} | {myList[i].Info} | ({myList[i].ItemCarry}/{myList[i].MaxItemCarry})"); }
                    else //장비라면 
                    { Console.WriteLine($"[{isEquipment}]{myList[i].Name}+{myList[i].Level}강 | {myList[i].Equipment} | {myList[i].Type} +{myList[i].ItemValue} | {myList[i].Info}"); }
                }
                Console.WriteLine("");
                Console.WriteLine($"보유골드 [{GameManager.player.statusList[0].Gold}G]");
                Console.WriteLine("");
                Console.WriteLine("1. 착용하기\n0. 나가기\n");
                Console.Write(">>");
                switch (ConsoleUtility.PromptMenuChoice(0, 1))
                {
                    case 0:
                        gameManager.MainMenu();
                        break;
                    case 1:
                        Console.Clear();
                        SetEquipmenty();
                        break;
                }
            }
        }
        public void SetEquipmenty() //장비 착용부
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("장착관리 ");
                for (int i = 0; i < myList.Count; i++)
                {
                    string isEquipment = myList[i].IsEquipment ? "E" : "X"; //착용된 장비면 "E" 아니면 "X"
                    if (myList[i].Equipment == "무기" || myList[i].Equipment == "장비")
                    { Console.WriteLine($"{i + 1}. [{isEquipment}]{myList[i].Name}+{myList[i].Level}강 | {myList[i].Equipment} | {myList[i].Type} +{myList[i].ItemValue} | {myList[i].Info}"); }
                }
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.Write(">>");

                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                if (choice == 0)
                {
                    break;
                }
                else if (choice > 0 && choice < myList.Count)
                {

                    myList[choice - 1].IsEquipment = !myList[choice - 1].IsEquipment; //선택장비 착용
                    if (myList[choice - 1].Equipment == "무기") { GameManager.player.statusList[0].TemAtk += myList[choice - 1].ItemValue; }
                    else { GameManager.player.statusList[0].TemDef += myList[choice - 1].ItemValue; }

                    foreach (Item i in myList) //리스트내에 모든 Item 자료를 i로 불러온다
                    {
                        if (myList[choice - 1] != i) //선택장비와 같은것 열외
                        {
                            if (myList[choice - 1].Equipment == i.Equipment) //같은종류의 장비중에
                            {
                                if (myList[choice - 1].IsEquipment) //선택장비 착용이 되엇으면 [단순 벗기할때 감지]
                                {
                                    if (i.IsEquipment) //다른장비가 착용중 이라면
                                    {
                                        i.IsEquipment = false; // 그 다른장비는 벗기
                                        if (i.Equipment == "무기") { GameManager.player.statusList[0].TemAtk -= i.ItemValue; }
                                        else { GameManager.player.statusList[0].TemDef += i.ItemValue; }
                                    } //중복착용 방지
                                }
                            }
                        }
                    }
                }
                else { Console.WriteLine("잘못된 입력."); }
            }
        }
        public void SetPotion() //내포션
        {
            int j = 1;
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].Equipment == "소모") //장비군이 소모탬이면 [강화,착용여부 등 표시 할 필요 없어서]
                {
                    myList[i].Level = j;
                    Console.WriteLine($"{myList[i].Level}. {myList[i].Name}| {myList[i].Equipment} | {myList[i].Info} | ({myList[i].ItemCarry}/{myList[i].MaxItemCarry})");
                    j++;
                }
            }
        }
        public void UsePotion(int _num)
        {
            foreach (Item i in myList)
            {
                if (i.Level == _num)
                {
                    i.ItemCarry -= 1; // 소지수량에서 -1

                    if (i.Type == "체력") //체력 회복약이면
                    {
                        //플레이어 HP += myList[i].ItemValue //아이템 값만큼 체력회복 
                        //플레이어의 최대체력변수도 있어야하고
                        //최대체력넘게 회복할수없게 해야함
                    }
                    else if (i.Type == "마력") //마력 회복약이면
                    {
                        //플레이어 MP += myList[i].ItemValue //아이템 값만큼 마력회복 
                        //플레이어의 최대마력변수도 있어야하고
                        //최대마력넘게 회복할수없게 해야함
                    }
                    if (i.ItemCarry == 0) //소지수량이 0이면
                    {
                        myList.Remove(i); //인벤에서 제거 
                    }
                }
            }
        }
        public void Shop()
        {
            while (true)
            {
                Console.Clear();
                ConsoleUtility.ShowTitle("■ 상 점 ■");
                Console.WriteLine("");
                ViewShop();
                Console.WriteLine("");
                Console.WriteLine("1. 구매하기\n2. 판매하기\n0. 나가기\n");
                Console.Write(">>");
                switch (ConsoleUtility.PromptMenuChoice(0, 2))
                {
                    case 0:
                        gameManager.MainMenu();
                        break;
                    case 1:
                        BuyShopItem();
                        break;
                    case 2:
                        SellShopItem();
                        break;
                }
            }
        }
        public void ViewShop()
        {
            Console.WriteLine($"소지골드 : {GameManager.player.statusList[0].Gold} G");
            Console.WriteLine("");
            for (int i = 0; i < itemList.Count; i++)
            {
                string isBuy = itemList[i].IsBuy ? "구매함" : itemList[i].Price.ToString() + "G";

                if (itemList[i].Equipment == "무역")
                { Console.WriteLine($"{i + 1}. {itemList[i].Name}| {itemList[i].Equipment} | {itemList[i].Info} |  ({itemList[i].ItemCarry}/{itemList[i].MaxItemCarry}) | {itemList[i].Price}G"); }
                else if (itemList[i].Equipment == "소모")
                {
                    Console.WriteLine($"{i + 1}. {itemList[i].Name}| {itemList[i].Equipment} | {itemList[i].Info} | ({itemList[i].ItemCarry}/{itemList[i].MaxItemCarry}) | {itemList[i].Price}G");
                }
                else //장비라면 
                { Console.WriteLine($"{i + 1}. {itemList[i].Name}+{itemList[i].Level}강 | {itemList[i].Equipment} | {itemList[i].Type} +{itemList[i].ItemValue} | {itemList[i].Info} | {isBuy}"); }
            }
        }

        public void BuyShopItem()
        {
            int choice = 0;
            while (choice >= 0)
            {
                Console.WriteLine("\n구매하실 아이템을 선택해주세요.");
                Console.Write(">>");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();

                if (choice == 0) break; //0를 입력받음 [나가기를 원함]
                else choice--; //1이상을 누름 아이템을 선택함 [아이탬목록은 0부터 시작이라서]

                Item item = itemList[choice];//선택한 아이템이
                Console.Write($"{item.Name} 을 ");
                if (item.Equipment == "무기" || item.Equipment == "장비")
                {
                    if (item.IsBuy == true) //이미 구매된 상품이라면
                    {
                        Console.WriteLine("이미 구매한거임.");
                    }
                    else if (GameManager.player.statusList[0].Gold > item.Price && item.IsBuy == false) // 구매 가능
                    {
                        Console.WriteLine("구매완료.");
                        item.IsBuy = true;
                        GameManager.player.statusList[0].Gold -= item.Price; //돈 나감
                    }
                    else if (GameManager.player.statusList[0].Gold < item.Price) // 돈 없으면
                    {
                        Console.WriteLine("님 돈 없.");
                    }
                    else // 잘못된 입력
                    {
                        Console.WriteLine("잘못된 입력.");
                    }
                }
                else if ((item.Equipment == "소모" || item.Equipment == "무역"))
                {
                    if (item.ItemCarry >= item.MaxItemCarry) //최대소지수량 일때
                    {
                        Console.WriteLine("이미 최대치임.");
                    }
                    else if (GameManager.player.statusList[0].Gold > item.Price && item.ItemCarry < item.MaxItemCarry) //중첩가능 구매시
                    {
                        Console.WriteLine("구매완료.");
                        item.ItemCarry += 1;
                        GameManager.player.statusList[0].Gold -= item.Price; //돈 나감
                    }
                    else if (GameManager.player.statusList[0].Gold < item.Price) // 돈 없으면
                    {
                        Console.WriteLine("님 돈 없.");
                    }
                }
                else // 잘못된 입력
                {
                    Console.WriteLine("잘못된 입력.");
                }
                Console.WriteLine("");
                ViewShop();
            }
        }
        public void SellShopItem()
        {
            int choice = 0;
            while (choice >= 0)
            {
                Console.WriteLine("\n구매하실 아이템을 선택해주세요.");
                Console.Write(">>");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();

                if (choice == 0) break; //0를 입력받음 [나가기를 원함]
                else choice--; //1이상을 누름 아이템을 선택함 [아이탬목록은 0부터 시작이라서]

                Item item = itemList[choice];//선택한 아이템이
                Console.Write($"{item.Name} 을 ");
                if (item.Equipment == "무기" || item.Equipment == "장비")
                {
                    if (item.IsBuy == false) //이미 판매된 상품이라면
                    {
                        Console.WriteLine("없었거나 이미 판매한거임.");
                    }
                    else if (item.IsBuy == true) // 판매 가능
                    {
                        Console.WriteLine("판매완료.");
                        item.IsBuy = false;
                        GameManager.player.statusList[0].Gold += item.Price; //돈 입금
                    }
                    else // 잘못된 입력
                    {
                        Console.WriteLine("잘못된 입력.");
                    }
                }
                else if ((item.Equipment == "소모" || item.Equipment == "무역"))
                {
                    if (item.ItemCarry == 0) //소지수량 0일때
                    {
                        Console.WriteLine("가진게 없네?.");
                    }
                    else if (item.ItemCarry < item.MaxItemCarry) //중첩가능 구매시
                    {
                        Console.WriteLine("구매완료.");
                        item.ItemCarry -= 1;
                        GameManager.player.statusList[0].Gold += item.Price; //돈 입금
                    }
                }
                else // 잘못된 입력
                {
                    Console.WriteLine("잘못된 입력.");
                }
                Console.WriteLine("");
                ViewShop();
            }
        }
    }
}
