using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform Player;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    private bool up = false;

    /*public float jumpUpVelocity;
    public float jumpDownVelocity;*/

    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale = 5;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    public float velocity;

    //[SerializeField] float floorHeight = 0.0f;
    //[SerializeField] Transform feet;
    //[SerializeField] ContactFilter filter;
    //public bool isGrounded;
    //Collider[] results = new Collider[1];

   /* public float jumpForce = 2f;

    public float fallForce = 2.5f;

    public Rigidbody rb;

    private bool isGrounded;*/

    public Material[] mat_sky;

    private void Start()
    {
        Player = GetComponent<Transform>();
        //rb = GetComponent<Rigidbody>();
        RenderSettings.skybox=mat_sky[UnityEngine.Random.Range(0 , 5)];//create random skybox 1-5
    }

    private void Update()
    {
        if(Lane3 == true && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if(Lane1 == true && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
        else if(Lane2 == true && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if(Lane2 == true && Player.position.z >= 0.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }



        #region ChangeBools
        if (SwipeManager.swipeRight == true && Lane3 == false && Lane1 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        else if (SwipeManager.swipeLeft == true && Lane2 == true && Player.position.z <= 0.2f)
        {
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;
        }
        else if (SwipeManager.swipeRight == true && Lane2 == true && Player.position.z >= -0.2f)
        {
            Lane3 = true;
            Lane1 = false;
            Lane2 = false;
        }
        else if (SwipeManager.swipeLeft == true && Lane1 == false && Lane3 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        #endregion


        /*if(Player.position.y == 0.0f)
        {
            velocity = 0;
        }*/
        velocity += Physics.gravity.y * gravityScale * Time.deltaTime;


        if(SwipeManager.swipeUp && IsGrounded())
        {
            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale));
        }

        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

       /* if(SwipeManager.swipeUp == true) {
        if (rb.velocity.y > 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (jumpForce - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallForce - 1) * Time.deltaTime;
        }
        }*/

        /*  if (SwipeManager.swipeUp == true && Player.position.y <= 0f && up ==false)
        {
            up = true;
        }

        if(up == true && Player.position.y <= 1.5f)
        {

            Player.position += new Vector3(0, + jumpUpVelocity * Time.deltaTime  , 0);
        }
        else if(Player.position.y > 0f)
        {
           up = false;
           Player.position += new Vector3(0, -jumpDownVelocity * Time.deltaTime  , 0);  
        }
        else if(Player.position.y < 0f)
        {
           Player.position += new Vector3(0, 0 , 0);  
        }*/

        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 5.0f); //rotate skybox
    
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}
