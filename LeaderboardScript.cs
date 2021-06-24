using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class LeaderboardScript : MonoBehaviour
{
    public Animator lbAnimator;
    private Animator mainAnimator;

    private PlayerData data;

    private TextMeshProUGUI scoresLB;

    private void Start()
    {
        data = GameObject.Find("GameManager").GetComponent<GameManager>().getData();
        scoresLB = GameObject.Find("LB").GetComponent<TextMeshProUGUI>();
        scoresLB.text = "";
        // fill data
        setLB();

        mainAnimator = GameObject.Find("MainMenu").GetComponent<Animator>();
    }

    private void setLB()
    {
        // fill scoresLB with data
        int[] s_highscores = (int[]) data.highscores.Clone();
        List<string> handled_names = new List<string>();
        Array.Sort(s_highscores);
        Array.Reverse(s_highscores);
        if(s_highscores.Length >= 5)
        {
            // interate through top 5
            for(int i = 0; i < 5; i++)
            {
                int index = Array.IndexOf(data.highscores, s_highscores[i]);
                while(handled_names.Contains(data.playernames[index]))
                {
                    index++;
                }
                handled_names.Add(data.playernames[index]);
                scoresLB.text += (i + 1) + ". " + data.playernames[index] + " - " + s_highscores[i] + "\n";
            }
        } else
        {
            // interate through s_highscores.Length
            for (int i = 0; i < s_highscores.Length; i++)
            {
                int index = Array.IndexOf(data.highscores, s_highscores[i]);
                while (handled_names.Contains(data.playernames[index]))
                {
                    index++;
                }
                handled_names.Add(data.playernames[index]);
                scoresLB.text += (i + 1) + ". " + data.playernames[index] + " - " + s_highscores[i] + "\n";
            }
        }
    }

    public void back()
    {
        lbAnimator.SetTrigger("Close");
        mainAnimator.SetTrigger("Open");
        StartCoroutine(Delay(lbAnimator.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}
