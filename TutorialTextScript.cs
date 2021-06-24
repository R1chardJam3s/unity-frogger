using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialTextScript : MonoBehaviour
{
    private GameObject frogger;

    private TextMeshProUGUI text;
    private GameObject button;

    private GameObject lorry;
    private GameObject log;

    private GameObject road;

    private int state;

    private string movementText = "Movement in Frogger is controlled by W, A and D." +
        "\n The aim is to move from the bottom of the map to the top into a goal.";

    private string movement2Text = "Unlike the original, this game aims to be harder by not allowing the player to" +
        "\n move downwards. You must think ahead a little more now... muhwhahaha";

    private string lorryText = "There are obstacles on the map. Lorries are able to squish you" +
        "\n This removes a frogs' life and resets your location to the starting point.";

    private string waterText = "In Frogger, water can also drown you!" +
        "\n In order to be safe from the water, you will need to be on a log.";

    private void Awake()
    {
        frogger = GameObject.Find("Player");
        text = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();
        button = GameObject.Find("NextTextButton");
        lorry = GameObject.Find("Lorry");
        lorry.SetActive(false);
        log = GameObject.Find("Log");
        log.SetActive(false);
        road = GameObject.Find("RoadGrid");
    }

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        load();
    }

    public void load()
    {
        switch(state)
        {
            case (0):
                loadMovementText();
                break;

            case (1):
                loadMovement2Text();
                break;

            case (2):
                loadLorryText();
                break;

            case (3):
                text.text = "...";
                lorry.SetActive(true);
                button.SetActive(false);
                break;

            case (4):
                text.text = "*SQUISH*";
                break;

            case (5):
                road.SetActive(false);
                frogger.SetActive(true);
                loadWaterText();
                break;

            case (6):
                text.text = "...";
                button.SetActive(false);
                frogger.GetComponent<PlayerTutorialScript>().stepForward();
                break;

            case (7):
                text.text = "Let's try that again - but with something to step on.";
                GameObject.Find("WaterGrid").GetComponent<BoxCollider2D>().enabled = false;
                frogger.SetActive(true);
                frogger.GetComponent<PlayerTutorialScript>().resetStep();
                log.SetActive(true);
                break;

            case (8):
                text.text = "For some extra added difficulty, the logs are unable" +
                    "\n to be moved horizontally on, otherwise they become unstable!";
                frogger.GetComponent<PlayerTutorialScript>().stepForward();
                break;

            case (9):
                text.text = ".. And that's the end of the tutorial! Good luck!";
                break;

            case (10):
                SceneManager.LoadScene(0);
                break;
        }
        state++;
    }

    private void loadMovementText()
    {
        text.text = movementText;
    }

    private void loadMovement2Text()
    {
        text.text = movement2Text;
    }

    private void loadLorryText()
    {
        text.text = lorryText;
    }

    private void loadWaterText()
    {
        text.text = waterText;
    }
}
