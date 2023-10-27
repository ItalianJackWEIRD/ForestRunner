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

    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale = 5;
    [SerializeField] LayerMask groundMask;

    public float velocity;

    [SerializeField] float floorHeight = 0.5f;
    [SerializeField] Transform feet;
    public bool isGrounded;

    public Material[] mat_sky;

    private void Start()
    {
        Player = GetComponent<Transform>();
        RenderSettings.skybox=mat_sky[UnityEngine.Random.Range(0 , 5)]; //create random skybox 1-5
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

        velocity += Physics.gravity.y * gravityScale * Time.deltaTime;

        RaycastHit hit;

        if(Physics.Raycast(feet.position, Vector3.down, out hit, floorHeight, groundMask) && velocity < 0)
        {
            velocity = 0;
            Vector3 surface = hit.point + Vector3.up * floorHeight;
            transform.position = new Vector3(transform.position.x, surface.y, transform.position.z);
            isGrounded = true;
        }
        else 
        {
            isGrounded = false;
        }

        if(SwipeManager.swipeUp && isGrounded)
        {
            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale));
        }

        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 5.0f); //rotate skybox
    
    }
}
