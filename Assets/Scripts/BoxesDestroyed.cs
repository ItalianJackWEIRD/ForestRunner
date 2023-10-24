using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyedBoxes : MonoBehaviour
{
    private float moveSpeed = 4;

    void Start()
    {
        StartCoroutine(DestroyBox());
    }

    void Update()
    {
        gameObject.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);  //tiles movment X direction axis
    }

    IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
