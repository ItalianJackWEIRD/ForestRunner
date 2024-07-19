using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform Player;
    private Attack att;
    private Boxes box;
    private CapsuleCollider collider;
    private Animator animator;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

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
        animator = GetComponentInChildren<Animator>();
        Player = GetComponent<Transform>();
        RenderSettings.skybox = mat_sky[Random.Range(0, 4)]; // create random skybox 1-5
        att = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        box = GameObject.FindGameObjectWithTag("Box").GetComponent<Boxes>();
        comingDown = false;
        collider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        GameObject check = GameObject.FindGameObjectWithTag("Box");

        if (check != null )

        {

            box = GameObject.FindGameObjectWithTag("Box").GetComponent<Boxes>();

        }

        // SWIPE

float smoothTime = 0.2f;
Vector3 targetPosition = Player.position;
Transform cameraTransform = GameObject.Find("CamFollow").transform;

if (Lane3 && Player.position.z < 1.1f)
{
    targetPosition.z = 1.1f;
}
else if (Lane1 && Player.position.z > -1.1f)
{
    targetPosition.z = -1.1f;
}
else if (Lane2)
{
    if (Player.position.z < -0.1f)
    {
        targetPosition.z = 0.1f;
    }
    else if (Player.position.z > 0.1f)
    {
        targetPosition.z = -0.1f;
    }
}

// Smoothly move player to target position
Player.position = Vector3.Lerp(Player.position, targetPosition, smoothTime);

// Smoothly move camera to follow player
Vector3 cameraTargetPosition = new Vector3(cameraTransform.position.x, cameraTransform.position.y, Player.position.z);
cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraTargetPosition, smoothTime * cameraTurn * Time.deltaTime);

#region ChangeBools
if (SwipeManager.swipeRight && !Lane3 && Lane1)
{
    Lane2 = true;
    Lane1 = false;
    Lane3 = false;
}
else if (SwipeManager.swipeLeft && Lane2 && Player.position.z <= 0.2f)
{
    Lane1 = true;
    Lane2 = false;
    Lane3 = false;
}
else if (SwipeManager.swipeRight && Lane2 && Player.position.z >= -0.2f)
{
    Lane3 = true;
    Lane1 = false;
    Lane2 = false;
}
else if (SwipeManager.swipeLeft && !Lane1 && Lane3)
{
    Lane2 = true;
    Lane1 = false;
    Lane3 = false;
}
#endregion

// swipe up

velocity += Physics.gravity.y * gravityScale * Time.deltaTime;

RaycastHit hit;

if (Physics.Raycast(feet.position, Vector3.down, out hit, floorHeight, groundMask) && velocity < 0 || (Player.transform.position.y < 0.1f && !onTheWater))
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

if (SwipeManager.swipeUp && isGrounded)
{
    velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale));
}

if (!comingDown) //se non sta nello swipe down
{
    transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
}
else //se sta nello swipe down
{
    transform.Translate(new Vector3(0, -downFactor, 0) * Time.deltaTime);
}

// swipe down

if (SwipeManager.swipeDown)
{
    if (!isGrounded) //sta nel salto, deve tornare a terra
    {
        comingDown = true;
        Debug.Log("down");
    }
    else //sta per terra deve scivolare
    {
        PlayerSlide();
        Debug.Log("downGrounded");
        StartCoroutine(Roll());
    }
}

RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.0f); //rotate skybox
}

private void PlayerSlide()
{
    Debug.Log("Player sliding!");
    animator.SetTrigger("Slide");
}


    private void OnTriggerEnter(Collider other)

    {

        if (other.tag == "Tramp" && !isGrounded)

        {

            box.destroyBox();

            comingDown = false;

            //gravityScale = tempGravityScale;

            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale) * 0.5f);

            

        }

        if (other.tag == "Tramp+" && !isGrounded)

        {

            comingDown = false;

            //gravityScale = tempGravityScale;

            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale) * 1.5f);


        }

    }

    public void SetJump(float height, float gravity)
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
