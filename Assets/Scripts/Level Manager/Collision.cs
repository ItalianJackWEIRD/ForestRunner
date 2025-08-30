/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private PUManager manager;

    private Shake shake;


    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            if (manager.GetLives()<2)
                SceneManager.LoadScene("Menu");//game over and reload scene
            else    //decrementa vita e shake schermo e distruggi game object
            {
                manager.LifeMinus1();
                shake.camShake();
                Destroy(other.gameObject);
            }
        }
        else if (other.tag == "River" || other.tag == "DeathBarrier")
            SceneManager.LoadScene("Menu");//game over and reload scene
    }
}*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private PUManager manager;
    private Shake shake;
    public LevelGenerator scoreManager; // Aggiungi questa variabile per il punteggio
    private int currentScore;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        scoreManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelGenerator>(); // Associa lo script LevelGenerator che ha lo score
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            if (manager.GetLives() < 2)
            {
                shake.camShake();
                Destroy(other.gameObject);
                if (!manager.powerUp2)
                {
                    manager.LifeMinus1();
                    currentScore = scoreManager.GetScore(); // Ottieni il punteggio corrente
                    GameOver(); // Passa il punteggio corrente al Game Over Manager
                }
            }
            else
            {
                shake.camShake();
                Destroy(other.gameObject);
                if (!manager.powerUp2)
                {
                    manager.LifeMinus1();
                }
            }
        }
        else if (other.tag == "River" || other.tag == "DeathBarrier")
        {
            currentScore = scoreManager.GetScore(); // Ottieni il punteggio corrente
            GameOver(); // Passa il punteggio corrente al Game Over Manager
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

