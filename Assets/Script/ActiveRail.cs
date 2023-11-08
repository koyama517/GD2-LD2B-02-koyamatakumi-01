using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRail : MonoBehaviour
{

    SpriteRenderer sprite;

    public GameObject activePoint;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(0.1f, 0.3f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        ActivePoint turnPoint;
        turnPoint = activePoint.GetComponent<ActivePoint>();
        if (turnPoint != null)
        {
            if (turnPoint.isActive)
            {
                sprite.color = new Color(0.45f, 1, 0.7f);
            }
            else
            {
                sprite.color = new Color(0.1f, 0.3f, 0.2f);
            }
        }
    }
}
