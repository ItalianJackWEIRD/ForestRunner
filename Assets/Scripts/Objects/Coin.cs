using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Score ScoreText;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
       
    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, 4.5f);//rotate coin
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ScoreText.ScorePlusOne();
            Destroy(gameObject);//coin
        }
    }
}
