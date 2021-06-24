using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;
    public Sprite[] sprites;

    [SerializeField] private SpriteRenderer sr;

    void Start()
    {
        StartCoroutine(SelfDestruct());
        int index = Random.Range(0, sprites.Length);
        sr.sprite = sprites[index];
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
}
