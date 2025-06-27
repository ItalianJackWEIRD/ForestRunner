using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopItems : MonoBehaviour
{
    private PUManager manager; // Riferimento al PUManager
    private LevelGenerator levelGenerator; // Riferimento al LevelGenerator

    private Score score; // Riferimento al componente Score, se necessario

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        levelGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelGenerator>();
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
    }
    public void buyLife()
    {
        manager.LifePlus1();
        score.MenoInt(50); // Sottrae 50 punti dal punteggio
    }

    public void buyPoweUpRandom()
    {
        int randomPowerUp = Random.Range(1, 4); // Genera un numero casuale tra 1 e 3
        switch (randomPowerUp)
        {
            case 1:
                manager.Set1(); // Attiva il primo PowerUp
                break;
            case 2:
                manager.Set2(); // Attiva il secondo PowerUp
                break;
            case 3:
                manager.Set3(); // Attiva il terzo PowerUp
                break;
        }
        score.MenoInt(50);
    }

    public void buySlowSpeed()  //slow speed del gioco per 15 secondi
    {
        levelGenerator.StartCoroutine(levelGenerator.SlowSpeed());
        score.MenoInt(100);
    }

    public void buyScoreX2()
    {
        levelGenerator.StartCoroutine(levelGenerator.ScoreX2());
        score.MenoInt(200);
    }

}
