using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    private bool[] goalsAcheived;
    private SpriteRenderer[] goals;

    private bool complete;

    private void Start()
    {
        getGoals();
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < goals.Length; i++)
        {
            goals[i].enabled = goalsAcheived[i];
        }
    }

    void getGoals()
    {
        goals = GameObject.Find("MainGoal").GetComponentsInChildren<SpriteRenderer>();
        goalsAcheived = new bool[goals.Length];
    }

    public bool acheiveGoal(double x)
    {
        for(int i = 0; i < goals.Length; i++)
        {
            if(goals[i].transform.position.x == x)
            {
                goalsAcheived[i] = true;
            }
        }
        return checkComplete();
    }

    public bool checkGoal(float x, float y)
    {
        for(int i = 0; i < goals.Length; i++)
        {
            if (goals[i].enabled)
            {
                if (goals[i].transform.position.x == x && goals[i].transform.position.y == y)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool checkComplete()
    {
        complete = true;
        for(int i = 0; i < goalsAcheived.Length; i++)
        {
            //Debug.Log("Goal " + i + " " + goalsAcheived[i]);
            complete = complete && goalsAcheived[i];
        }
        return complete;
    }
}
