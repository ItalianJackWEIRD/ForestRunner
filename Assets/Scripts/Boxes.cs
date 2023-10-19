using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Boxes : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    private Score ScoreText;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreText.ScorePlusFive();
        myAnimationController.SetBool("crashBool", true);
        Destroy(gameObject);//box
        
    }
}
