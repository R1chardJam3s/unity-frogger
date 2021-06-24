using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesScript : MonoBehaviour
{
    private ScoreManager scoreManager;

    private int frogsLeft = 7;

    private Text text;
    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public void takeLife()
    {
        frogsLeft--;
        if(frogsLeft == 0)
        {
            PlayerPrefs.SetInt("score", scoreManager.getScore());
            PlayerPrefs.Save();
            SceneManager.LoadScene(2);
        }
    }

    private void Update()
    {
        text.text = "Frogs Left: " + frogsLeft;
    }
}
