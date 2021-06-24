using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccountMenu : MonoBehaviour
{
    private TextMeshProUGUI loginText;
    private string playername;

    private void Awake()
    {
        loginText = GameObject.Find("LoggedInText").GetComponent<TextMeshProUGUI>();
        updateName();
    }

    public void updateName()
    {
        playername = PlayerPrefs.GetString("name","---");
        loginText.text = "LOGGED IN AS: " + playername;
    }
}
