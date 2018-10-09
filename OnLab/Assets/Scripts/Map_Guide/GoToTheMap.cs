using UnityEngine;

public class GoToTheMap : MonoBehaviour {

    SceneLoader scLoad;
    public int mapNumber;

	// Use this for initialization
	void Start () {
        scLoad = GameObject.Find("LoadSceneGO").GetComponent<SceneLoader>();
	}

    public void GoMyMap()
    {
        if (mapNumber != CurrentGameDatas.GetActualLevelLastMapNumber())
        {
            scLoad.LoadMapTimeScaleUsed(mapNumber);
        }
        else if (CurrentGameDatas.ItemCount >= CurrentGameDatas.GetActualLevelLastMapNumber() - 1)
        {
            scLoad.LoadMapTimeScaleUsed(mapNumber);
        }  
    }

}
