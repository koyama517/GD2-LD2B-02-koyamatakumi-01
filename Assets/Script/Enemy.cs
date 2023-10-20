using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = 5f;

    Rigidbody2D rb;

    private Vector2 moveDirection = new Vector2(1, 0);

    public float angle;
    public bool isCollision;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(angle >= 360)
        {
            angle = 0;
        }

        Vector2 enemyVector = Quaternion.Euler(0, 0, angle) * Vector2.right;

        rb.velocity = enemyVector * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            if (!isCollision)
            {
                angle += 90;
                isCollision = true;
            }
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision = false;
    }

}
