using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float blinkSpeed = 1.0f; // �_�ł̑��x

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    //private bool isBlinking = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Movealpha()
    {
        // �_�ł����s
        float alpha = Mathf.PingPong(Time.time * blinkSpeed, 1.0f);
        Color newColor = originalColor;
        newColor.a = alpha;
        spriteRenderer.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        Movealpha();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
}
