using UnityEngine;


public class JOE_Anim_Manager : MonoBehaviour {

    [Header("Base Settings")]
    public Animator joeAnim;
    public float minWait = 3;
    public float maxWait = 6;

    [Header("Animation Chance Settings")]
    public float footChance;
    public float lookAroundChance;
    public float welcomeChance;

    [Header("Animation Time Settings")]
    public float footAnimTime;
    public float lookAroundAnimTime;
    public float welcomeAnimTime;

    private string lastAnimation;

    // Use this for initialization
    void Start () {

        float rand = Random.Range(minWait, maxWait);
        Invoke("ShowAnim", rand);

        footChance = Mathf.Abs(footChance);
        lookAroundChance = Mathf.Abs(lookAroundChance);
        welcomeChance = Mathf.Abs(welcomeChance);
    }

    public void ShowAnim()
    {
        float invokeCallTime;
        float random = Random.value;

        if(random <= footChance)
        {
            joeAnim.SetBool(Configuration.footAnimation, true);
            invokeCallTime = footAnimTime;
            lastAnimation = Configuration.footAnimation;
        }
        else if(random <= footChance + lookAroundChance)
        {
            joeAnim.SetBool(Configuration.lookAroundAnimation, true);
            invokeCallTime = lookAroundAnimTime;
            lastAnimation = Configuration.lookAroundAnimation;
        }
        else
        {
            joeAnim.SetBool(Configuration.welcomeAnimation, true);
            invokeCallTime = welcomeAnimTime;
            lastAnimation = Configuration.welcomeAnimation;
        }

        Invoke("AnimEnd", invokeCallTime);
        Invoke("ShowAnim", invokeCallTime + Random.Range(minWait, maxWait));
    }

    public void AnimEnd()
    {
        joeAnim.SetBool(lastAnimation, false);
    }
}
