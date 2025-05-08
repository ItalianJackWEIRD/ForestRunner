using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopItems : MonoBehaviour
{
    private PUManager manager; // Riferimento al PUManager
    private LevelGenerator levelGenerator; // Riferimento al LevelGenerator

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        levelGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelGenerator>();
    }
    public void buyLife()
    {
        manager.LifePlus1();
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
    }

    public void buySlowSpeed()  //slow speed del gioco per 15 secondi
    {
        levelGenerator.StartCoroutine(levelGenerator.SlowSpeed());
    }

    public void buyScoreX2()
    {
        levelGenerator.StartCoroutine(levelGenerator.ScoreX2());
    }

}
