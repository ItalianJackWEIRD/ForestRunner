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

    public bool canDestroyBoxes = false;

    public GameObject destroyedVersion;

    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(canDestroyBoxes)
        {
        ScoreText.ScorePlusFive();
        myAnimationController.SetBool("crashBool", true);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);//box
        }
        else
        {
            SceneManager.LoadScene("Main");//game over and reload scene
        }
    }
}
