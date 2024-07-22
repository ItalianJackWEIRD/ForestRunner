using UnityEngine;

public class Boxes : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    public GameObject destroyedVersion;
    public AudioClip destructionSoundClip;  // Campo pubblico per il suono di distruzione

    private Score ScoreText;
    private Attack canDestroyBoxes;
    private Movement player;
    private PUManager manager;
    private Shake shake;
    private int currentScore;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        canDestroyBoxes = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        if (ScoreText == null) Debug.LogError("ScoreText non trovato!");
        if (canDestroyBoxes == null) Debug.LogError("canDestroyBoxes non trovato!");
        if (player == null) Debug.LogError("player non trovato!");
        if (manager == null) Debug.LogError("manager non trovato!");
        if (shake == null) Debug.LogError("shake non trovato!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (canDestroyBoxes.canDestroy())
            {
                destroyBox();
            }
            else
            {
                if (manager.GetLives() < 2)
                {
                    currentScore = ScoreText.GetScoreInt();
                    GameOver();
                }
                else
                {
                    manager.LifeMinus1();
                    shake.camShake();
                    destroyBoxNoCoin();
                }
            }
        }
    }

    public void destroyBox()
    {
        myAnimationController.SetBool("crashBool", true);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        PlayDestructionSound();  // Riproduci il suono di distruzione
        Destroy(gameObject);
        int random = Random.Range(0, 20);
        if (random <= 11)
            ScoreText.ScorePlusFive();
        else if (random <= 15)
            manager.LifePlus1();
        else if (random <= 17)
            manager.Set1();
        else if (random == 18)
            manager.Set2();
        else if (random == 19)
            manager.Set3();
    }

    public void destroyBoxNoCoin()
    {
        myAnimationController.SetBool("crashBool", true);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        PlayDestructionSound();  // Riproduci il suono di distruzione
        Destroy(gameObject);
    }

    private void PlayDestructionSound()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySound(destructionSoundClip);
        }
        else
        {
            Debug.LogError("SoundManager non trovato!");
        }
    }

    private void GameOver()
    {
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver(currentScore);
        }
        else
        {
            Debug.LogError("GameOverManager non trovato nella scena.");
        }
    }
}
