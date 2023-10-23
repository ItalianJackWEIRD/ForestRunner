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
        if (parentName == "Tile 1(Clone)" || parentName == "Tile 2(Clone)" || parentName == "Tile 3(Clone)" || parentName == "Tile(Clone)" || parentName == "TileNEW(Clone)") 
        {
            Destroy(gameObject);
        }
    }

   
}
