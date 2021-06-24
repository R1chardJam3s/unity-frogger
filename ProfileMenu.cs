using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProfileMenu : MonoBehaviour
{
    public Animator profileAnimator;
    private Animator mainAnimator;

    private GameManager gm;
    private TMP_Dropdown dropdown;
    private TextMeshProUGUI statsText;

    [SerializeField] private Sprite[] badges;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        dropdown = GameObject.Find("ProfileDropdown").GetComponent<TMP_Dropdown>();
        statsText = GameObject.Find("StatsText").GetComponent<TextMeshProUGUI>();
        loadProfiles();
        List<TMP_Dropdown.OptionData> menuOptions = dropdown.options;
        dropdown.value = menuOptions.FindIndex(option => option.text == PlayerPrefs.GetString("name"));
        loadStats();

        mainAnimator = GameObject.Find("MainMenu").GetComponent<Animator>();
    }

    private void loadProfiles()
    {
        List<string> names = new List<string>();
        for(int i = 0; i < gm.getData().playernames.Length; i++)
        {
            names.Add(gm.getData().playernames[i]);
        }
        dropdown.AddOptions(names);
    }

    public void loadStats()
    {
        List<TMP_Dropdown.OptionData> menuOptions = dropdown.options;
        string name = menuOptions[dropdown.value].text;
        PlayerPrefs.SetString("name", name);
        PlayerPrefs.Save();
        int index = Array.IndexOf(gm.getData().playernames, name);
        int hs = gm.getData().highscores[index];
        int sq = gm.getData().lifetimeSquishes[index];
        setText(hs, sq);
        setBadge(hs);
    }

    private void setText(int hs, int sq)
    {
        statsText.text = "";
        statsText.text += "Highscore: " + hs;
        statsText.text += "\nTotal Squishes: " + sq;
    }

    public void createProfile()
    {
        string name = GameObject.Find("CreateProfIF").GetComponent<TMP_InputField>().text;
        gm.getData().CreateRecord(name);
        clearProfileList();
        loadProfiles();
        List<TMP_Dropdown.OptionData> menuOptions = dropdown.options;
        dropdown.value = menuOptions.FindIndex(option => option.text == name);
        loadStats();
        SaveSystem.SavePlayers();
    }

    public void clearProfileList()
    {
        //Debug.Log(dropdown.options.Count);
        for(int i = 0; i < dropdown.options.Count; i++)
        {
            dropdown.options.RemoveAt(i);
        }
    }

    private void setBadge(int score)
    {
        if (score >= 2000) {
            GameObject.Find("Badge").GetComponent<Image>().sprite = badges[0];
        } else if (score >= 1000)
        {
            GameObject.Find("Badge").GetComponent<Image>().sprite = badges[1];
        } else if (score >= 500)
        {
            GameObject.Find("Badge").GetComponent<Image>().sprite = badges[2];
        } else {
            // unranked
            GameObject.Find("Badge").GetComponent<Image>().sprite = badges[3];
        }
    }

    public void back()
    {
        profileAnimator.SetTrigger("Close");
        mainAnimator.SetTrigger("Open");
        StartCoroutine(Delay(profileAnimator.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}
