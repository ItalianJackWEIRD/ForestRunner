using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject powerUp3;

    public int random;
    public int numberOfPowerUps;

    // Start is called before the first frame update
    void Start()
    {
        int RandomInt = Random.Range(0, random);
        if (RandomInt == 0)
        {
            int RandomPower = Random.Range(0, numberOfPowerUps);
            if (RandomPower == 0 )
                Instantiate(powerUp1, transform);

        }
        
    }
}
