
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float moveSpeed;
    public float advancementScore = 0;

    public int GetScore() { return Mathf.RoundToInt(advancementScore); }  // getter per il punteggio
    public float scoreRate = 250 / 90f; // 250 punti ogni 90 secondi
    public int random;

    private Movement mov;

    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;
    public GameObject Tile4;
    public GameObject Tile5;
    public GameObject Tile6;
    public GameObject Tile7;
    public GameObject Tile8;
    public GameObject Tile9;
    public GameObject Tile10;
    public GameObject Tile11;
    public GameObject Tile12;
    public GameObject Tile13;
    public GameObject Tile14;
    public GameObject Tile15;
    public GameObject Tile16;
    public GameObject Tile17;
    public GameObject Tile18;
    public GameObject Tile19;
    public GameObject Tile20;
    public GameObject Tile21;
    public GameObject Tile22;
    public GameObject Tile23;
    public GameObject Tile24;
    public GameObject Tile25;
    public GameObject StartTile1;
    public GameObject StartTile2;
    public GameObject StartTile3;
    public GameObject StartTile4;

    private float Index = 0;
    private int lastRandom;

    private void Start()
    {
        mov = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();

        //create 5 tile first game
        GameObject StartPlane1 = Instantiate(StartTile1, transform);
        StartPlane1.transform.position = new Vector3(8, -0.25f, 0);

        GameObject StartPlane2 = Instantiate(StartTile2, transform);
        StartPlane2.transform.position = new Vector3(0, -0.25f, 0);

        GameObject StartPlane3 = Instantiate(StartTile3, transform);
        StartPlane3.transform.position = new Vector3(-8, -0.25f, 0);

        GameObject StartPlane4 = Instantiate(StartTile4, transform);
        StartPlane4.transform.position = new Vector3(-16, -0.25f, 0);

        /* GameObject StartPlane5 = Instantiate(StartTile5, transform);
        StartPlane5.transform.position = new Vector3(-25, -0.25f, 0);

        GameObject StartPlane6 = Instantiate(StartTile6, transform);
        StartPlane6.transform.position = new Vector3(-33, -0.25f, 0); */
    }

    private float nextTilePosition = -25f; // Posizione iniziale
    private float tileSpacing = 9f; // Distanza tra i tile

    private void Update()
    {
        if (!mov.isGameOverCheck())
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            UpdateScore();
            AdjustSpeed();
        }

        if (transform.position.x >= Index)
        {
            for (int i = 0; i < 3; i++) // Ciclo per spawnare 3 tile
            {
                int randomTileIndex = Random.Range(0, random);
                while (randomTileIndex == lastRandom)
                {
                    randomTileIndex = Random.Range(0, random);
                }
                lastRandom = randomTileIndex;

                GameObject newTile = Instantiate(GetRandomTile(randomTileIndex), transform);
                newTile.transform.position = new Vector3(nextTilePosition, -0.25f, 0);

                nextTilePosition -= tileSpacing; // Aggiorna la posizione per il prossimo tile
            }

            Index += tileSpacing * 3; // Aggiorna l'indice per il prossimo batch
        }
    }

    private GameObject GetRandomTile(int index)
    {
        GameObject[] tiles = { Tile1, Tile2, Tile3, Tile4, Tile5, Tile6, Tile7, Tile8, Tile9, Tile10, Tile11, Tile12, Tile13 };
        return tiles[Mathf.Clamp(index, 0, tiles.Length - 1)];
    }

    private void UpdateScore()
    {
        advancementScore += scoreRate * Time.deltaTime;
    }

    private void AdjustSpeed()
    {
        float targetSpeed = Mathf.Lerp(4f, 10f, Mathf.InverseLerp(0f, 1500f, advancementScore));    //setta questi parametri per gestire la velocità
        moveSpeed = targetSpeed;
    }
}
