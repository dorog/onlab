using UnityEngine;

public class MapCollection
{

    private static int Gem = Configuration.GemID;
    private static int DoorE = Configuration.DoorEdgeID; //DoorEdge
    private static int Key = Configuration.KeyID;
    private static int Door = Configuration.DoorID;
    private static int Column = Configuration.ColumnID;
    private static int Edge = Configuration.EdgeID;
    private static int Trap = Configuration.TrapID;
    private static int Button = Configuration.ButtonID;
    private static int Hole = Configuration.HoleID;
    private static int StoneL = Configuration.StoneLifterID;
    private static int RStone = Configuration.RisingStoneID;
    private static int LGate = Configuration.LaserGateID;
    private static int LGateE = Configuration.LaserGateEdgeID;
    private static int LSwitch = Configuration.LaserSwitchID;

    public static Map ReadMap(int number)
    {
        //Original
        switch (number)
        {
            case 1:
                return InitMap1();
            case 2:
                return InitMap2();
            case 3:
                return InitMap3();
            case 4:
                return InitMap4();
            case 5:
                return InitMap5();
            case 6:
                return InitMap6();
            case 7:
                return InitMap7();
            case 8:
                return InitMap8();
            case 9:
                return InitMap9();
            default:
                return IziMapWithGem();
                //break;
        }

        //For test
        /*switch (number)
        {
            case 9:
                return IziMapWithGem();
            default:
                return IziMapWithKey();
                //break;
        }*/
    }

