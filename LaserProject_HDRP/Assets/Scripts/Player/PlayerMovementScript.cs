using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovementScript : MonoBehaviour
{
    public static PlayerMovementScript defaultPlayer;
    //public PositionConstraint parenting;
    private float x;
    private float z;
    

    private Vector3 myVelocity;
    public float gravity = -9.81f;
    
    [SerializeField] private int jumpHeight = 10;
    private Vector3 move;
    //public Rigidbody rb;
    private CharacterController controller;
    private float initSpeed;
    public float speed = 12f;
    
    
    //GroundCheck
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    [SerializeField] private bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        defaultPlayer = this;
        initSpeed = speed;
        controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePackage();
        JumpPackage();
    }

    void JumpPackage()
    {
        myVelocity.y += gravity * Time.deltaTime;
        controller.Move(myVelocity*Time.deltaTime);
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        /*if (onGround && myVelocity.y < 0)
        {
            myVelocity.y = -2;
        }*/

        if (onGround && Input.GetButtonDown("Jump"))
        {
            myVelocity.y = Mathf.Sqrt(jumpHeight *-2* gravity);
        }

        //if (!onGround && myVelocity.y <= 0) myVelocity.y -= .01f;
        if (!onGround) speed = initSpeed * 0.7f;
        if (onGround) speed = initSpeed;

    }
    void MovePackage()
    {
        //if(!onGround) speed=speed/2;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward*z;
        controller.Move(move.normalized* speed*Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 10);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 7);
    }
}
