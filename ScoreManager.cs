using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    private Text text;

    private void Start()
    {
        text = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "Score: " + score;
    }

    public void addScore(int _score)
    {
        score += _score;
    }

    public int getScore()
    {
        return score;
    }
}
