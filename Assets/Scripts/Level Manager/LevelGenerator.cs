using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float moveSpeed;
    public int random;

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
    public GameObject StartTile5;
    public GameObject StartTile6;

    private float Index = 0;
    private int lastRandom;

    private void Start()
    {
        //create 5 tile first game
        GameObject StartPlane1 = Instantiate(StartTile1, transform);
        StartPlane1.transform.position = new Vector3(7, -0.25f, 0);
        
        GameObject StartPlane2 = Instantiate(StartTile2, transform);
        StartPlane2.transform.position = new Vector3(-1, -0.25f, 0);
       
        GameObject StartPlane3 = Instantiate(StartTile3, transform);
        StartPlane3.transform.position = new Vector3(-9, -0.25f, 0);
       
        GameObject StartPlane4 = Instantiate(StartTile4, transform);
        StartPlane4.transform.position = new Vector3(-17, -0.25f, 0);
       
        GameObject StartPlane5 = Instantiate(StartTile5, transform);
        StartPlane5.transform.position = new Vector3(-25, -0.25f, 0);

        GameObject StartPlane6 = Instantiate(StartTile6, transform);
        StartPlane6.transform.position = new Vector3(-33, -0.25f, 0);
    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);  //tiles movment X direction axis

        if(transform.position.x >= Index)
        {
            int RandomInt1 = Random.Range(0, random);
            while (RandomInt1 == lastRandom)
            {
                RandomInt1 = Random.Range(0, random);
            }

            if (RandomInt1 == 0)
            {
                GameObject TempTile1 = Instantiate(Tile1, transform);
                TempTile1.transform.position = new Vector3(-40, -0.25f, 0);
            }
            else if(RandomInt1 == 1)
            {
                GameObject TempTile1 = Instantiate(Tile2, transform);
                TempTile1.transform.position = new Vector3(-40, -0.25f, 0);
            }
            else if (RandomInt1 == 2)
            {
                GameObject TempTile1 = Instantiate(Tile3, transform);
                TempTile1.transform.position = new Vector3(-40, -0.25f, 0);
            }
            else if (RandomInt1 == 3)
            {
                GameObject TempTile1 = Instantiate(Tile4, transform);
                TempTile1.transform.position = new Vector3(-40, -0.25f, 0);
            }
            else if (RandomInt1 == 4)
            {
                GameObject TempTile1 = Instantiate(Tile5, transform);
                TempTile1.transform.position = new Vector3(-40, -0.25f, 0);
            }
            else if(RandomInt1 == 5)
            {
                GameObject TempTile1 = Instantiate(Tile6, transform);
                TempTile1.transform.position = new Vector3(-40, -0.25f, 0);
            }
            else if (RandomInt1 == 6)
            {
                GameObject TempTile1 = Instantiate(Tile7, transform);
                TempTile1.transform.position = new Vector3(-40, -0.25f, 0);
            }
            else if (RandomInt1 == 7)
            {
                GameObject TempTile1 = Instantiate(Tile8, transform);
                TempTile1.transform.position = new Vector3(-40, -0.25f, 0);
            }
            else if (RandomInt1 == 8)
            {
                GameObject TempTile1 = Instantiate(Tile9, transform);
                TempTile1.transform.position = new Vector3(-40, -0.25f, 0);
            }


            int RandomInt2 = Random.Range(0, random);
            while (RandomInt2 == RandomInt1)
            {
                RandomInt2 = Random.Range(0, random);
            }

            if (RandomInt2 == 0)
            {
                GameObject TempTile2 = Instantiate(Tile1, transform);
                TempTile2.transform.position = new Vector3(-48, -0.25f, 0);
            }
            else if(RandomInt2 == 1)
            {
                GameObject TempTile2 = Instantiate(Tile2, transform);
                TempTile2.transform.position = new Vector3(-48, -0.25f, 0);
            }
            else if (RandomInt2 == 2)
            {
                GameObject TempTile2 = Instantiate(Tile3, transform);
                TempTile2.transform.position = new Vector3(-48, -0.25f, 0);
            }
            else if (RandomInt2 == 3)
            {
                GameObject TempTile2 = Instantiate(Tile4, transform);
                TempTile2.transform.position = new Vector3(-48, -0.25f, 0);
            }
            else if (RandomInt2 == 4)
            {
                GameObject TempTile2 = Instantiate(Tile5, transform);
                TempTile2.transform.position = new Vector3(-48, -0.25f, 0);
            }
            else if (RandomInt2 == 5)
            {
                GameObject TempTile2 = Instantiate(Tile6, transform);
                TempTile2.transform.position = new Vector3(-48, -0.25f, 0);
            }
            else if (RandomInt2 == 6)
            {
                GameObject TempTile2 = Instantiate(Tile7, transform);
                TempTile2.transform.position = new Vector3(-48, -0.25f, 0);
            }
            else if (RandomInt2 == 7)
            {
                GameObject TempTile2 = Instantiate(Tile8, transform);
                TempTile2.transform.position = new Vector3(-48, -0.25f, 0);
            }
            else if (RandomInt2 == 8)
            {
                GameObject TempTile2 = Instantiate(Tile9, transform);
                TempTile2.transform.position = new Vector3(-48, -0.25f, 0);
            }

            int RandomInt3 = Random.Range(0, random);
            while (RandomInt3 == RandomInt2)
            {
                RandomInt3 = Random.Range(0, random);
            }
            lastRandom = RandomInt3;

            if (RandomInt3 == 0)
            {
                GameObject TempTile3 = Instantiate(Tile1, transform);
                TempTile3.transform.position = new Vector3(-56, -0.25f, 0);
            }
            else if (RandomInt3 == 1)
            {
                GameObject TempTile3 = Instantiate(Tile2, transform);
                TempTile3.transform.position = new Vector3(-56, -0.25f, 0);
            }
            else if (RandomInt3 == 2)
            {
                GameObject TempTile3 = Instantiate(Tile3, transform);
                TempTile3.transform.position = new Vector3(-56, -0.25f, 0);
            }
            else if (RandomInt3 == 3)
            {
                GameObject TempTile3 = Instantiate(Tile4, transform);
                TempTile3.transform.position = new Vector3(-56, -0.25f, 0);
            }
            else if (RandomInt3 == 4)
            {
                GameObject TempTile3 = Instantiate(Tile5, transform);
                TempTile3.transform.position = new Vector3(-56, -0.25f, 0);
            }
            else if (RandomInt3 == 5)
            {
                GameObject TempTile3 = Instantiate(Tile6, transform);
                TempTile3.transform.position = new Vector3(-56, -0.25f, 0);
            }
            else if (RandomInt3 == 6)
            {
                GameObject TempTile3 = Instantiate(Tile7, transform);
                TempTile3.transform.position = new Vector3(-56, -0.25f, 0);
            }
            else if (RandomInt3 == 7)
            {
                GameObject TempTile3 = Instantiate(Tile8, transform);
                TempTile3.transform.position = new Vector3(-56, -0.25f, 0);
            }
            else if (RandomInt3 == 8)
            {
                GameObject TempTile3 = Instantiate(Tile9, transform);
                TempTile3.transform.position = new Vector3(-56, -0.25f, 0);
            }

            Index = Index + 24f;
        }
    }
}
