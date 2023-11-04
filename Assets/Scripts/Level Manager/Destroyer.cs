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
        if (parentName == "TileNew(Clone)" || parentName == "TileNewBase(Clone)" || parentName == "Tile 3(Clone)" || parentName == "Tile(Clone)" || parentName == "TileNEW(Clone)") 
        {
            Destroy(gameObject);
        }
    }

   
}
