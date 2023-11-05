using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moji : MonoBehaviour
{
    // Start is called before the first frame update

    public float blinkSpeed = 2.0f; // 点滅の速度

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isBlinking = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Movealpha()
    {
        // 点滅を実行
        float alpha = Mathf.PingPong(Time.time * blinkSpeed, 1.0f);
        Color newColor = originalColor;
        newColor.a = alpha;
        spriteRenderer.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        Movealpha();
        /*SceneManegar mane;
        GameObject manegar = GameObject.Find("Main Camera");
        mane = manegar.GetComponent<SceneManegar>();
        if (mane != null)
        {
            if (mane.isStart)
            {
                Destroy(this.GameObject());
            }
        }*/
    }
}
