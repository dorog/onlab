using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MapGenerator : MonoBehaviour {

    private bool used;
    private GameObject door;
    private GameObject Joe;
    private int count = 1;
    // public GameObject Joe;          //ID:
    public GameObject EdgeModel;    //-1
    public GameObject brickModel;   // 0
    public GameObject doorModel;    // 1
    public GameObject KeyModel;     // 2
    public GameObject trapModel;    // 3
    public GameObject buttonModel;  // 4
    public GameObject boxModel;     // 5: box + brick under it
    private Vector3 joePosition;
    
    public int mapNumber = 1;
    GameObject parent;
    private List<GameObject> notStaticElements = new List<GameObject>();


    private int[,] actMap;
    private int[,] originalMap;

    private int EdgeChild = 3;
    private int BrickChild = 0;
    private int TrapChild = 2;
    private int ButtonChild = 1;
    private int BoxChild = 4;

    private Vector3 doorPosition;

    private List<int> notStaticElementsID = new List<int>(); //clear it ?
    private List<Vector3> notStaticElementsPosition = new List<Vector3>();
    private List<GameObject> boxes = new List<GameObject>();

    private Vector3 startPosition;

    private int charMatrixPositionX;
    private int charMatrixPositionZ;

    private int originMatrixPositionX;
    private int originMatrixPositionZ;

    // Use this for initialization
    void Start()
    {
        used = false;
        parent = GameObject.Find(Configuration.mapGeneratorName);
        mapNumber = CurrentGameDatas.mapNumber;
        Joe = GameObject.Find(Configuration.characterName);

        switch (mapNumber)
        {
            /*case 1:
                //GameObject brick = Instantiate(brickModel, new Vector3(325, -90, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                map1();
                break;
            case 2:
                map2();
                break;*/
            case 3:
                map3();
                break;
            default:
                map3();
                break;
        }
    }

    public void baseMap(int x, int z)
    {

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                Instantiate(brickModel, new Vector3(25 + i * 50, -90, 25 + j * 50), Quaternion.AngleAxis(-90, Vector3.right), parent.transform);
            }
        }
        door = Instantiate(doorModel, new Vector3(25 + x * 50, 0, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
    }

    public void map1()
    {
        for(int i=0; i<5; i++)
        {
            Instantiate(EdgeModel, new Vector3(225, 0, 225+i*50), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(3));
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Instantiate(brickModel, new Vector3(275 + i * 50, -90, 275 + j * 50), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(0));
            }
            Instantiate(brickModel, new Vector3(425 + i * 50, -90, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(0));

            Instantiate(EdgeModel, new Vector3(275 + i * 50, 0, 225), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(3));
            Instantiate(EdgeModel, new Vector3(425 + i * 50, 0, 275), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(3));
        }

        for(int i=0; i<4; i++)
        {
            Instantiate(EdgeModel, new Vector3(325 + i * 50, 0, 425), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(3));
        }

        Instantiate(EdgeModel, new Vector3(275, 0, 475), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(3));
        Instantiate(EdgeModel, new Vector3(525, 0, 375), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(3));
        map1NotStaticElements();

    }

    public void map1NotStaticElements()
    {
        CurrentGameDatas.HaveKey = false;
        count = 1;
        door = Instantiate(doorModel, new Vector3(575, 0, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
        GameObject trap = Instantiate(trapModel, new Vector3(425, -90, 375), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(2)) as GameObject;
        GameObject doorButton = Instantiate(buttonModel, new Vector3(475, 0, 375), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(1)) as GameObject;
        GameObject Key = Instantiate(KeyModel, new Vector3(275, -90, 425), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;

        notStaticElements.Add(trap);
        notStaticElements.Add(doorButton);
        notStaticElements.Add(door);
        notStaticElements.Add(Key);
    }

    public void map2()
    {
       
        for (int i = 0; i < 2; i++)
        {
                Instantiate(brickModel, new Vector3(325 + i * 50, -90, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(0));
        }
        map2NotStaticElements();
    }

    public void map2NotStaticElements()
    {
        CurrentGameDatas.HaveKey = false;
        count = 0;
        door = Instantiate(doorModel, new Vector3(475, 0, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
        GameObject Key = Instantiate(KeyModel, new Vector3(425, -90, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;

        notStaticElements.Add(door);
        notStaticElements.Add(Key);

    }

    public void map3()
    {
        try
        {
            using (StreamReader sr = new StreamReader("maps.txt")) //TODO: tobbszorozni
            {
                //Debug.Log("usingba");
                String line = sr.ReadToEnd();
                string[] datas = line.Split('\n');
                string[] charPosition = datas[0].Split(' ');

                //character position ready
                Joe.transform.position = new Vector3(Convert.ToInt32(charPosition[0]), Convert.ToInt32(charPosition[1]), Convert.ToInt32(charPosition[2]));

                string[] matrixDatas = datas[1].Split(' ');
                actMap = new int[Convert.ToInt32(matrixDatas[0]), Convert.ToInt32(matrixDatas[1])];
                originalMap = new int[Convert.ToInt32(matrixDatas[0]), Convert.ToInt32(matrixDatas[1])];

                string[] stPos = datas[2].Split(' ');
                
                startPosition = new Vector3(Convert.ToInt32(stPos[0]), 0, Convert.ToInt32(stPos[1]));

                charMatrixPositionZ = (Convert.ToInt32(stPos[1]) - Convert.ToInt32(charPosition[2])) / Configuration.unit;
                originMatrixPositionZ = charMatrixPositionZ;
                charMatrixPositionX = (Convert.ToInt32(charPosition[0]) - Convert.ToInt32(stPos[0])) / Configuration.unit;
                originMatrixPositionX = charMatrixPositionX;


                for (int i=0; i< Convert.ToInt32(matrixDatas[0]); i++)
                {

                    string[] row = datas[i+3].Split(' ');


                    for (int j=0; j< Convert.ToInt32(matrixDatas[1]); j++)
                    {

                        Vector3 placePosition = startPosition + new Vector3(Configuration.unit*j, 0, i * -1 * Configuration.unit);
                        int id = Convert.ToInt32(row[j]);
                        actMap[i,j] = id;
                        originalMap[i, j] = id;
                        switch (id)
                        {
                            case 0:
                                Instantiate(brickModel, placePosition + new Vector3(0, Configuration.brickGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(BrickChild));
                                break;
                            case 1:
                                Instantiate(EdgeModel, placePosition+new Vector3(0, Configuration.edgeGround, 0), Quaternion.AngleAxis(0, Vector3.right), parent.transform.GetChild(EdgeChild));
                                break;
                            case 2:
                                GameObject Key = Instantiate(KeyModel, placePosition+new Vector3(0, Configuration.keyGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                                notStaticElementsID.Add(2);
                                notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y+Configuration.keyGround, placePosition.z));
                                notStaticElements.Add(Key);
                                break;
                            case 3:
                                GameObject trap = Instantiate(trapModel, placePosition + new Vector3(0, Configuration.trapGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(TrapChild)) as GameObject;
                                notStaticElementsID.Add(3);
                                notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y+Configuration.trapGround, placePosition.z));
                                notStaticElements.Add(trap);
                                break;
                            case 4:
                                GameObject doorButton = Instantiate(buttonModel, placePosition + new Vector3(0, Configuration.buttonGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(ButtonChild)) as GameObject;
                                notStaticElementsID.Add(4);
                                notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y+Configuration.buttonGround, placePosition.z));
                                notStaticElements.Add(doorButton);
                                count++;
                                break;
                            case 5:
                                Instantiate(brickModel, placePosition + new Vector3(0, Configuration.brickGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(BrickChild));
                                GameObject box = Instantiate(boxModel, placePosition + new Vector3(0, Configuration.boxGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(BoxChild)) as GameObject;
                                box.GetComponent<OnePushPerRound>().x = j;
                                box.GetComponent<OnePushPerRound>().z = i;
                                //Visszaallitasnak tudnom kene hova rakjam vissza, tolas menedzseles nincs meg
                                notStaticElementsID.Add(5);
                                notStaticElementsPosition.Add(new Vector3(placePosition.x, placePosition.y + Configuration.boxGround, placePosition.z));
                                notStaticElements.Add(box);
                                boxes.Add(box);
                                break;
                            case -1:
                                door = Instantiate(doorModel, placePosition + new Vector3(0, Configuration.doorGround, 0), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                                notStaticElements.Add(door);
                                doorPosition = placePosition;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
        }
    }

    private void Update()
    {
        if (count == 0 && !used)
        {
            used = true;
            Animation anim = door.GetComponent<Animation>();
            anim.Play();
        }
    }

    public void lessCount()
    {
        count--;
        //Debug.Log(count+" c");
    }

    public void restartMap(int number)
    {
        boxes.Clear();
        charMatrixPositionX = originMatrixPositionX;
        charMatrixPositionZ = originMatrixPositionZ;
        count = 0;
        for(int i=0; i<notStaticElements.Count; i++)
        {
            GameObject.Destroy(notStaticElements[i]);
        }
        used = false;

        door = Instantiate(doorModel, doorPosition, Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
        notStaticElements.Add(door);

        for(int i=0; i<notStaticElementsID.Count; i++)
        {
            switch (notStaticElementsID[i])
            {
                case 2:
                    GameObject Key = Instantiate(KeyModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
                    notStaticElements.Add(Key);
                    break;
                case 3:
                    GameObject trap = Instantiate(trapModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(TrapChild)) as GameObject;
                    notStaticElements.Add(trap);
                    break;
                case 4:
                    GameObject doorButton = Instantiate(buttonModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(ButtonChild)) as GameObject;
                    notStaticElements.Add(doorButton);
                    count++;
                    break;
                case 5:
                    GameObject box = Instantiate(boxModel, notStaticElementsPosition[i], Quaternion.AngleAxis(-90, Vector3.right), parent.transform.GetChild(BoxChild)) as GameObject;
                    box.GetComponent<OnePushPerRound>().x = (int)(notStaticElementsPosition[i].x - startPosition.x)/Configuration.unit;
                    box.GetComponent<OnePushPerRound>().z = (int)(startPosition.z-notStaticElementsPosition[i].z)/Configuration.unit;
                    notStaticElements.Add(box);
                    boxes.Add(box);
                    break;
                default:
                    break;
            }
        }

        for(int i=0; i<originalMap.GetLength(0); i++)
        {
           for(int j=0; j<originalMap.GetLength(1); j++)
            {
                actMap[i, j] = originalMap[i, j];
            }
        }
    }

    public void RightToMove()
    {
        int x = charMatrixPositionX;
        int z = charMatrixPositionZ;
        int[] reCalc = new int[2];
        if (Joe.transform.forward == Vector3.left)
        {
            x--;
            reCalc[0] = -1;
            reCalc[1] = 0;
        }
        else if(Joe.transform.forward == Vector3.right)
        {
            x++;
            reCalc[0] = 1;
            reCalc[1] = 0;
        }
        else if (Joe.transform.forward == Vector3.back)
        {
            z++;
            reCalc[0] = 0;
            reCalc[1] = -1;
        }
        else
        {
            z--;
            reCalc[0] = 0;
            reCalc[1] = 1;
        }

        if (actMap[z, x] < 0)
        {
            return; //TODO: valami animaciot adni neki
        }
        else if (actMap[z, x] == 5) //doboz
        {
            if(actMap[z+reCalc[0], x + reCalc[1]] < 0 || actMap[z + reCalc[0], x + reCalc[1]] == 5) //static element or another box
            {
                return; //TODO: valami animaciot adni neki
            }
            //else if(actMap)
            else if(actMap[z + reCalc[0], x + reCalc[1]] == 1) //edge
            {

            }
            else if(actMap[z + reCalc[0], x + reCalc[1]]==6)
            {
                //New element
            }
            else
            {
                int i = 0;
                while (boxes[i].GetComponent<OnePushPerRound>().x != x && boxes[i].GetComponent<OnePushPerRound>().z != z) {
                    i++;
                }
                actMap[z, x] = 0; //hardcode
                actMap[z + reCalc[1], x + reCalc[0]] = 5;
                boxes[i].GetComponent<OnePushPerRound>().x += reCalc[0];
                boxes[i].GetComponent<OnePushPerRound>().z += reCalc[1];
                boxes[i].GetComponent<OnePushPerRound>().MoveToThere(Joe.transform.forward);
                Joe.GetComponent<JoeCommandControl>().GoForward();
                charMatrixPositionX = x;
                charMatrixPositionZ = z;
            }
        }
        else
        {
            Joe.GetComponent<JoeCommandControl>().GoForward();
            charMatrixPositionX = x;
            charMatrixPositionZ = z;
        }
    }
}
