using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaPoint : MonoBehaviour
{
    public bool isRide = false;
    public bool isActive;

    BoxCollider2D col;

    public GameObject turnPointPrefab;
    GameObject turnPoint;

    
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(0.6f, 0.6f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            sprite.color = new Color(0.5f, 1f, 0.7f);
            if (turnPoint == null)
            {
                turnPoint = Instantiate(turnPointPrefab, transform);
            }
        }
        else
        {
            sprite.color = new Color(0.6f, 0.6f, 0.6f);
            if (turnPoint != null)
            {
                Destroy(turnPoint);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isRide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isRide = false;
        }
    }
}
