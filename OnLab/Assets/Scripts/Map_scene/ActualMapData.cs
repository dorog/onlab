using UnityEngine.UI;

public class ActualMapData {

    static public int mapNumber = 7;
    static public int Scarab3PartCmd;
    static public int Scarab2PartCmd;
    static public bool HaveItem = false;
    static public bool HawNewItem = false;

    static public MapData solvedMap = new MapData();

    public static CommandType chosenCommand = CommandType.Null;
    public static Image chosenImage = null;
}
