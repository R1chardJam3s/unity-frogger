using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinScoreScript : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
    }
}
