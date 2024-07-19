using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int ScoreInt = 0;

    public void ScorePlusOne()
    {
        ScoreInt++;
    }

    public void ScorePlusFive() 
    { 
        ScoreInt += 5;
    }

    public string GetScore ()
    {
        return ScoreInt.ToString();
    }
}