using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public Animator creditsAnimator;
    private Animator mainAnimator;

    private void Start()
    {
        mainAnimator = GameObject.Find("MainMenu").GetComponent<Animator>();
    }

    public void back()
    {
        creditsAnimator.SetTrigger("Close");
        mainAnimator.SetTrigger("Open");
        StartCoroutine(Delay(creditsAnimator.GetCurrentAnimatorStateInfo(0).length));
    }

    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}
