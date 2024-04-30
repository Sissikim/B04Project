namespace B04Project
{
    internal class Player
    {
        public string Name { get; }
        public string Chad { get; }
        public int Lv { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; set; }

        public Player(string name, string chad, int lv, int atk, int def, int hp, int gold)
        {
            Name = name;
            Chad = chad;
            Lv = lv;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
}