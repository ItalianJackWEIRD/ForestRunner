using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int ScoreInt = 0;
    private string ScoreText;

    public void ScorePlusOne()
    {
        ScoreInt++;
    }

    public void ScorePlusFive() 
    { 
        ScoreInt += 5;
    }

    private void Update()
    {
        ScoreText = ScoreInt.ToString();
    }

    public string GetScore ()
    {
        return ScoreText;
    }
}
