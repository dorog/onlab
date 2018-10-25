using UnityEngine;

public class MapCollection
{
    private static MapElement Gem = MapElement.Gem;
    private static MapElement DoorE = MapElement.DoorEdge; //DoorEdge
    private static MapElement Key = MapElement.Key;
    private static MapElement Door = MapElement.Door;
    private static MapElement Column = MapElement.Column;
    private static MapElement Edge = MapElement.Edge;
    private static MapElement Trap = MapElement.Trap;
    private static MapElement Button = MapElement.Button;
    private static MapElement Hole = MapElement.Hole;
    private static MapElement StoneL = MapElement.StoneLifter;
    private static MapElement RStone = MapElement.RisingStone;
    private static MapElement LGate = MapElement.LaserGate;
    private static MapElement LGateE = MapElement.LaserGateEdge;
    private static MapElement LSwitch = MapElement.LaserSwitch;

    public static Map ReadMap(int number)
    {
        /*switch (number)
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
        }*/

        //For test
        switch (number)
        {
            case 9:
                return IziMapWithGem();
            default:
                return IziMapWithKey();
                //break;
        }
    }

    private static Map InitMap1()
    {
        Map map = new Map();
        map.charPosition = new Vector3(225, 26, 325);
        map.startPosition = new Vector3(175, 0, 475);
        map.mapMatrix = new MapElement[,]{ { Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                     { Edge,    Key,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                     { Edge,    Column,  Column,  Column,  Trap,   Button, Edge,   DoorE},
                                     { Edge,    Column,  Column,  Column,  Column,  Column,  Column,  Door},
                                     { Edge,    Column,  Column,  Column,  Column,  Edge,   Edge,   DoorE},
                                     { Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                     { Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.Scarab3PartNumber = 21;
        map.Scarab2PartNumber = 30;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap2()
    {
        Map map = new Map();
        map.charPosition = new Vector3(225, 26, 325);
        map.startPosition = new Vector3(175, 0, 475);
        map.heigth = 7;
        map.width = 11;
        map.mapMatrix = new MapElement[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Column, Column, Column, Column,  Column,  Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Column, Column, Column, Column,  Column,  Edge,   Edge},
                                      {Edge,    Column, Column, Column, Column, Edge,   Hole,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Trap,   Edge,   Hole,   Edge,   Edge,   DoorE,  Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Key,    Button, Column, Column, Column,  Door,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   DoorE,  Edge}};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 2;
        map.boxLocations = new Vector3[2] { new Vector3(425, 30, 375), new Vector3(525, 30, 375) };
        map.Scarab3PartNumber = 43;
        map.Scarab2PartNumber = 50;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap3()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 425);
        map.startPosition = new Vector3(175, 0, 625);
        map.mapMatrix = new MapElement[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    StoneL, Column,  Column,  Column,  Trap,   Column,  Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  Column,  Edge,   Button, Column,  Column,  Column,  Door},
                                      {Edge,    Edge,   Column,  Column,  Column,  Edge,   Hole,   Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Edge,   RStone, Edge,   Edge,   Column,  Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   RStone, Edge,   Edge,   Key,    Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   RStone, RStone, RStone, Column,  Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge} };
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 3;
        map.boxLocations = new Vector3[3] { new Vector3(325, 30, 425), new Vector3(375, 30, 425), new Vector3(475, 30, 325) };
        map.Scarab3PartNumber = 37;
        map.Scarab2PartNumber = 40;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap4()
    {
        Map map = new Map();
        map.charPosition = new Vector3(225, 26, 325);
        map.startPosition = new Vector3(175, 0, 575);
        map.mapMatrix = new MapElement[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Column,  Column,  Column,  Button, Edge},
                                      {Edge,    Edge,   Edge,   Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Column,  Column,  Column,  Button, Edge},
                                      {Edge,    Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Edge,   Edge,   Edge,   DoorE,  Edge},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Column,  Column,  Column,  Door,   Edge},
                                      {Edge,    Edge,   Edge,   Column,  Key,    Column,  Edge,   Edge,   DoorE,  Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.Scarab3PartNumber = 44;
        map.Scarab2PartNumber = 50;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap5()
    {
        Map map = new Map();
        map.charPosition = new Vector3(225, 26, 325);
        map.startPosition = new Vector3(125, 0, 575);
        map.mapMatrix = new MapElement[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
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
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 4;
        map.boxLocations = new Vector3[4] { new Vector3(325, 30, 325), new Vector3(375, 30, 325), new Vector3(375, 30, 275), new Vector3(375, 30, 375) };
        map.Scarab3PartNumber = 69;
        map.Scarab2PartNumber = 75;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap6()
    {
        Map map = new Map();
        map.charPosition = new Vector3(225, 26, 325);
        map.startPosition = new Vector3(175, 0, 525);
        map.mapMatrix = new MapElement[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Column,  Column,  Button, Edge,   Key,    Column,  Column,  Edge,   Edge,   Edge},
                                      {Edge,    Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge,   Edge,   DoorE},
                                      {Edge,    Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Door},
                                      {Edge,    Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  DoorE},
                                      {Edge,    Edge,   Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge,   Column,  Edge},
                                      {Edge,    Edge,   Edge,   Button, Column,  Column,  Edge,   Column,  Column,  Column,  Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge} };
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.Scarab3PartNumber = 34;
        map.Scarab2PartNumber = 40;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap7()
    {
        Map map = new Map();
        map.charPosition = new Vector3(225, 26, 375);
        map.startPosition = new Vector3(125, 0, 575);
        map.mapMatrix = new MapElement[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  StoneL, StoneL, RStone, RStone, Column,  Column,  Key,    Column,  Door},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 5;
        map.boxLocations = new Vector3[5] { new Vector3(275, 30, 375), new Vector3(275, 30, 425), new Vector3(275, 30, 325), new Vector3(525, 30, 375), new Vector3(575, 30, 375) };
        map.Scarab3PartNumber = 30;
        map.Scarab2PartNumber = 32;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap8()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(175, 0, 575);
        map.mapMatrix = new MapElement[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Column,  Column,  Column,  Hole,   Key,    Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  RStone, Column,  StoneL, Hole,   Column,  Column,  Door},
                                      {Edge,    Edge,   Column,  Column,  Column,  Hole,   Button, Edge,   Edge,   DoorE},
                                      {Edge,    Edge,   Column,  Column,  Column,  Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 4;
        map.boxLocations = new Vector3[4] { new Vector3(375, 30, 425), new Vector3(375, 30, 325), new Vector3(325, -20, 375), new Vector3(325, 35, 375) };
        map.Scarab3PartNumber = 40;
        map.Scarab2PartNumber = 43;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap9()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(-25, 0, 775);
        map.mapMatrix = new MapElement[,] { {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge},
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
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 8;
        map.boxLocations = new Vector3[8] { new Vector3(325, 0, 325), new Vector3(325, 0, 275), new Vector3(425, 0, 325), new Vector3(425, 0, 275), new Vector3(325, 0, 475), new Vector3(325, 0, 425), new Vector3(425, 0, 475), new Vector3(425, 0, 425) };
        map.Scarab3PartNumber = 89;
        map.Scarab2PartNumber = 95;
        map.itemType = SharedData.GemType;
        return map;
    }

    private static Map IziMapWithGem()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(275, 0, 375);
        map.mapMatrix = new MapElement[,] { { Column, Gem, Door } };
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.itemType = SharedData.GemType;
        return map;
    }

    private static Map IziMapWithKey()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(275, 0, 375);
        map.mapMatrix = new MapElement[,] { { Column, Key, Door } };
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map TestMap()
    {
        Map map = new Map();
        map.charPosition = new Vector3(375, 100, 325);
        map.startPosition = new Vector3(175, 0, 375);
        map.mapMatrix = new MapElement[,] { { Column, Column, Column, Column, Column, LGateE, DoorE },
                                     { Column, Column, Hole, RStone, RStone, RStone, Door },
                                     { Column, Column, Column, Column, RStone, LGateE, DoorE}};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 2;
        map.boxLocations = new Vector3[5] { new Vector3(325, 30, 325), new Vector3(225, 30, 325), new Vector3(475, 700, 325), new Vector3(375, 100, 325), new Vector3(375, 170, 325), };
        return map;
    }
}
