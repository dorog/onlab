using UnityEngine;
using UnityEngine.UI;

public class Configuration {

    //datas for models
    public static int unit = 50;
    public static float columnGround = -90;
    public static float holeGround = -65;
    public static float risingStoneGround = -65;
    public static float stoneLifterGround = -65;
    public static float doorGround = -90;
    public static float doorEdgeGround = -90;
    public static float keyGround = -90;
    public static float trapGround = -90;
    public static float buttonGround = 0;
    public static float edgeGround = 0;
    public static float boxGround = 40;
    public static float laserGateGround = -90;
    public static float laserGateEdgeGround = -90;
    public static float laserSwitchGround = -90;

    //Configuration parameters
    public static float TimeBetweenCmds = 0.5f;
    public static float fallDistance = 100;
    public static float fallSpeedBoost = 2;
    public static float timeForAnimation = 1f;
    public static float timeForBoxMove = 0.55f;

    //GameObjects
    public static string mapGeneratorName = "MapGeneratorGO";
    public static string actionMenuName= "ActionMenuGO";
    public static string characterName = "joe_v4";
    public static string cmdPanelManagerName = "CommandPanelManager";
    public static string cmdFactoryName = "CommandFactory";
    public static string cmdPanelName = "CommandPanel";
    public static string cmdPanelBorderName = "CommandPanelBorder";
    public static string loadSceneGOName = "LoadSceneGO";
    public static string finishedPanelName = "FinishedPanel";
    public static string startButton = "StartButton";
    public static string stopButton = "StopButton";
    public static string fv1Name = "FV1";
    public static string fv2Name = "FV2";

    //Map_guide GameObjects
    public static string doorStr = "Doors";
    public static string gatesStr = "Gates";
    public static string keyStr = "Keys";

    //Icons
    public static string fv1IconLocation = "Icons/FV1";
    public static string fv2IconLocation = "Icons/FV2";
    public static string forwardIcon = "Icons/uparrow";
    public static string leftIcon = "Icons/leftarrow";
    public static string rightIcon = "Icons/rightarrow";
    public static string activateIcon = "Icons/lightbulb";
    public static string GSB_part = "Map_guide/GSB_part";
    public static string GSB_sprite = "Map_guide/GSB";
    public static string numberIcon = "Map_guide/number";

    //TXT files
    public static string slotName = "Slot0.txt";
    public static string buggSystemFile = "ScarabCmdMin.txt";

    //Scenes
    public static string resultScene = "FinishedMap";
    public static string levelOneName = "Level1";
    public static string levelTwoName = "Level2";
    public static string levelThreeName = "Level3";
    public static string levelLast = "LevelLast";
    public static string mapName = "Map_scene";
    public static bool isLoad = false;

    //Joe anims in menu
    public static string footAnimation = "foot";
    public static string lookAroundAnimation = "around";
    public static string welcomeAnimation = "hi";

    //Joe anims in game
    public static string forwardAnimation = "forward";
    public static string idleAnimation = "start";
    public static string trapAnimation = "trap";
    public static string fallAnimation = "lava";

    //Screen data
    public static int bestScreenWidth = 1920;
    public static int bestScreenHeight = 1080;

    //Speed data
    public static int minSpeed = 1;
    public static int maxSpeed = 4;
    public static int basicSpeed = 1;
    public static string speedTextText = "Speed x";

    //New
    public static int maxMap = 18;

    public static int emptySlot = 0;
    public static int notEmptySlot = 1;

    public static int hasItem = 0;
    public static int maxScarab = 3;
    public static int scarabNumberForSolved = 0;


    public static int KeyType = 1;
    public static int GemType = 2;

    public const int GemID = -4;
    public const int DoorEdgeID = -3;
    public const int KeyID = -2;
    public const int DoorID = -1;
    public const int ColumnID = 1;
    public const int EdgeID = 0;
    public const int TrapID = 2;
    public const int ButtonID = 3;
    public const int HoleID = 4;
    public const int StoneLifterID = 5;
    public const int RisingStoneID = 6;
    public const int LaserGateID = 7;
    public const int LaserGateEdgeID = 8;
    public const int LaserSwitchID = 9;
    public const int BoxID = 10;


    public enum CommandType { GoForward, TurnRight, TurnLeft, Activate, FV1, FV2, Null }

    public enum CanGoForward { OneDiff, CantGo, Go }

    public static float  hight_0_Ground = -90;

    public static CommandType chosenCommand = CommandType.Null;
    public static Image chosenImage = null;

    public static bool inStart = false;

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
