using UnityEngine;
using System.Collections;

public class LogScript : MonoBehaviour
{

    private GameObject player;
    private GameObject movePoint;

    public Rigidbody2D rb;
    public float speed = 1f;

    void Start()
    {
        player = GameObject.Find("Player");
        //movePoint = GameObject.Find("Player Move Point");
        StartCoroutine(SelfDestruct());
    }

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x * -1, transform.right.y * -1);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(20f);
        Destroy(this.gameObject);
    }

    public void onLogEnter()
    {
        //Debug.Log("enter");
        player.transform.parent = gameObject.transform;
        //movePoint.transform.parent = gameObject.transform;
    }
}
