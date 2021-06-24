using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpriteScript : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
}
