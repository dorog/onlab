using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActive : MonoBehaviour {

    Animation trapAnim;
    StartActions sa;
    public float resetTime = 2;
    private int fill = 0; //max 2

	// Use this for initialization
	void Start () {
        trapAnim = this.transform.GetComponent<Animation>();
        sa = GameObject.Find(Configuration.actionMenuName).GetComponent<StartActions>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("if elott: " + fill);
        if (fill <= 2)
        {
            Collider[] colliders = Physics.OverlapBox(this.transform.position, new Vector3(25, 150, 25));
            //Debug.Log(colliders.Length);
            float joeTime = 0;
            for (int i = 0; i < colliders.Length; i++)
            {
                JoeCommandControl joeController = colliders[i].GetComponent<JoeCommandControl>();
                BoxController boxController = colliders[i].GetComponent<BoxController>();
                if (!joeController && !boxController)
                {
                    continue;
                }

                if (fill == 0)
                {
                    trapAnim.Play();
                }

                if (joeController)
                {

                    joeController.fall_trap = true;
                    joeController.left_time = joeController.fallAnimationTime;
                    joeTime = joeController.fallAnimationTime;
                    Animator anim = colliders[i].GetComponent<Animator>();
                    if (!anim)
                    {
                        continue;
                    }
                    anim.SetBool(Configuration.idleAnimation, false);
                    anim.SetBool(Configuration.trapAnimation, true);
                    trapAnim.Play();
                    sa.ObjectHit(resetTime + joeTime);
                }
                if (boxController)
                {
                    fill++;
                }
                
                
                //fill++;
                Debug.Log(fill);
            }
        }
        
        //Debug.Log(colliders.Length);
        
    }
}
