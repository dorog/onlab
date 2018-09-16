using UnityEngine;

public class Configuration {

    //datas for models
    public static int unit = 50;
    public static float brickGround = -90;
    public static float holeGround = -65;
    public static float bridgeElementGround = -65;
    public static float bridgeMakeGround = -65;
    public static float doorGround = 0;
    public static float doorEdgeGround = -90;
    public static float keyGround = -90;
    public static float trapGround = -90;
    public static float buttonGround = 0;
    public static float edgeGround = 0;
    public static float boxGround = 40;
    public static float laserGateGround = -90;
    public static float laserGateEdgeGround = -90;
    public static float laserSwitchGround = -40;

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
    public static string mapGuideScene = "Map_guide";
    public static string mapScene = "Map_scene";
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
    public static int speed = 1;
    public static int minSpeed = 1;
    public static int maxSpeed = 4;
    public static int basicSpeed = 1;
    public static string speedTextText = "Speed x";
}
