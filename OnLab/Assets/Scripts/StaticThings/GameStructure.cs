
public class GameStructure {

    static public int[] levelMapsCount = new int[] { 9, 5, 3, 1 };
    // levelMapsCount summ
    public static int maxMap = 18;

    public static int maxScarab = 3;
    public static int scarabNumberForSolved = 0;
    static public int maxPoint = 999;
    static public int maxScarabNumber = 3;
    static public int startLevel = 1;
    static public int maxLevel = 4;

    //Scenes
    public static string resultScene = "FinishedMap";
    public static string levelOneName = "Level1";
    public static string levelTwoName = "Level2";
    public static string levelThreeName = "Level3";
    public static string levelLast = "LevelLast";
    public static string mapName = "Map_scene";

    public static string GetLevelName()
    {
        switch (CurrentGameDatas.onLevel)
        {
            case 1:
                return levelOneName;
            case 2:
                return levelTwoName;
            case 3:
                return levelThreeName;
            case 4:
                return levelLast;
            default:
                return levelOneName;
        }
    }
}
