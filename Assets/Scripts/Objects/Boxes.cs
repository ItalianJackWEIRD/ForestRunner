using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Boxes : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    private Score ScoreText;
    private Attack canDestroyBoxes;
    private Movement player;

    public GameObject destroyedVersion;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();
        canDestroyBoxes = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(canDestroyBoxes.canDestroy())
        {
            destroyBox();
        }
        else
        {
            SceneManager.LoadScene("Main");//game over and reload scene
        }
    }

    public void destroyBox()
    {
        myAnimationController.SetBool("crashBool", true);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);//box
        ScoreText.ScorePlusFive();
    }


}