using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int ScoreInt;
    public Text ScoreText;

    public void ScorePlusOne()
    {
        ScoreInt++;
    }

    public void ScorePlusFive() 
    { 
        ScoreInt = ScoreInt + 5;
    }

    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
    }
}
