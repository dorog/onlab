using UnityEngine;

public class AnimationManager : MonoBehaviour {

    public GameObject UFO;
    public GameObject UFO_place;
    public GameObject Joe;
    public bool rise = false;
    public bool returnHome = false;
    public bool joe_hi = false;
    public float hi_time = 3;
    private float origin_hi_time;
    private bool hi_running = false;

    private Animator joeAnim;

	// Use this for initialization
	void Start () {
        joeAnim = Joe.GetComponent<Animator>();
        origin_hi_time = hi_time;
    }
	
	// Update is called once per frame
	void Update () {
        if (rise)
        {
            rise = false;
            UFO_place.GetComponent<Animation>().Play();
            UFO.GetComponent<UFO_Move>().Start_animation();
        }
        if (returnHome)
        {
            returnHome = false;
            UFO.GetComponent<UFO_Move>().Come_back();
        }
        if (joe_hi)
        {
            joeAnim.SetBool("hi", true);
            joe_hi = false;
            hi_running = true;
        }
        if (hi_running)
        {
            if(hi_time-Time.deltaTime >= 0)
            {
                hi_time -= Time.deltaTime;
            }
            else if (hi_time > 0)
            {
                hi_time = 0;
            }
            else
            {
                joeAnim.SetBool("hi", false);
                hi_time = origin_hi_time;
                hi_running = false;
            }
        }
    }
}
