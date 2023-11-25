using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Movement mov;
    // Start is called before the first frame update
    void Start()
    {
        mov = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        mov.onTheWater = true;
        wait();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        mov.onTheWater = false;
    }
}
