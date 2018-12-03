using UnityEngine;

public class SharedData
{

    public static int widhtUnit = 50;
    public static int heightUnit = 50;

    public static float fallDistance = 100;
    public static float timeForAnimation = 1f;

    //Icons
    public static string fv1Icon = "Icons/FV1";
    public static string fv2Icon = "Icons/FV2";
    public static string forwardIcon = "Icons/uparrow";
    public static string leftIcon = "Icons/leftarrow";
    public static string rightIcon = "Icons/rightarrow";
    public static string activateIcon = "Icons/lightbulb";

    public static string columnIcon = "Icons/MapElements/columnIcon";
    public static string boxIcon = "Icons/MapElements/boxIcon";
    public static string buttonIcon = "Icons/MapElements/buttonIcon";
    public static string doorIcon = "Icons/MapElements/doorIcon";
    public static string gemIcon = "Icons/MapElements/gemIcon";
    public static string holeIcon = "Icons/MapElements/holeIcon";
    public static string keyIcon = "Icons/MapElements/keyIcon";
    public static string laserGateIcon = "Icons/MapElements/laserGateIcon";
    public static string laserSwitchIcon = "Icons/MapElements/laserSwitchIcon";
    public static string relicIcon = "Icons/MapElements/relicIcon";
    public static string risingStoneIcon = "Icons/MapElements/risingStoneIcon";
    public static string stoneLifterIcon = "Icons/MapElements/stoneLifterIcon";
    public static string trapIcon = "Icons/MapElements/trapIcon";
    public static string joeIcon = "Icons/MapElements/joeIcon";

    //Speed data
    public static int minSpeed = 1;
    public static int maxSpeed = 4;
    public static int basicSpeed = 1;

    public static int DefaultType = 0;
    public static int KeyType = 1;
    public static int GemType = 2;
    public static int RelicType = 3;

    public static float hight_0_Ground = -90;

    public static int emptyCommandID = -1;
    public static int realCommandID = 1;

    public static string playerTag = "Player";

    public static int notHaveItemNumber = 0;
    public static int HaveItemNumber = 1;

    public static string deviceCreatedMapFileLocation = "/createdMaps.bat";
}
