using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JOE_Anim_Manager : MonoBehaviour {

    public Animator joeAnim;
    public float[] AnimTimes;
    public float minWait = 3;
    public float maxWait = 6;
    private int anim_count=0;

    

    // Use this for initialization
    void Start () {
        anim_count = AnimTimes.Length;

        float rand = Random.Range(minWait, maxWait);
        Invoke("ShowAnim", rand);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowAnim()
    {
        System.Random rnd = new System.Random();
        int animNumber = rnd.Next(0, anim_count+1); // +1 for do hi more times: it needs better implementation
        switch (animNumber)
        {
            case (0):
                joeAnim.SetBool("foot", true);
                break;
            case (1):
                joeAnim.SetBool("around", true);
                break;
            case (2):
                joeAnim.SetBool("hi", true);
                break;
            default:
                joeAnim.SetBool("hi", true);
                break;
        }

        Invoke("AnimEnd", AnimTimes[animNumber]);
        Invoke("ShowAnim", AnimTimes[animNumber]+Random.Range(minWait, maxWait));
    }

    public void AnimEnd()
    {
        joeAnim.SetBool("foot", false);
        joeAnim.SetBool("around", false);
        joeAnim.SetBool("hi", false);
        joeAnim.SetBool("idle", false);
    }
}
