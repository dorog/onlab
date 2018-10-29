using UnityEngine;

public class MapCollection
{
    private static MapElement Gem = MapElement.Gem;
    private static MapElement DoorE = MapElement.DoorEdge;
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
    private static MapElement Relic = MapElement.Relic;
    private static MapElement LRStone = MapElement.LowRisingStone;

    public static Map ReadMap(int number)
    {
        Map chosedMap;

        switch (number)
        {
            case 1:
                chosedMap = InitMap1();
                break;
            case 2:
                chosedMap = InitMap2();
                break;
            case 3:
                chosedMap = InitMap3();
                break;
            case 4:
                chosedMap = InitMap4();
                break;
            case 5:
                chosedMap = InitMap5();
                break;
            case 6:
                chosedMap = InitMap6();
                break;
            case 7:
                chosedMap = InitMap7();
                break;
            case 8:
                chosedMap = InitMap8();
                break;
            case 9:
                chosedMap = InitMap9();
                break;
            case 10:
                chosedMap = InitMap10();
                break;
            case 11:
                chosedMap = InitMap11();
                break;
            case 12:
                chosedMap = InitMap12();
                break;
            case 13:
                chosedMap = InitMap13();
                break;
            case 14:
                chosedMap = InitMap14();
                break;
            case 15:
                chosedMap = InitMap15();
                break;
            case 16:
                chosedMap = InitMap16();
                break;
            case 17:
                chosedMap = InitMap17();
                break;
            case 18:
                chosedMap = InitMap18();
                break;
            default:
                chosedMap = MaxSizeMap();
                break;
        }

        CalculateItems(chosedMap);

        return chosedMap;

        //For test

        /*switch (number)
        {
            case 1:
                chosedMap =  IziMapWithGem();
                break;
            case 2:
                chosedMap = IziMapWithKey();
                break;
            default:
                chosedMap = IziMapWithRelic();
                break;
        }

        CalculateItems(chosedMap);

        return chosedMap;*/
    }

