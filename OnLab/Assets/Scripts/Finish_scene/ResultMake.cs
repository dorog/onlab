using UnityEngine;
using UnityEngine.UI;

public class ResultMake : MonoBehaviour {

    private string GSB_sprite = "Map_guide/GSB";

    [Header("Result elements")]
    [SerializeField]
    private Image scarabImagePlace;
    [SerializeField]
    private Text scoreText;

    // Use this for initialization
    void Start () {
        Time.timeScale = SharedData.basicSpeed;

        scarabImagePlace.sprite = Resources.Load<Sprite>(GSB_sprite + ActualMapData.solvedMap.scarab);
        scoreText.text = "Score: "+ ActualMapData.solvedMap.mapScore;
    }

    public void LoadSameScene()
    {
        SceneLoader.LoadMapTimeScaleUsed(ActualMapData.mapNumber);
    }
}
