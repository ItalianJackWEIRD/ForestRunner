using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public int secondsToWait;

    private string parentName;

 
    void Update()
    {
        parentName = transform.name;
        //while ( asp == false)
        //{
        //    Wait();
        //}
        StartCoroutine(DestroyClone());
    }

    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(5);
    //    asp = true;
    //}


    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(secondsToWait);
        if (parentName == "Tile1(Clone)" || parentName == "Tile2(Clone)" || parentName == "Tile3(Clone)" || parentName == "Tile4(Clone)" || parentName == "Tile5(Clone)" || parentName == "TileBase1(Clone)" || parentName == "TileBase2(Clone)" || parentName == "TileBase3(Clone)" || parentName == "TileBase4(Clone)" || parentName == "TileBase5(Clone)" || parentName == "TileBase6(Clone)") 
        {
            Destroy(gameObject);
        }
    }

   
}
