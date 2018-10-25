using UnityEngine;

public class UFO_Manager : MonoBehaviour {

    [Header("GameObjects")]
    [SerializeField]
    private GameObject UFO;
    [SerializeField]
    private GameObject UFO_place;
    [Header("Settings")]
    [SerializeField]
    private float minWait = 30;
    [SerializeField]
    private float maxWait = 60;

    private Animation ufoDoor;
    private UFO_Move ufoMove;

    void Start () {

        ufoDoor = UFO_place.GetComponent<Animation>();
        if(ufoDoor == null)
        {
            Debug.LogError("UFO_Manager: UFO_place GameObject don't have Animation component!");
        }

        ufoMove = UFO.GetComponent<UFO_Move>();
        if (ufoMove == null)
        {
            Debug.LogError("UFO_Manager: UFO GameObject don't have UFO_Move component!");
        }

        float rand = Random.Range(minWait, maxWait);
        Invoke("Fly_Away", rand);
	}

    public void Fly_Away()
    {
        ufoDoor.Play();
        ufoMove.Start_animation();

        float rand = Random.Range(minWait, maxWait);
        Invoke("Come_Back", rand);
    }

    public void Come_Back()
    {
        UFO.GetComponent<UFO_Move>().Come_back();

        float rand = Random.Range(minWait, maxWait);
        Invoke("Fly_Away", rand);
    }
}
