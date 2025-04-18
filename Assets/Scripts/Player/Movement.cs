using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

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

    [Header("Movement")]
    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale = 5;
    [SerializeField] float slideDuration = 1f;
    private float tempGravityScale;
    [SerializeField] LayerMask groundMask;

    [Header("Timers")]
    [SerializeField] float jumpDuration = 0.5f;
    [SerializeField] float strafeDuration = 0.2f;

    //  Timers
    List<Timer> timers;
    CountdownTimer jumpTimer;
    CountdownTimer slideTimer;
    CountdownTimer strafeRightTimer;
    CountdownTimer strafeLeftTimer;

    public float cameraTurn;
    public float downFactor;
    public float velocity;

    [SerializeField] float floorHeight = 0.5f;
    [SerializeField] Transform feet;

    // state of the player
    public bool isGrounded;
    public bool comingDown;
    public bool onTheWater;

    public Material[] mat_sky;

    public bool isGameOver = false;

    public AudioClip trampolineSound;  // Aggiungi questa riga
    private AudioSource audioSource;  // Aggiungi questa ri

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Player = GetComponent<Transform>();
        RenderSettings.skybox = mat_sky[Random.Range(0, 4)]; // create random skybox 1-5
        att = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        box = GameObject.FindGameObjectWithTag("Box").GetComponent<Boxes>();
        comingDown = false;
        collider = GetComponent<CapsuleCollider>();
        audioSource = GetComponent<AudioSource>();

        // Setup timers
        jumpTimer = new CountdownTimer(jumpDuration);
        slideTimer = new CountdownTimer(slideDuration);
        strafeRightTimer = new CountdownTimer(strafeDuration);
        strafeLeftTimer = new CountdownTimer(strafeDuration);

        timers = new List<Timer>(capacity: 2) { jumpTimer, slideTimer, strafeRightTimer, strafeLeftTimer };

    }

    private void HandleTimers()
    {
        foreach (var timer in timers)
        {
            timer.Tick(Time.deltaTime);
        }
    }

    private void Update()
    {
        HandleTimers();

        if (isGameOver || Time.timeScale == 0)
        {
            animator.SetBool("GameOver", isGameOver);
            animator.SetBool("GameOverWater", onTheWater && isGameOver);
            return;
        }

        GameObject check = GameObject.FindGameObjectWithTag("Box");

        if (check != null)

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
        cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, cameraTargetPosition, cameraTurn * Time.deltaTime);

        #region ChangeBools
        if (SwipeManager.swipeRight && !Lane3 && Lane1)
        {
            Lane1 = false;
            Lane2 = true;
            Lane3 = false;
            strafeRightTimer.Start();
        }
        else if (SwipeManager.swipeLeft && Lane2 && Player.position.z <= 0.2f)
        {
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;
            strafeLeftTimer.Start();
        }
        else if (SwipeManager.swipeRight && Lane2 && Player.position.z >= -0.2f)
        {
            Lane1 = false;
            Lane2 = false;
            Lane3 = true;
            strafeRightTimer.Start();
        }
        else if (SwipeManager.swipeLeft && !Lane1 && Lane3)
        {
            Lane1 = false;
            Lane2 = true;
            Lane3 = false;
            strafeLeftTimer.Start();
        }
        #endregion

        // swipe up

        velocity += Physics.gravity.y * gravityScale * Time.deltaTime;

        RaycastHit hit;
        // calcola la discesa
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

        // salto
        if (isGrounded) jumpTimer.Stop(); // Reset isJumping when grounded

        if (SwipeManager.swipeUp && isGrounded)
        {
            jumpTimer.Start();
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
            }
            else //sta per terra deve scivolare
            {
                StartCoroutine(Roll());
            }
        }

        // Animator
        CheckAnimator();

        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.0f); //rotate skybox
    }

    void CheckAnimator()
    {
        animator.SetBool("Jump", jumpTimer.IsRunning);
        animator.SetBool("Slide", slideTimer.IsRunning);
        animator.SetBool("Floating", comingDown);
        animator.SetBool("StrafeRight", strafeRightTimer.IsRunning);
        animator.SetBool("StrafeLeft", strafeLeftTimer.IsRunning);
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

            // Riproduci il suono
            if (audioSource != null && trampolineSound != null)
            {
                audioSource.PlayOneShot(trampolineSound);
            }
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
        slideTimer.Start();
        float y = collider.center.y;
        float height = collider.height;
        collider.height = 2.72f;
        Vector3 center = collider.center;
        center.y = 1.04f;
        collider.center = center;
        yield return new WaitForSecondsRealtime(slideDuration);
        collider.height = height;
        center.y = y;
        collider.center = center;
    }

    public void SetGameOver(bool gameOver)
    {
        isGameOver = gameOver;
    }

    public bool isGameOverCheck()
    {
        return isGameOver;
    }
}