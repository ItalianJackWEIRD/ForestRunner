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
        if (parentName == "Tile1(Clone)" || parentName == "Tile2(Clone)" || parentName == "Tile3(Clone)" || parentName == "Tile4(Clone)" || parentName == "Tile5(Clone)" || parentName == "Tile6(Clone)" || parentName == "Tile7(Clone)" || parentName == "Tile8(Clone)" || parentName == "Tile9(Clone)" || parentName == "Tile10(Clone)" || parentName == "Tile11(Clone)" || parentName == "Tile12(Clone)" || parentName == "Tile13(Clone)" || parentName == "Tile14(Clone)" || parentName == "Tile15(Clone)" || parentName == "Tile16(Clone)" || parentName == "Tile17(Clone)" || parentName == "Tile18(Clone)" || parentName == "Tile19(Clone)" || parentName == "Tile20(Clone)" || parentName == "TileBase1(Clone)" || parentName == "TileBase2(Clone)" || parentName == "TileBase3(Clone)" || parentName == "TileBase4(Clone)" || parentName == "TileBase5(Clone)" || parentName == "TileBase6(Clone)") 
        {
            Destroy(gameObject);
        }
    }

   
}
