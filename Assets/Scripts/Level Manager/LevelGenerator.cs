using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float moveSpeed;
    public int random; // Assicurati che il valore random copra tutti i 24 Tile rimanenti

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
        // Crea 5 tiles iniziali
        GameObject StartPlane1 = Instantiate(StartTile1, transform);
        StartPlane1.transform.position = new Vector3(7, -0.25f, 0);
        
        GameObject StartPlane2 = Instantiate(StartTile2, transform);
        StartPlane2.transform.position = new Vector3(-1, -0.25f, 0);
       
        GameObject StartPlane3 = Instantiate(StartTile3, transform);
        StartPlane3.transform.position = new Vector3(-9, -0.25f, 0);
       
        GameObject StartPlane4 = Instantiate(StartTile4, transform);
        StartPlane4.transform.position = new Vector3(-17, -0.25f, 0);
    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);  // tiles movment X direction axis

        if(transform.position.x >= Index)
        {
            int RandomInt1 = Random.Range(0, random);
            while (RandomInt1 == lastRandom)
            {
                RandomInt1 = Random.Range(0, random);
            }

            InstantiateTile(RandomInt1, -25);
            
            int RandomInt2 = Random.Range(0, random);
            while (RandomInt2 == RandomInt1)
            {
                RandomInt2 = Random.Range(0, random);
            }

            InstantiateTile(RandomInt2, -33);

            int RandomInt3 = Random.Range(0, random);
            while (RandomInt3 == RandomInt2)
            {
                RandomInt3 = Random.Range(0, random);
            }
            lastRandom = RandomInt3;

            InstantiateTile(RandomInt3, -41);

            Index = Index + 24f;
        }
    }

    private void InstantiateTile(int randomInt, float positionX)
    {
        GameObject tempTile = null;

        switch (randomInt)
        {
            case 0: tempTile = Instantiate(Tile1, transform); break;
            case 1: tempTile = Instantiate(Tile2, transform); break;
            case 2: tempTile = Instantiate(Tile3, transform); break;
            case 3: tempTile = Instantiate(Tile4, transform); break;
            case 4: tempTile = Instantiate(Tile5, transform); break;
            case 5: tempTile = Instantiate(Tile6, transform); break;
            case 6: tempTile = Instantiate(Tile7, transform); break;
            case 7: tempTile = Instantiate(Tile8, transform); break;
            case 8: tempTile = Instantiate(Tile9, transform); break;
            case 9: tempTile = Instantiate(Tile10, transform); break;
            case 10: tempTile = Instantiate(Tile11, transform); break;
            case 11: tempTile = Instantiate(Tile12, transform); break;
            case 12: tempTile = Instantiate(Tile13, transform); break;
            case 13: tempTile = Instantiate(Tile14, transform); break;
            case 14: tempTile = Instantiate(Tile15, transform); break;
            case 15: tempTile = Instantiate(Tile16, transform); break;
            case 16: tempTile = Instantiate(Tile17, transform); break;
            case 17: tempTile = Instantiate(Tile18, transform); break;
            case 18: tempTile = Instantiate(Tile19, transform); break;
            case 19: tempTile = Instantiate(Tile20, transform); break;
            case 20: tempTile = Instantiate(Tile21, transform); break;
            case 21: tempTile = Instantiate(Tile22, transform); break;
            case 22: tempTile = Instantiate(Tile23, transform); break;
            case 23: tempTile = Instantiate(Tile24, transform); break;
            case 24: tempTile = Instantiate(Tile25, transform); break;
        }

        if (tempTile != null)
        {
            tempTile.transform.position = new Vector3(positionX, -0.25f, 0);
        }
    }
}
