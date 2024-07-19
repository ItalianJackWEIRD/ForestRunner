using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinX5 : MonoBehaviour
{
    private Score ScoreText;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
       
    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, 3.5f);//rotate coin
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreText.ScorePlusFive();
        Destroy(gameObject);//coin
    }
}