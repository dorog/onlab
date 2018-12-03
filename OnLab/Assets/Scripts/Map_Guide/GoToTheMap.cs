using UnityEngine;

public class GoToTheMap : MonoBehaviour {

    [SerializeField]
    private int mapNumber;

    public void GoMyMap()
    {
        if (mapNumber != CurrentGameDatas.GetActualLevelLastMapNumber())
        {
            SceneLoader.LoadMapTimeScaleUsed(mapNumber);
        }
        else if (CurrentGameDatas.ItemCount >= CurrentGameDatas.GetActualLevelLastMapNumber() - 1)
        {
            SceneLoader.LoadMapTimeScaleUsed(mapNumber);
        }  
    }

    private void OnMouseDown()
    {
        GoMyMap();
    }
}
