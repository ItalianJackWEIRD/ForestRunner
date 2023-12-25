using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJumo : MonoBehaviour
{
    private PUManager powerUp;

    private void Start()
    {
        powerUp = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        powerUp.Set3();
        Destroy(gameObject);
    }
}
