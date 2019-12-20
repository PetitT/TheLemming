using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI tmp;

    private int score;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;

        DisplayScore();
    }

    public void ChangeScore(int value)
    {
        score += value;
        if (score < 0)
            score = 0;

        DisplayScore();
    }

    private void DisplayScore()
    {
        tmp.text = score.ToString();
    }
}
