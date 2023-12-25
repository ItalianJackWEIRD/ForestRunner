using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform Player;
    private Attack att;
    private Boxes box;
    private CapsuleCollider collider;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    //private bool up = false;

    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale = 5;
    private float tempGravityScale;
    [SerializeField] LayerMask groundMask;

    public float cameraTurn;
    public float downFactor;
    public float velocity;

    [SerializeField] float floorHeight = 0.5f;
    [SerializeField] Transform feet;
    public bool isGrounded;
    public bool comingDown;
    public bool onTheWater;

   public Material[] mat_sky;

    private void Start()
    {
        Player = GetComponent<Transform>();
        RenderSettings.skybox=mat_sky[Random.Range(0 , 4)];//create random skybox 1-5
        att = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        box = GameObject.FindGameObjectWithTag("Box").GetComponent<Boxes>();
        //tempGravityScale = gravityScale;
        comingDown = false;
        collider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        //if (isGrounded)
        //{
        //    //gravityScale = tempGravityScale;
        //}
        box = GameObject.FindGameObjectWithTag("Box").GetComponent<Boxes>();

        //SWIPE


        if (Lane3 == true && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 12.5f * Time.deltaTime);
            GameObject.Find("CamFollow").transform.position += new Vector3(0, 0, cameraTurn * Time.deltaTime);
        }
        else if(Lane1 == true && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -12.5f * Time.deltaTime);
            GameObject.Find("CamFollow").transform.position += new Vector3(0, 0, -cameraTurn * Time.deltaTime);
        }
        else if(Lane2 == true && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 12.5f * Time.deltaTime);
            GameObject.Find("CamFollow").transform.position += new Vector3(0, 0, cameraTurn * Time.deltaTime);
        }
        else if(Lane2 == true && Player.position.z >= 0.1f)
        {
            Player.position += new Vector3(0, 0, -12.5f * Time.deltaTime);
            GameObject.Find("CamFollow").transform.position += new Vector3(0, 0, -cameraTurn * Time.deltaTime);
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

        //swipe up

        velocity += Physics.gravity.y * gravityScale * Time.deltaTime;

        RaycastHit hit;

        if(Physics.Raycast(feet.position, Vector3.down, out hit, floorHeight, groundMask) && velocity < 0 || (Player.transform.position.y < 0.1f && !onTheWater))
        {
            velocity = 0;
            Vector3 surface = hit.point + Vector3.up * floorHeight;
            transform.position = new Vector3(transform.position.x, surface.y, transform.position.z);
            isGrounded = true;
            comingDown = false;
        }
        else 
        {
            isGrounded = false;
        }

        if(SwipeManager.swipeUp && isGrounded)
        {
            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale));
        }

        if (!comingDown) //se non sta nello swipe down
        {
            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        }
        else    //se sta nello swipe down
        {
            transform.Translate(new Vector3(0, - downFactor, 0) * Time.deltaTime);
        }


        //swipe down

        if (SwipeManager.swipeDown)
        {
            if (!isGrounded)    //sta nel salto, deve tornare a terra
            {
                comingDown = true;
                Debug.Log("down");
            }
            else        //sta per terra deve scivolare
            {
                Debug.Log("downGrounded");
                StartCoroutine(Roll());
            }
        }

        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.0f); //rotate skybox

        
        
    }

    /// <summary>
    /// Metodo fa cose
    /// <br>Bla bla</br>
    /// <para>altro badjienoaw <see cref="Motion"/></para>
    /// </summary>
    /// <param name="other">other sè quessto, rappe</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tramp" && !isGrounded)
        {
            box.destroyBox();
            comingDown = false;
            //gravityScale = tempGravityScale;
            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale) * 1.5f);
            
        }
    }

    public void SetJump (float height, float gravity)
    {
        jumpHeight = height;
        gravityScale = gravity;
    }

    public void SetJumpNormal()
    {
        jumpHeight = 1.65f;
        gravityScale = 1.6f;
    }

    IEnumerator Roll()
    {
        float y = collider.center.y;
        float height = collider.height;
        collider.height = 2.12f;
        collider.center.Set(collider.center.x, 1.04f, collider.center.z);
        Debug.Log("Collider Small");
        yield return new WaitForSecondsRealtime(1.3f);
        collider.height = height;
        collider.center.Set(collider.center.x, y, collider.center.z);
        Debug.Log("Collider Normal");
    }
 }
