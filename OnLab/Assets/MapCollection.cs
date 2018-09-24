using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCollection {

    public static Map ReadMap(int number)
    {
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
                //return InitMap9();
                return Izi();
            default:
                return InitMap1();
                //break;
        }
    }

    private static Map InitMap1()
    {
        Map map1 = new Map();
        map1.charPosition = new Vector3(225, 26, 325);
        map1.startPosition = new Vector3(175, 0, 475);
        map1.heigth = 7;
        map1.width = 8;
        map1.mapMatrix = new int[,]{ { 1, 1, 1, 1, 1, 1, 1, 1},  
                                     { 1, -2, 1, 1, 1, 1, 1, 1},
                                     { 1, 0, 0, 0, 2, 3, 1, -3},
                                     { 1, 0, 0, 0, 0, 0, 0, -1},
                                     { 1, 0, 0, 0, 0, 1, 1, -3},
                                     { 1, 1, 1, 1, 1, 1, 1, 1},
                                     { 1, 1, 1, 1, 1, 1, 1, 1} };
        map1.boxNumber = 0;
        map1.Scarab3PartNumber = 21;
        map1.Scarab2PartNumber = 30;
        map1.itemType = 1;
        return map1;
    }

    private static Map InitMap2()
    {
        Map map2 = new Map();
        map2.charPosition = new Vector3(225, 26, 325);
        map2.startPosition = new Vector3(175, 0, 475);
        map2.heigth = 7;
        map2.width = 12;
        map2.mapMatrix = new int[,] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1},
                                      {1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1},
                                      {1, 0, 0, 0, 0, 1, 4, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 2, 1, 4, 1, 1, 1, -3, 1},
                                      {1, 1, 1, 1, -2, 3, 0, 0, 0, -1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -3, 1}};
        map2.boxNumber = 2;
        map2.boxLocations = new Vector3[2]{ new Vector3(425, 30, 375), new Vector3(525, 30, 375)};
        map2.Scarab3PartNumber = 43;
        map2.Scarab2PartNumber = 50;
        map2.itemType = 1;
        return map2;
    }

    private static Map InitMap3()
    {
        Map map3 = new Map();
        map3.charPosition = new Vector3(275, 26, 425);
        map3.startPosition = new Vector3(175, 0, 625);
        map3.heigth = 10;
        map3.width = 11;
        map3.mapMatrix = new int[,] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 5, 0, 0, 0, 2, 0, 1, 1, 1, -3},
                                      {1, 1, 0, 0, 0, 1, 3, 0, 0, 0, -1},
                                      {1, 1, 0, 0, 0, 1, 4, 1, 1, 1, -3},
                                      {1, 1, 1, 6, 1, 1, 0, 1, 1, 1, 1},
                                      {1, 1, 1, 6, 1, 1, -2, 1, 1, 1, 1},
                                      {1, 1, 1, 6, 6, 6, 0, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
        map3.boxNumber = 3;
        map3.boxLocations = new Vector3[3] {new Vector3(325, 30, 425), new Vector3(375, 30, 425), new Vector3(475, 30, 325) };
        map3.Scarab3PartNumber = 40;
        map3.Scarab2PartNumber = 45;
        map3.itemType = 1;
        return map3;
    }

    private static Map InitMap4()
    {
        Map map4 = new Map();
        map4.charPosition = new Vector3(225, 26, 325);
        map4.startPosition = new Vector3(175, 0, 575);
        map4.heigth = 10;
        map4.width = 10;
        map4.mapMatrix = new int[,] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 0, 0, 0, 3, 1},
                                      {1, 1, 1, 0, 0, 0, 1, 1, 1, 1},
                                      {1, 1, 1, 0, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 0, 1, 0, 0, 0, 3, 1},
                                      {1, 0, 0, 0, 0, 0, 1, 1, 1, 1},
                                      {1, 1, 1, 0, 1, 1, 1, 1, -3, 1},
                                      {1, 1, 1, 0, 1, 0, 0, 0, -1, 1},
                                      {1, 1, 1, 0, -2, 0, 1, 1, -3, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
        map4.boxNumber = 0;
        map4.Scarab3PartNumber = 62;
        map4.Scarab2PartNumber = 65;
        map4.itemType = 1;
        return map4;
    }

    private static Map InitMap5()
    {
        Map map5 = new Map();
        map5.charPosition = new Vector3(225, 26, 325);
        map5.startPosition = new Vector3(125, 0, 575);
        map5.heigth = 11;
        map5.width = 11;
        map5.mapMatrix = new int[,] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1},
                                      {1, 1, 0, 0, 0, 0, 1, 1, 1, 1, -3},
                                      {1, 1, 0, 0, 0, 0, 2, 2, -2, 3, -1},
                                      {1, 1, 0, 0, 0, 0, 1, 1, 1, 1, -3},
                                      {1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
        map5.boxNumber = 4;
        map5.boxLocations = new Vector3[4] { new Vector3(325, 30, 325), new Vector3(375, 30, 325), new Vector3(375, 30, 275), new Vector3(375, 30, 375)};
        map5.Scarab3PartNumber = 69;
        map5.Scarab2PartNumber = 80;
        map5.itemType = 1;
        return map5;
    }

    private static Map InitMap6()
    {
        Map map6 = new Map();
        map6.charPosition = new Vector3(225, 26, 325);
        map6.startPosition = new Vector3(175, 0, 525);
        map6.heigth = 8;
        map6.width = 11;
        map6.mapMatrix = new int[,] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 0, 0, 3, 1, -2, 0, 0, 1, 1, 1},
                                      {1, 0, 1, 0, 1, 0, 1, 0, 1, 1, -3},
                                      {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, -1},
                                      {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, -3},
                                      {1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1},
                                      {1, 1, 1, 3, 0, 0, 1, 0, 0, 0, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
        map6.boxNumber = 0;
        map6.Scarab3PartNumber = 62;
        map6.Scarab2PartNumber = 65;
        map6.itemType = 1;
        return map6;
    }

    private static Map InitMap7()
    {
        Map map7 = new Map();
        map7.charPosition = new Vector3(225, 26, 375);
        map7.startPosition = new Vector3(125, 0, 575);
        map7.heigth = 9;
        map7.width = 13;
        map7.mapMatrix = new int[,] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, -3},
                                      {1, 1, 0, 0, 5, 5, 6, 6, 0, 0, -2, 0, -1},
                                      {1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, -3},
                                      {1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
        map7.boxNumber = 5;
        map7.boxLocations = new Vector3[5] { new Vector3(275, 30, 375), new Vector3(275, 30, 425), new Vector3(275, 30, 325), new Vector3(525, 30, 375), new Vector3(575, 30, 375)};
        map7.Scarab3PartNumber = 31;
        map7.Scarab2PartNumber = 32;
        map7.itemType = 1;
        return map7;
    }

    private static Map InitMap8()
    {
        Map map8 = new Map();
        map8.charPosition = new Vector3(275, 26, 375);
        map8.startPosition = new Vector3(175, 0, 575);
        map8.heigth = 9;
        map8.width = 10;
        map8.mapMatrix = new int[,] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 0, 0, 0, 1, 1, 1, 1, 1},
                                      {1, 1, 0, 0, 0, 4, -2, 1, 1, -3},
                                      {1, 1, 0, 6, 0, 5, 4, 0, 0, -1},
                                      {1, 1, 0, 0, 0, 4, 3, 1, 1, -3},
                                      {1, 1, 0, 0, 0, 1, 1, 1, 1, 1,},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
        map8.boxNumber = 4;
        map8.boxLocations = new Vector3[4] { new Vector3(375, 30, 425), new Vector3(375, 30, 325), new Vector3(325, -20, 375), new Vector3(325, 35, 375)};
        map8.Scarab3PartNumber = 40;
        map8.Scarab2PartNumber = 43;
        map8.itemType = 1;
        return map8;
    }

    private static Map InitMap9()
    {
        Map map9 = new Map();
        map9.charPosition = new Vector3(275, 26, 375);
        map9.startPosition = new Vector3(-25, 0, 775);
        map9.heigth = 17;
        map9.width = 16;
        map9.mapMatrix = new int[,] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 0, 9, 0, 9, 0, 1, 1, 1, 1, 1,},
                                      {1, 1, 1, 1, 1, 1, 9, 0, 0, 0, 9, 1, 1, 1, 1, 1,},
                                      {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 8, 1, -3, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 7, -4, -1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 8, 1, -3, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 9, 0, 0, 0, 9, 1, 1, 1, 1, 1,},
                                      {1, 1, 1, 1, 1, 1, 0, 9, 0, 9, 0, 1, 1, 1, 1, 1,},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                      {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
        map9.boxNumber = 8;
        map9.boxLocations = new Vector3[8] { new Vector3(325, 0, 325), new Vector3(325, 0, 275), new Vector3(425, 0, 325), new Vector3(425, 0, 275), new Vector3(325, 0, 475), new Vector3(325, 0, 425), new Vector3(425, 0, 475), new Vector3(425, 0, 425) };
        map9.Scarab3PartNumber = 88;
        map9.Scarab2PartNumber = 95;
        map9.itemType = 2;
        return map9;
    }

    private static Map Izi()
    {
        Map map9 = new Map();
        map9.charPosition = new Vector3(275, 26, 375);
        map9.startPosition = new Vector3(275, 0, 375);
        map9.heigth = 1;
        map9.width = 3;
        map9.mapMatrix = new int[,] { { 0, -2, -1 } };
        map9.boxNumber = 0;
        return map9;
    }
}
