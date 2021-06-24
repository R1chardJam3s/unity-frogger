using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    private static PlayerData data;

    public static GameManager instance { get; private set; }

    // Ensures that the GameManager is not destory across scenes.
    private void Awake()
    {
        //SaveSystem.resetSave();
        if(instance)
        {
            Destroy(gameObject);
        } 
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            try
            {
                SaveSystem.LoadPlayers();
            }
            catch (Exception)
            {
                data = new PlayerData();
            }
            data.printData();
        }
    }

    public PlayerData getData()
    {
        return data;
    }

    public void setData(PlayerData d)
    {
        data = d;
    }

    public void Save()
    {
        string text = PlayerPrefs.GetString("name");
        data.FindIndex(text);
        data.UpdateRecords(PlayerPrefs.GetInt("score"), PlayerPrefs.GetInt("jump"), PlayerPrefs.GetInt("squish"));
        SaveSystem.SavePlayers();
        data.printData();
    }

    public void rs()
    {
        SaveSystem.resetSave();
        PlayerPrefs.SetString("name", "");
        PlayerPrefs.Save();
        Application.Quit();
    }
}

/*
 * As soon as game launches, gamemanager loads the data in the game.
 * 
 * the user inputs name at the end and their stats are updated
 * 
 */