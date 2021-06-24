using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{

    private ScoreManager scoreManager;
    private GoalManager goalManager;
    private GameObject playerPos;

    private TimerScript timer;

    public void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        goalManager = GameObject.Find("GoalManager").GetComponent<GoalManager>();
        playerPos = GameObject.Find("Player");

        timer = GameObject.Find("TimerText").GetComponent<TimerScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("YOU WON");
        scoreManager.addScore(50);
        scoreManager.addScore((int)Math.Round(timer.getTime() * 2));
        if(goalManager.acheiveGoal(Math.Round(playerPos.transform.position.x)))
        {
            scoreManager.addScore(1000);
            Debug.Log("GAME COMPLETE");
            PlayerPrefs.SetInt("score", scoreManager.getScore());
            PlayerPrefs.Save();
            GameObject.Find("LevelLoader").GetComponent<LevelLoaderScript>().LoadScene(2);
        }
        playerPos.GetComponent<PlayerBehaviour>().die();
    }
}
