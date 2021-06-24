using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class OptionAnimator : MonoBehaviour
{
    public Animator animator;

    public GameObject mainMenu;
    public GameObject optionMenu;

    public void back()
    {
        animator.SetTrigger("Close");
        StartCoroutine(Delay(animator.GetCurrentAnimatorStateInfo(0).length));

    }

    IEnumerator Delay(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
}
