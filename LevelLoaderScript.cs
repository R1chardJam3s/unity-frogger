using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void LoadScene(int bIndex)
    {
        StartCoroutine(Load(bIndex));
    }

    IEnumerator Load(int index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }
}
