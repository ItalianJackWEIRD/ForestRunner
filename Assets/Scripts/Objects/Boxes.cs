/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Boxes : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    private Score ScoreText;
    private Attack canDestroyBoxes;
    private Movement player;
    public Score scoreManager;
    private int currentScore;

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
        if(other.tag == "Player")
        {
            if(canDestroyBoxes.canDestroy())
            {
                destroyBox();
            }
            else
            {
                if (manager.GetLives() < 2)
                {
                    currentScore = scoreManager.GetScoreInt(); 
                    GameOver();
                }
                else    //decrementa vita e shake schermo e distruggi game object
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
        Destroy(gameObject);//box
        int random = Random.Range(0, 20); // 60% coin | 20% +1 hp | 10% Magnet | 5% Invincible | 5% Super Jump
        if (random == 0 || random == 1 || random == 2 || random == 3 || random == 4 || random == 5 || random == 6 || random == 7 || random == 8 || random == 9 || random == 10 || random == 11)
            ScoreText.ScorePlusFive();
        else if (random == 12 || random == 13 || random == 14 || random == 15)  // +1 hp
            manager.LifePlus1();
        else if (random == 16 || random == 17)  //magnet
            manager.Set1();
        else if(random == 18)   //invincible
            manager.Set2();
    }

    public void destroyBoxNoCoin()
    {
        myAnimationController.SetBool("crashBool", true);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);//box
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


}*/

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

    private int currentScore;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        canDestroyBoxes = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        // Aggiungi debug per verificare che i componenti siano trovati correttamente
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
                else    //decrementa vita e shake schermo e distruggi game object
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
        Destroy(gameObject);//box
        int random = Random.Range(0, 20); // 60% coin | 20% +1 hp | 10% Magnet | 5% Invincible | 5% Super Jump
        if (random <= 11) //60%
            ScoreText.ScorePlusFive();
        else if (random <= 15) //20%
            manager.LifePlus1();
        else if (random <= 17) //10%
            manager.Set1();
        else if (random == 18) //5%
            manager.Set2();
        else if (random == 19) //5%
            manager.Set3();
    }

    public void destroyBoxNoCoin()
    {
        myAnimationController.SetBool("crashBool", true);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);//box
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
