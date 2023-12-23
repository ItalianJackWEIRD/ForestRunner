using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PowerUpCoin : MonoBehaviour
{
    private PUManager powerUp;

    private void Start()
    {
        powerUp = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        powerUp.Set1();
        Destroy(gameObject);
    }
}
