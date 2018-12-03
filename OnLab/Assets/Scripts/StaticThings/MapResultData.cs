using System;

[Serializable]
public class MapResultData{

    public int Score { get; set; }
    public int Scarab { get; set; }

    public int Item { get; set; }
    public int ItemType { get; set; }
    
    public MapResultData()
    {
        Score = 0;
        Scarab = 0;
        Item = SharedData.notHaveItemNumber;
    }

    public MapResultData(int mapScr, int bug, int _item, int _itemType)
    {
        Score = mapScr;
        Scarab = bug;
        Item = _item;
        ItemType = _itemType;
    }
}
