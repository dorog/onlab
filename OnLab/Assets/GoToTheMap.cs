using UnityEngine;

public class GoToTheMap : MonoBehaviour {

    SceneLoader scLoad;
    public int mapNumber;

	// Use this for initialization
	void Start () {
        scLoad = GameObject.Find("LoadSceneGO").GetComponent<SceneLoader>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoMyMap()
    {
        if (mapNumber != CurrentGameDatas.maxMap)
        {
            scLoad.LoadMapTimeScaleUsed(mapNumber);
        }
        else if (CurrentGameDatas.KeyNumber >= CurrentGameDatas.maxMap - 1)
        {
            scLoad.LoadMapTimeScaleUsed(mapNumber);
        }  
    }

}
