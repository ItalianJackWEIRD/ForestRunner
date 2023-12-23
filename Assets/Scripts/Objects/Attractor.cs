using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private PUManager player;

    public float AttractorSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.Get1())    //se il player è dentro il raggio d'azione e il power up è attivo
        {
            transform.parent.gameObject.transform.position = Vector3.MoveTowards(transform.position, other.transform.position, AttractorSpeed * Time.deltaTime);
        }
    }
}
