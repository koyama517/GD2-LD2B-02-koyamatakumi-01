using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePoint : MonoBehaviour
{
    bool isRide = false;
    public bool isActive;

    BoxCollider2D col;

    public GameObject turnPointPrefab;
    GameObject turnPoint;

    SpriteRenderer sprite;

    public GameObject player;
    public GameObject peaPoint;

    private float error = 0.1f;
    private float angle;

    public bool isSide;

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
        SceneManegar mane;
        GameObject manegar = GameObject.Find("Main Camera");
        mane = manegar.GetComponent<SceneManegar>();
        if (mane != null)
        {
            if (mane.isStart)
            {
                if (isActive)
                {
                    sprite.color = new Color(1, 1f, 1);
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
                if (isRide)
                {
                    Active();
                    Rotate();
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, 1);
    }

    private void CheckRide()
    {
        
       


        if (player != null)
        {
            if (isSide)
            {
                if (gameObject.transform.position.y + error >= player.transform.position.y &&
                    gameObject.transform.position.y - error <= player.transform.position.y)
                {
                    isRide = true;
                }
                else
                {
                    isRide = false;
                }
            }
            else
            {
                if (gameObject.transform.position.x + error >= player.transform.position.x &&
                gameObject.transform.position.x - error <= player.transform.position.x)
                {
                    isRide = true;
                }
                else
                {
                    isRide = false;
                }
            }
        }
    }

    private void Active()
    {
        PeaPoint peaPointScript;
        peaPointScript = peaPoint.GetComponent<PeaPoint>();
        if (peaPoint != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isActive)
                {
                    isActive = true;
                }
                else
                {
                    isActive = false;
                }
                peaPointScript.isActive = isActive;
            }
        }
    }
}
