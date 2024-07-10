using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private PUManager manager;

    private Shake shake;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            if (manager.GetLives()<2)
                SceneManager.LoadScene("Menu");//game over and reload scene
            else    //decrementa vita e shake schermo e distruggi game object
            {
                manager.LifeMinus1();
                shake.camShake();
                Destroy(other.gameObject);
            }
        }
        else if (other.tag == "River" || other.tag == "DeathBarrier")
            SceneManager.LoadScene("Menu");//game over and reload scene
    }
}
