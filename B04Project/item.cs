using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Item( string _itemName, string _equipment, string _type, int _itemValue, string _info, int _price, bool _isBuy, int _itemCarry, int _maxItemCarry) //소모품 아이템 생성자
        {
            itemName = _itemName; //이름
            equipment = _equipment; //장비 부위(소모)
            type = _type;  //아이템 능력(회복력,)
            itemValue = _itemValue; // 아이템능력치
            info = _info;   // 소개
            price = _price; //가격
            isBuy = _isBuy; //구매 여부
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
        public List<Item> itemList; //전체 아이템 리스트
        public List<Item> myList; //내 보유한 리스트
        public ItemManager() //전체 아이템
        {
            itemList = new List<Item>();
            myList = new List<Item>();

            itemList.Add(new Item(0, "낡은 검    ", "무기", false, "공격력", 2, "낡은 검 입니다.", 100, true));
            itemList.Add(new Item(0, "청동 도끼  ", "무기", false, "공격력", 5, "청동 도끼 입니다.", 100, false));
            itemList.Add(new Item(0, "스파르타의 창", "무기", true, "공격력", 7, "전설의 창입니다.", 3500, true));
            itemList.Add(new Item(0, "수련자 갑옷 ", "장비", false, "방어력", 5, "수련용 갑옷입니다.", 1000, false));
            itemList.Add(new Item(0, "무쇠갑옷    ", "장비", true, "방어력", 9, "튼튼한 갑옷입니다.", 2000, true));
            itemList.Add(new Item(0, "스파르타의 갑옷", "장비", false, "방어력", 15, "전설의 갑옷입니다.", 3500, false));

            itemList.Add(new Item(0, "구매 테스트용", "무역", false, "방어력", 1, "잡탬.", 100, false));
            itemList.Add(new Item(0, "판매 테스트용", "무역", false, "방어력", 1, "잡탬.", 100, true));

            itemList.Add(new Item("소량 회복포션", "소모", "회복력", 25, "25체력 회복약.", 100, true, 1 , 10));
            itemList.Add(new Item("중량 회복포션", "소모", "회복력", 50, "50체력 회복약.", 300, false, 0, 5));
            itemList.Add(new Item("대량 회복포션", "소모", "회복력", 100, "100체력 회복약.", 1000, false, 0, 2));

            itemList.Add(new Item("소량 마나포션", "소모", "회복력", 25, "10체력 마나약.", 100, true, 1, 10));
            itemList.Add(new Item("중량 마나포션", "소모", "회복력", 50, "25체력 마나약.", 300, false, 0, 5));
            itemList.Add(new Item("대량 마나포션", "소모", "회복력", 100, "50체력 마나약.", 1000, false, 0, 2));
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
            }
            //for (int i = 0; i < myList.Count; i++)
            //{
            //    Console.WriteLine($"{myList[i].Name}"); //MyInventoryMake 확인용
            //}
        }
        public void SetMyInventory() //내인벤토리 표시
        {
            for (int i = 0; i < myList.Count; i++)
            {
                string isEquipment = myList[i].IsEquipment ? "E" : "X"; //착용된 장비면 "E" 아니면 "X"
                if (myList[i].Equipment == "무역") // 장비군이 무역탬이면 [강화,공격력,착용여부 등 표시 할 필요 없어서]
                { Console.WriteLine($"{myList[i].Name}| {myList[i].Equipment} | {myList[i].Info} | {myList[i].Price}G"); }
                else if (myList[i].Equipment == "소모") //장비군이 소모탬이면 [강화,착용여부 등 표시 할 필요 없어서]
                { Console.WriteLine($"{myList[i].Name}| {myList[i].Equipment} | {myList[i].Info} | ({myList[i].ItemCarry}/{myList[i].MaxItemCarry})"); }
                else //장비라면 
                { Console.WriteLine($"[{isEquipment}]{myList[i].Name}+{myList[i].Level}강 | {myList[i].Equipment} | {myList[i].Type} +{myList[i].ItemValue} | {myList[i].Info}"); }
            }
        }
        public void SetEquipmenty() //장비 착용부
        {
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

                myList[choice - 1].IsEquipment = !myList[choice - 1].IsEquipment; //선택장비 착용

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
                                } //중복착용 방지
                            }
                        }
                    }
                }                
            }
        }

        public void SetPotion() //내포션
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].Equipment == "소모") //장비군이 소모탬이면 [강화,착용여부 등 표시 할 필요 없어서]
                { Console.WriteLine($"{myList[i].Name}| {myList[i].Equipment} | {myList[i].Info} | ({myList[i].ItemCarry}/{myList[i].MaxItemCarry})"); }
            }
        }
        public void ViewShop()
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                string isBuy = itemList[i].IsBuy ? "구매함" : itemList[i].Price.ToString() + "G";

                if (myList[i].Equipment == "무역")
                { Console.WriteLine($"{i + 1}. {itemList[i].Name}| {itemList[i].Equipment} | {itemList[i].Info} | {isBuy}"); }
                else if (myList[i].Equipment == "소모")
                {
                    string maxCarry;
                    if (itemList[i].ItemCarry == itemList[i].MaxItemCarry) { maxCarry = "가득참"; } //포션을 최대수랑까지 구매햇다면 maxCarry = "가득참"
                    else { maxCarry = itemList[i].Price.ToString(); }
                    Console.WriteLine($"{i + 1}. {itemList[i].Name}| {itemList[i].Equipment} | {itemList[i].Info} | ({itemList[i].ItemCarry}/{itemList[i].MaxItemCarry} | {maxCarry})");
                }
                else //장비라면 
                { Console.WriteLine($"{i + 1}. {myList[i].Name}+{myList[i].Level}강 | {myList[i].Equipment} | {myList[i].Type} +{myList[i].ItemValue} | {myList[i].Info} | {isBuy}"); }
            }
        }
    }
}
