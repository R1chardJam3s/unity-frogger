using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public Animator mainAnimator;
    public GameObject leaderboard;
    public GameObject profileScreen;
    public GameObject creditsScreen;

    private void Start()
    {
        updateProfile();
    }

    public void PlayGame()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoaderScript>().LoadScene(1);
    }

    public void PlayTutorial()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoaderScript>().LoadScene(3);
    }

    public void QuitGame()
    {
        Debug.Log("App:QUIT");
        Application.Quit();
    }

    public void updateProfile()
    {
        GameObject.Find("ProfSelectText").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("name");
    }

    public void loadLB()
    {
        mainAnimator.SetTrigger("Close");
        leaderboard.SetActive(true);
        //StartCoroutine(Delay(mainAnimator.GetCurrentAnimatorStateInfo(0).length));
    }

    public void loadProfiles()
    {
        mainAnimator.SetTrigger("Close");
        profileScreen.SetActive(true);
    }

    public void loadCredits()
    {
        mainAnimator.SetTrigger("Close");
        creditsScreen.SetActive(true);
    }

    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        leaderboard.SetActive(true);
    }

}
