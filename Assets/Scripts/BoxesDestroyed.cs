using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyedBoxes : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(DestroyBox());
    }

    IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
