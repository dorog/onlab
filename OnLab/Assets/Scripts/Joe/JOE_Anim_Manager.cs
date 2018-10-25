using UnityEngine;

public class JOE_Anim_Manager : MonoBehaviour {

    [Header("Base Settings")]
    [SerializeField]
    private Animator joeAnim;
    [SerializeField]
    private float minWait = 3;
    [SerializeField]
    private float maxWait = 6;

    [Header("Animation Chance Settings")]
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float footChance = 0.3f;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float lookAroundChance = 0.3f;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float welcomeChance = 0.4f;

    [Header("Animation Time Settings")]
    [SerializeField]
    private float footAnimTime;
    [SerializeField]
    private float lookAroundAnimTime;
    [SerializeField]
    private float welcomeAnimTime;

    private string lastAnimation = null;

    private float summChance;

    private readonly string footAnimation = "foot";
    private readonly string lookAroundAnimation = "around";
    private readonly string welcomeAnimation = "hi";

    void Start () {

        summChance = footChance + lookAroundChance + welcomeChance;

        float rand = Random.Range(minWait, maxWait);
        Invoke("ShowAnim", rand);
    }

    public void ShowAnim()
    {
        if (PreparLevel.InAnimation)
        {
            return;
        }

        float invokeCallTime;
        float random = Random.value;

        if (random <= footChance / summChance)
        {
            joeAnim.SetBool(footAnimation, true);
            invokeCallTime = footAnimTime;
            lastAnimation = footAnimation;
        }
        else if(random <= (footChance + lookAroundChance) / summChance)
        {
            joeAnim.SetBool(lookAroundAnimation, true);
            invokeCallTime = lookAroundAnimTime;
            lastAnimation = lookAroundAnimation;
        }
        else
        {
            joeAnim.SetBool(welcomeAnimation, true);
            invokeCallTime = welcomeAnimTime;
            lastAnimation = welcomeAnimation;
        }
        Invoke("AnimEnd", invokeCallTime);
        Invoke("ShowAnim", invokeCallTime + Random.Range(minWait, maxWait));
    }

    public void AnimEnd()
    {
        if(lastAnimation == null)
        {
            return;
        }
        joeAnim.SetBool(lastAnimation, false);
    }
}