    private static Map InitMap1()
    {
        Map map1 = new Map();
        map1.charPosition = new Vector3(225, 26, 325);
        map1.startPosition = new Vector3(175, 0, 475);
        map1.heigth = 7;
        map1.width = 8;
        map1.mapMatrix = new int[,]{ { Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                     { Edge,    Key,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                     { Edge,    Column,  Column,  Column,  Trap,   Button, Edge,   DoorE},
                                     { Edge,    Column,  Column,  Column,  Column,  Column,  Column,  Door},
                                     { Edge,    Column,  Column,  Column,  Column,  Edge,   Edge,   DoorE},
                                     { Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                     { Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map1.boxNumber = 0;
        map1.Scarab3PartNumber = 21;
        map1.Scarab2PartNumber = 30;
        map1.itemType = Configuration.KeyType;
        return map1;
    }

    private static Map InitMap2()
    {
        Map map2 = new Map();
        map2.charPosition = new Vector3(225, 26, 325);
        map2.startPosition = new Vector3(175, 0, 475);
        map2.heigth = 7;
        map2.width = 11;
        map2.mapMatrix = new int[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Column, Column, Column, Column,  Column,  Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Column, Column, Column, Column,  Column,  Edge,   Edge},
                                      {Edge,    Column, Column, Column, Column, Edge,   Hole,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Trap,   Edge,   Hole,   Edge,   Edge,   DoorE,  Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Key,    Button, Column, Column, Column,  Door,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   DoorE,  Edge}};
        map2.boxNumber = 2;
        map2.boxLocations = new Vector3[2] { new Vector3(425, 30, 375), new Vector3(525, 30, 375) };
        map2.Scarab3PartNumber = 43;
        map2.Scarab2PartNumber = 50;
        map2.itemType = Configuration.KeyType;
        return map2;
    }

    private static Map InitMap3()
    {
        Map map3 = new Map();
        map3.charPosition = new Vector3(275, 26, 425);
        map3.startPosition = new Vector3(175, 0, 625);
        map3.heigth = 10;
        map3.width = 11;
        map3.mapMatrix = new int[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    StoneL, Column,  Column,  Column,  Trap,   Column,  Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  Column,  Edge,   Button, Column,  Column,  Column,  Door},
                                      {Edge,    Edge,   Column,  Column,  Column,  Edge,   Hole,   Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Edge,   RStone, Edge,   Edge,   Column,  Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   RStone, Edge,   Edge,   Key,    Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   RStone, RStone, RStone, Column,  Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge} };
        map3.boxNumber = 3;
        map3.boxLocations = new Vector3[3] { new Vector3(325, 30, 425), new Vector3(375, 30, 425), new Vector3(475, 30, 325) };
        map3.Scarab3PartNumber = 37;
        map3.Scarab2PartNumber = 40;
        map3.itemType = Configuration.KeyType;
        return map3;
    }

    private static Map InitMap4()
    {
        Map map4 = new Map();
        map4.charPosition = new Vector3(225, 26, 325);
        map4.startPosition = new Vector3(175, 0, 575);
        map4.heigth = 10;
        map4.width = 10;
        map4.mapMatrix = new int[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Column,  Column,  Column,  Button, Edge},
                                      {Edge,    Edge,   Edge,   Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Column,  Column,  Column,  Button, Edge},
                                      {Edge,    Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Edge,   Edge,   Edge,   DoorE,  Edge},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Column,  Column,  Column,  Door,   Edge},
                                      {Edge,    Edge,   Edge,   Column,  Key,    Column,  Edge,   Edge,   DoorE,  Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map4.boxNumber = 0;
        map4.Scarab3PartNumber = 44;
        map4.Scarab2PartNumber = 50;
        map4.itemType = Configuration.KeyType;
        return map4;
    }

    private static Map InitMap5()
    {
        Map map5 = new Map();
        map5.charPosition = new Vector3(225, 26, 325);
        map5.startPosition = new Vector3(125, 0, 575);
        map5.heigth = 11;
        map5.width = 11;
        map5.mapMatrix = new int[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Trap,   Trap,   Key,    Button, Door},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map5.boxNumber = 4;
        map5.boxLocations = new Vector3[4] { new Vector3(325, 30, 325), new Vector3(375, 30, 325), new Vector3(375, 30, 275), new Vector3(375, 30, 375) };
        map5.Scarab3PartNumber = 69;
        map5.Scarab2PartNumber = 75;
        map5.itemType = Configuration.KeyType;
        return map5;
    }

    private static Map InitMap6()
    {
        Map map6 = new Map();
        map6.charPosition = new Vector3(225, 26, 325);
        map6.startPosition = new Vector3(175, 0, 525);
        map6.heigth = 8;
        map6.width = 11;
        map6.mapMatrix = new int[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Column,  Column,  Button, Edge,   Key,    Column,  Column,  Edge,   Edge,   Edge},
                                      {Edge,    Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge,   Edge,   DoorE},
                                      {Edge,    Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Door},
                                      {Edge,    Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  DoorE},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge},
                                      {Edge,    Edge,   Edge,   Button, Column,  Column,  Edge,   Column,  Column,  Column,  Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge} };
        map6.boxNumber = 0;
        map6.Scarab3PartNumber = 34;
        map6.Scarab2PartNumber = 40;
        map6.itemType = Configuration.KeyType;
        return map6;
    }

    private static Map InitMap7()
    {
        Map map7 = new Map();
        map7.charPosition = new Vector3(225, 26, 375);
        map7.startPosition = new Vector3(125, 0, 575);
        map7.heigth = 9;
        map7.width = 13;
        map7.mapMatrix = new int[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  StoneL, StoneL, RStone, RStone, Column,  Column,  Key,    Column,  Door},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map7.boxNumber = 5;
        map7.boxLocations = new Vector3[5] { new Vector3(275, 30, 375), new Vector3(275, 30, 425), new Vector3(275, 30, 325), new Vector3(525, 30, 375), new Vector3(575, 30, 375) };
        map7.Scarab3PartNumber = 30;
        map7.Scarab2PartNumber = 32;
        map7.itemType = Configuration.KeyType;
        return map7;
    }

    private static Map InitMap8()
    {
        Map map8 = new Map();
        map8.charPosition = new Vector3(275, 26, 375);
        map8.startPosition = new Vector3(175, 0, 575);
        map8.heigth = 9;
        map8.width = 10;
        map8.mapMatrix = new int[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Hole,   Key,    Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  RStone, Column,  StoneL, Hole,   Column,  Column,  Door},
                                      {Edge,    Edge,   Column,  Column,  Column,  Hole,   Button, Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map8.boxNumber = 4;
        map8.boxLocations = new Vector3[4] { new Vector3(375, 30, 425), new Vector3(375, 30, 325), new Vector3(325, -20, 375), new Vector3(325, 35, 375) };
        map8.Scarab3PartNumber = 40;
        map8.Scarab2PartNumber = 43;
        map8.itemType = Configuration.KeyType;
        return map8;
    }

    private static Map InitMap9()
    {
        Map map9 = new Map();
        map9.charPosition = new Vector3(275, 26, 375);
        map9.startPosition = new Vector3(-25, 0, 775);
        map9.heigth = 17;
        map9.width = 16;
        map9.mapMatrix = new int[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Column,  LSwitch,Column,  LSwitch,Column,  Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   LSwitch,Column,  Column,  Column,  LSwitch,Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Column,  Column,  Column,  Column,  Column,  LGateE, Edge,   DoorE,  Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Column,  Column,  Column,  Column,  Button,  LGate,  Gem,    Door,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Column,  Column,  Column,  Column,  Column,  LGateE, Edge,   DoorE,  Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   LSwitch,Column,  Column,  Column,  LSwitch,Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Column,  LSwitch,Column,  LSwitch,Column,  Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map9.boxNumber = 8;
        map9.boxLocations = new Vector3[8] { new Vector3(325, 0, 325), new Vector3(325, 0, 275), new Vector3(425, 0, 325), new Vector3(425, 0, 275), new Vector3(325, 0, 475), new Vector3(325, 0, 425), new Vector3(425, 0, 475), new Vector3(425, 0, 425) };
        map9.Scarab3PartNumber = 89;
        map9.Scarab2PartNumber = 95;
        map9.itemType = Configuration.GemType;
        return map9;
    }

    private static Map IziMapWithGem()
    {
        Map map9 = new Map();
        map9.charPosition = new Vector3(275, 26, 375);
        map9.startPosition = new Vector3(275, 0, 375);
        map9.heigth = 1;
        map9.width = 3;
        map9.mapMatrix = new int[,] { { Column, Gem, Door } };
        map9.boxNumber = 0;
        map9.itemType = Configuration.GemType;
        return map9;
    }

    private static Map IziMapWithKey()
    {
        Map map9 = new Map();
        map9.charPosition = new Vector3(275, 26, 375);
        map9.startPosition = new Vector3(275, 0, 375);
        map9.heigth = 1;
        map9.width = 3;
        map9.mapMatrix = new int[,] { { Column, Key, Door } };
        map9.boxNumber = 0;
        map9.itemType = Configuration.KeyType;
        return map9;
    }

    private static Map TestMap()
    {
        Map map = new Map();
        map.charPosition = new Vector3(375, 100, 325);
        map.startPosition = new Vector3(175, 0, 375);
        map.heigth = 3;
        map.width = 7;
        map.mapMatrix = new int[,] { { Column, Column, Column, Column, Column, LGateE, DoorE },
                                     { Column, Column, Hole, RStone, RStone, RStone, Door },
                                     { Column, Column, Column, Column, RStone, LGateE, DoorE}};
        map.boxNumber = 2;
        map.boxLocations = new Vector3[5] { new Vector3(325, 30, 325), new Vector3(225, 30, 325), new Vector3(475, 700, 325), new Vector3(375, 100, 325), new Vector3(375, 170, 325), };
        return map;
    }
}
