using UnityEngine;
using System;

[Serializable]
public class PlayerData
{
    public string[] playernames;
    public int[] highscores;

    public int[] lifetimeJumps;
    public int[] lifetimeSquishes;

    public void FindIndex(string name)
    {
        //Debug.Log("findindex method");
        int index = -1;
        try
        {
            index = Array.IndexOf(playernames, name);
        } catch(ArgumentNullException)
        {
            createBlank();
        }
        if (index == -1)
        {
            CreateRecord(name);
        }
        index = Array.IndexOf(playernames, name);
        PlayerPrefs.SetInt("index", index);
        PlayerPrefs.Save();
    }

    public void CreateRecord(string name)
    {
        Array.Resize(ref playernames, playernames.Length + 1);
        playernames[playernames.Length - 1] = name;

        Array.Resize(ref highscores, highscores.Length + 1);
        highscores[highscores.Length - 1] = 0;

        Array.Resize(ref lifetimeJumps, lifetimeJumps.Length + 1);
        lifetimeJumps[lifetimeJumps.Length - 1] = 0;

        Array.Resize(ref lifetimeSquishes, lifetimeSquishes.Length + 1);
        lifetimeSquishes[lifetimeSquishes.Length - 1] = 0;
    }

    public void UpdateRecords(int hs, int jumps, int squish)
    {
        int index = PlayerPrefs.GetInt("index");
        if(hs > highscores[index])
        {
            highscores[index] = hs;
        }
        lifetimeJumps[index] += jumps;
        lifetimeSquishes[index] += squish;
    }

    public void createBlank()
    {
        playernames = new string[1];
        playernames[0] = "";
        highscores = new int[1];
        highscores[0] = 0;
        lifetimeJumps = new int[1];
        lifetimeJumps[0] = 0;
        lifetimeSquishes = new int[1];
        lifetimeSquishes[0] = 0;
    }

    public void printData()
    {
        for(int i = 0; i < playernames.Length; i++)
        {
            Debug.Log(playernames[i] + ", " + highscores[i] + ", " + lifetimeJumps[i] + ", " + lifetimeSquishes[i]);
        }
    }
}
