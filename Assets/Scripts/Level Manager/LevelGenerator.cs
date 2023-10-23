﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float moveSpeed;
    public int random;

    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;
    public GameObject StartTile;

    private float Index = 0;

    private void Start()
    {
        //create 5 tile first game
        GameObject StartPlane1 = Instantiate(StartTile, transform);
        StartPlane1.transform.position = new Vector3(7, 0, 0);
        
        GameObject StartPlane2 = Instantiate(StartTile, transform);
        StartPlane2.transform.position = new Vector3(-1, 0, 0);
       
        GameObject StartPlane3 = Instantiate(StartTile, transform);
        StartPlane3.transform.position = new Vector3(-9, 0, 0);
       
        GameObject StartPlane4 = Instantiate(StartTile, transform);
        StartPlane4.transform.position = new Vector3(-17, 0, 0);
       
        GameObject StartPlane5 = Instantiate(StartTile, transform);
        StartPlane5.transform.position = new Vector3(-25, 0, 0);
    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);  //tiles movment X direction axis

        if(transform.position.x >= Index)
        {
            int RandomInt1 = Random.Range(0, random);

            if(RandomInt1 == 0)
            {
                GameObject TempTile1 = Instantiate(Tile1, transform);
                TempTile1.transform.position = new Vector3(-24, 0, 0);
            }
            else if(RandomInt1 == 1)
            {
                GameObject TempTile1 = Instantiate(Tile2, transform);
                TempTile1.transform.position = new Vector3(-24, 0, 0);
            }
            else if (RandomInt1 == 2)
            {
                GameObject TempTile1 = Instantiate(Tile3, transform);
                TempTile1.transform.position = new Vector3(-24, 0, 0);
            }

            int RandomInt2 = Random.Range(0, random);

            if(RandomInt2 == 0)
            {
                GameObject TempTile2 = Instantiate(Tile1, transform);
                TempTile2.transform.position = new Vector3(-32, 0, 0);
            }
            else if(RandomInt2 == 1)
            {
                GameObject TempTile2 = Instantiate(Tile2, transform);
                TempTile2.transform.position = new Vector3(-32, 0, 0);
            }
            else if (RandomInt2 == 2)
            {
                GameObject TempTile2 = Instantiate(Tile3, transform);
                TempTile2.transform.position = new Vector3(-32, 0, 0);
            }

            int RandomInt3 = Random.Range(0, random);

            if (RandomInt3 == 0)
            {
                GameObject TempTile3 = Instantiate(Tile1, transform);
                TempTile3.transform.position = new Vector3(-40, 0, 0);
            }
            else if (RandomInt3 == 1)
            {
                GameObject TempTile3 = Instantiate(Tile2, transform);
                TempTile3.transform.position = new Vector3(-40, 0, 0);
            }
            else if (RandomInt3 == 2)
            {
                GameObject TempTile3 = Instantiate(Tile3, transform);
                TempTile3.transform.position = new Vector3(-40, 0, 0);
            }

            Index = Index + 23.95f;
        }
    }
}
