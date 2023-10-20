using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActivePoint : MonoBehaviour
{
    public bool isRide = false;
    public bool isActive;

    BoxCollider2D col;

    public GameObject turnPointPrefab;
    GameObject turnPoint;

    SpriteRenderer sprite;

    public GameObject player;

    private float error = 0.1f;



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

        CheckRide();

    }

    private void CheckRide()
    {
        if(gameObject.transform.position.y + error >= player.transform.position.y &&
            gameObject.transform.position.y - error <= player.transform.position.y)
        {
            isRide = true;
        }
        else
        {
            isRide = false;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
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
    }*/
}
