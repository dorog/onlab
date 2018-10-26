using System;

[Serializable]
public class MapData{

    public int Score { get; set; }
    public int Scarab { get; set; }

    public int Item { get; set; }
    public int ItemType { get; set; }
    
    public MapData()
    {
        Score = 0;
        Scarab = 0;
        Item = SharedData.notHaveItemNumber;
    }

    public MapData(int mapScr, int bug, int _item, int _itemType)
    {
        Score = mapScr;
        Scarab = bug;
        Item = _item;
        ItemType = _itemType;
    }
}
