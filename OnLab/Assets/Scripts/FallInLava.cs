using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInLava : MonoBehaviour {

    StartActions sa;
    public float resetTime = 2;

    // Use this for initialization
    void Start()
    {

        sa = GameObject.Find("ActionMenuGO").GetComponent<StartActions>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapBox(this.transform.position, new Vector3(25, 150, 25));
        //Debug.Log(colliders.Length);
        float joeTime = 0;
        for (int i = 0; i < colliders.Length; i++)
        {
            JoeCommandControl joeController = colliders[i].GetComponent<JoeCommandControl>();
            //OnePushPerRound oppr = colliders[i].GetComponent<OnePushPerRound>();
            if (!joeController)
            {
                continue;
            }
            if (joeController)
            {
                joeController.fall = true;
                joeController.left_time = 0.7f;
                joeTime = joeController.LavaFallAnimationTime;

                /*Animator anim = colliders[i].GetComponent<Animator>();
                if (anim == null)
                {
                    continue;
                }*/
                //anim.SetBool("lava", true);
                //anim.SetBool("start", false);
                //sa.ObjectHit(resetTime + joeTime);
            }
            /*else if (oppr)
            {
                Debug.Log("else if");
                oppr.left_time = 0.7f; //rethink it
                oppr.fall = true;
                oppr.isFalled = true;
                
                //oppr.gameObject.AddComponent<BoxCollider>(); //NOPE
                //TODO: trigger off?
            }*/
            
        }

        
    }
}
