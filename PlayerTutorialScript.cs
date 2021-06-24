using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorialScript : MonoBehaviour
{
    private GameObject button;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector3 defLoc = new Vector3(0.5f, -0.5f, 0f);
    private Vector3 moveLoc = new Vector3(0.5f, 0.5f, 0f);
    private Vector3 resetLoc = new Vector3(0.5f, -3.5f, 0f);

    private Vector3 moveTo;

    private void Start()
    {
        button = GameObject.Find("NextTextButton");
        moveTo = defLoc;
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("frogger deded");
        gameObject.SetActive(false);
        button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        return;
    }

    public void stepForward()
    {
        moveTo = moveLoc;
    }

    public void resetStep()
    {
        transform.position = resetLoc;
        moveTo = defLoc;
    }

    private void Update()
    {
        rb.position = Vector3.MoveTowards(rb.position, moveTo, Time.deltaTime * 3f);
        animator.SetFloat("Speed", rb.velocity.y * 3);
    }
}
