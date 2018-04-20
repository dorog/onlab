using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour {

    Animator anim;
    //Rigidbody character

    //Ideiglenes

    public float jumpPower = 20;
    private bool jumped = false;
    public float gravity = 20.0F;
    public float Speed = 5;
    public float rotationSpeed = 0.5f;
    Quaternion targetRotation;
    CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    // Use this for initialization
    void Start()
    {
        targetRotation = transform.rotation;
        anim = GetComponent<Animator>();
        //character = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float rot = Input.GetAxis("Horizontal");
        
        rot *= rotationSpeed;

        transform.Rotate(0, rot, 0);


        if (controller.isGrounded)
        {
            if (jumped)
            {
                //anim.SetBool("Down", true);
            }
            jumped = false;
            moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;
            /*Debug.Log(moveDirection);
            Debug.Log("foldon vagyok!");*/

        }

        /*moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= Speed;*/
        //Debug.Log(moveDirection);


        if (Input.GetKey("space") && !jumped)
        {
            jumped = true;
            moveDirection.y += jumpPower;
        }


        //Gravity ujragondolasa, belso valtozo, ami szamol
        /*if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }*/
        controller.Move(moveDirection * Time.deltaTime);
    }
}
