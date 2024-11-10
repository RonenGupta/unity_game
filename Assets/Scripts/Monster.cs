using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int dir = 1;
    public float speed = 2.0f;
    private Rigidbody2D body2D;
    private SpriteRenderer spriteRenderer;

    void Start() {
        body2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void toggleDir() {
        dir *= -1;
        Flip();
    }

    void Flip() {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        body2D.velocity = new Vector2(dir * speed, body2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag != "Player") {
            toggleDir();
        }
    }
}

