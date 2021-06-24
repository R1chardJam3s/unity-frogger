using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float timeValue = 30;

    private Text text;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        } else
        {
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().die();
            timeValue = 30;
        }
        text.text = "Time: " + Math.Round(timeValue);
    }

    public void resetTimer()
    {
        timeValue = 30;
    }

    public float getTime()
    {
        return timeValue;
    }
}