    private static Map InitMap1()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(225, 0, 475);
        map.mapMatrix = new MapElement[,] { { Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge },
                                            { Edge, Column, Column, Column, Edge, Edge, DoorE },
                                            { Edge, Column, Column, Column, Button, Key, Door },
                                            { Edge, Column, Column, Column, Edge, Edge, DoorE },
                                            { Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge, }};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.Scarab3PartNumber = 7;
        map.Scarab2PartNumber = 8;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap2()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(225, 0, 475);
        map.mapMatrix = new MapElement[,] { { Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge },
                                            { Edge, Column, Column, Column, Edge, Edge, DoorE },
                                            { Edge, Column, Trap,   Column, Column, Key, Door },
                                            { Edge, Column, Column, Column, Edge, Edge, DoorE },
                                            { Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge, }};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.Scarab3PartNumber = 12;
        map.Scarab2PartNumber = 14;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap3()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(225, 0, 525);
        map.mapMatrix = new MapElement[,] { { Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge },
                                            { Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge, },
                                            { Edge, Column, Column, Hole,   Edge, Edge, DoorE },
                                            { Edge, Column, Column, Hole,   Column, Key, Door },
                                            { Edge, Column, Column, Hole,   Edge, Edge, DoorE },
                                            { Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge, },
                                            { Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge, }};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 1;
        map.boxLocations = new Vector3[1] { new Vector3(325, 30, 375) };
        map.Scarab3PartNumber = 6;
        map.Scarab2PartNumber = 8;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap4()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(175, 0, 525);
        map.mapMatrix = new MapElement[,] { {  Edge, Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge },
                                            {  Edge, Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge, },
                                            {  Edge, StoneL, Column, Column, RStone,   Edge, Edge, DoorE },
                                            {  Edge, Edge, Column, Column, RStone,   Column, Key, Door },
                                            {  Edge, Edge, Column, Column, RStone,   Edge, Edge, DoorE },
                                            {  Edge, Edge, Edge,   Edge,   Edge,   Edge, Edge, Edge, }};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 1;
        map.boxLocations = new Vector3[1] { new Vector3(275, 30, 425) };
        map.Scarab3PartNumber = 16;
        map.Scarab2PartNumber = 18;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap5()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(175, 0, 525);
        map.mapMatrix = new MapElement[,] { { Edge, Edge, Edge,   Edge,   Edge,   Edge,   Edge, Edge },
                                            { Edge, Edge, Edge,   Edge,   Edge,   Edge,   Edge, Edge },
                                            { Edge, Edge, Column, Column, Column, LGateE, Edge, DoorE },
                                            { Edge, Edge, Column, Column, Column, LGate,  Key,  Door },
                                            { Edge, Edge, Column, LSwitch,Column, LGateE, Edge, DoorE },
                                            { Edge, Edge, Edge,   Edge,   Edge,   Edge,   Edge, Edge },
                                            { Edge, Edge, Edge,   Edge,   Edge,   Edge,   Edge, Edge }};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 1;
        map.boxLocations = new Vector3[1] { new Vector3(325, 30, 375) };
        map.Scarab3PartNumber = 16;
        map.Scarab2PartNumber = 18;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap6()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 225);
        map.startPosition = new Vector3(225, 0, 475);
        map.mapMatrix = new MapElement[,] {{ Edge, Edge,   Edge,   Edge,   Edge, Edge },
                                           { Edge, Button, Button, Button, Edge, Edge,},
                                           { Edge, Button, Button, Button, Edge, DoorE},
                                           { Edge, Button, Button, Button, Key,  Door},
                                           { Edge, Button, Button, Button, Edge, DoorE},
                                           { Edge, Button, Button, Button, Edge, Edge,},
                                           { Edge, Edge,   Edge,   Edge,   Edge, Edge,} };
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.Scarab3PartNumber = 27;
        map.Scarab2PartNumber = 30;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap7()
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

    private static Map InitMap8()
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

    private static Map InitMap9()
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
                                      {Edge,    Edge,   Edge,   Column,  Relic,    Column,  Edge,   Edge,   DoorE,  Edge},
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge,   Edge}};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.Scarab3PartNumber = 44;
        map.Scarab2PartNumber = 50;
        map.itemType = SharedData.RelicType;
        return map;
    }

    private static Map InitMap10()
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

    private static Map InitMap11()
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

    private static Map InitMap12()
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

    private static Map InitMap13()
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

    private static Map InitMap14()
    {
        Map map = new Map();
        map.charPosition = new Vector3(525, 180, 325);
        map.startPosition = new Vector3(275, 0, 475);
        map.mapMatrix = new MapElement[,] { { Edge, Edge, Edge,    Edge,    Edge,    Edge,      Edge },
                                            { Edge, Edge, Button,  Edge,    Edge,    StoneL,    Edge },
                                            { Edge, Edge, LRStone, Button,  Edge,    DoorE,     Edge },
                                            { Edge, Relic,  LRStone, Edge,    LRStone, Door,      Edge },
                                            { Edge, Edge, LRStone, LRStone, LRStone, DoorE,     Edge },
                                            { Edge, Edge, Edge,    Button,  Edge,    StoneL,    Edge },
                                            { Edge, Edge, Edge,    Edge,    Edge,    Edge,      Edge }};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 2;
        map.boxLocations = new Vector3[2] { new Vector3(525, 180, 375), new Vector3(525, 180, 275)};
        map.Scarab3PartNumber = 48;
        map.Scarab2PartNumber = 52;
        map.itemType = SharedData.RelicType;
        return map;
    }

    private static Map InitMap15()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(25, 0, 625);
        map.mapMatrix = new MapElement[,] { { Edge, Edge, Edge, Edge, Edge, Edge,   Edge,   Edge,   Edge, Edge,   Edge, Edge, Edge },
                                            { Edge, Edge, Edge, Edge, Edge, Edge,   Edge,   Edge,   Edge,  Edge,   Edge, Edge, Edge },
                                            { Edge, Edge, Edge, Edge, Edge, Edge,   Edge,   Edge,   Edge,  Edge,   Edge, Edge, Edge },
                                            { Edge, Edge, Edge, Edge, Column, Column, LSwitch,Column, Column, StoneL, Edge, Edge, Edge },
                                            { Edge, Edge, Edge, Edge, Column, LSwitch,Column, Column, RStone, RStone, LGateE, Edge, DoorE },
                                            { Edge, Edge, Edge, StoneL,Column, Column, StoneL, RStone, RStone, RStone, LGate,Key, Door },
                                            { Edge, Edge, Edge, Edge, Column, LSwitch,Column, Column, RStone, RStone, LGateE, Edge, DoorE },
                                            { Edge, Edge, Edge, Edge, Column, Column, LSwitch,Column, Column, StoneL, Edge, Edge, Edge },
                                            { Edge, Edge, Edge, Edge, Edge, Edge,   Edge,   Edge,   Edge, Edge,   Edge, Edge, Edge },
                                            { Edge, Edge, Edge, Edge, Edge, Edge,   Edge,   Edge,   Edge, Edge,   Edge, Edge, Edge },
                                            { Edge, Edge, Edge, Edge, Edge, Edge,   Edge,   Edge,   Edge, Edge,   Edge, Edge, Edge } };
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 4;
        map.boxLocations = new Vector3[4] { new Vector3(225, 30, 375), new Vector3(375, 30, 375), new Vector3(375, 30, 425), new Vector3(375, 30, 325) };
        map.Scarab3PartNumber = 46;
        map.Scarab2PartNumber = 50;
        map.itemType = SharedData.KeyType;
        return map;
    }

    private static Map InitMap16()
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

    private static Map InitMap17()
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
                                      {Edge,    Edge,   Edge,   Edge,   Edge,   Edge,   Column,  Column,  Column,  Column,  Button,  LGate,  Relic,    Door,   Edge,   Edge},
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
        map.itemType = SharedData.RelicType;
        return map;
    }

    private static Map InitMap18()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(225, 0, 425);
        map.mapMatrix = new MapElement[,] { { Edge, Edge, Edge, DoorE },
                                            { Edge, Column, Gem, Door },
                                            { Edge, Edge, Edge, DoorE } };
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.Scarab3PartNumber = 100;
        map.Scarab2PartNumber = 200;
        map.boxNumber = 0;
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

    private static Map IziMapWithRelic()
    {
        Map map = new Map();
        map.charPosition = new Vector3(275, 26, 375);
        map.startPosition = new Vector3(275, 0, 375);
        map.mapMatrix = new MapElement[,] { { Column, Relic, Door } };
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        map.itemType = SharedData.RelicType;
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

    private static Map MaxSizeMap()
    {
        Map map = new Map();
        map.charPosition = new Vector3(375, 100, 325);
        map.startPosition = new Vector3(175, 0, 525);
        map.mapMatrix = new MapElement[,] { { Column, Column, Column, Column, Column, Column, Column, Column, Column, Column },
                                            { Column, Column, Column, Column, Column, Column, Column, Column, Column, Column },
                                            { Column, Column, Column, Column, Column, Column, Column, Column, Column, Column },
                                            { Column, Column, Column, Column, Column, Column, Column, Column, Column, Column },
                                            { Column, Column, Column, Column, Column, Column, Column, Column, Column, Column },
                                            { Column, Column, Column, Column, Column, Column, Column, Column, Column, Column },
                                            { Column, Column, Column, Column, Column, Column, Column, Column, Column, Column },
                                            { Column, Column, Column, Column, Column, Column, Column, Column, Column, Column }};
        map.heigth = map.mapMatrix.GetLength(0);
        map.width = map.mapMatrix.GetLength(1);
        map.boxNumber = 0;
        return map;
    }

    public static void CalculateItems(Map map)
    {
        for (int i = 0; i < map.heigth; i++)
        {
            for (int j = 0; j < map.width; j++)
            {
                if(map.mapMatrix[i, j] == Button)
                {
                    map.buttonCount++;
                }
                else if(map.mapMatrix[i, j] == LSwitch)
                {
                    map.laserSwitchCount++;
                }
            }
        }
    }
}
