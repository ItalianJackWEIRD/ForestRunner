using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boxes : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    private Score ScoreText;
    private Attack canDestroyBoxes;
    private Movement player;
    private PUManager manager;
    private Shake shake;

    public GameObject destroyedVersion;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        canDestroyBoxes = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canDestroyBoxes.canDestroy())
        {
            destroyBox();
        }
        else
        {
            if (manager.GetLives() < 2)
            {
                ShowGameOver();
            }
            else
            {
                manager.LifeMinus1();
                shake.camShake();
                destroyBoxNoCoin();
            }
        }
    }

    public void destroyBox()
    {
        myAnimationController.SetBool("crashBool", true);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);//box
        int random = Random.Range(0, 100); // Cambiato per facilitare la gestione delle probabilità
        if (random < 60)
            ScoreText.ScorePlusFive();
        else if (random < 80)  // 20% +1 hp
            manager.LifePlus1();
        else if (random < 90)  //magnet
            manager.Set1();
        else if (random < 95)  //invincible
            manager.Set2();

    }

    public void destroyBoxNoCoin()
    {
        myAnimationController.SetBool("crashBool", true);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);//box
    }

    private void ShowGameOver()
    {
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver(ScoreText.GetScoreInt());
        }
        else
        {
            Debug.LogError("GameOverManager non trovato nella scena.");
        }
    }
}
