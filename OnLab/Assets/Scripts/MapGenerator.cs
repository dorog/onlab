using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    private bool used;
    private GameObject door;
    private int count = 1;
    public GameObject buttonModel;
    public GameObject doorModel;
    public GameObject brickModel;
    public GameObject trapModel;
    public int mapNumber = 1;
    GameObject parent;
    private List<GameObject> notStaticElements = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        used = false;
        parent = GameObject.Find("MapGeneratorGO");
        mapNumber = CurrentGameDatas.mapNumber;

        switch (mapNumber)
        {
            case 1:
                map1();
                break;
            default:
                baseMap(10, 10);
                break;
        }
    }

    public void baseMap(int x, int z)
    {

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                GameObject brick = Instantiate(brickModel, new Vector3(25 + i * 50, 0, 25 + j * 50), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
            }
        }
        door = Instantiate(doorModel, new Vector3(25 + x * 50, 0, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
    }

    public void map1()
    {
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject brick = Instantiate(brickModel, new Vector3(275 + i * 50, 0, 275 + j * 50), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
            }
            GameObject brick2 = Instantiate(brickModel, new Vector3(425 + i * 50, 0, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
        }

        map1NotStaticElements();

    }

    public void map1NotStaticElements()
    {
        count = 1;
        door = Instantiate(doorModel, new Vector3(575, 0, 325), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
        GameObject trap = Instantiate(trapModel, new Vector3(425, 10, 375), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
        GameObject doorButton = Instantiate(buttonModel, new Vector3(475, 0, 375), Quaternion.AngleAxis(-90, Vector3.right), parent.transform) as GameObject;
        
        notStaticElements.Add(trap);
        notStaticElements.Add(doorButton);
        notStaticElements.Add(door);
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
        //Debug.Log(count);
    }

    public void restartMap(int number)
    {
        for(int i=0; i<notStaticElements.Count; i++)
        {
            GameObject.Destroy(notStaticElements[i]);
        }
        used = false;

        switch (number)
        {
            case 1:
                map1NotStaticElements();
                break;
            default:
                baseMap(10, 10);
                break;
        }
    }
}
