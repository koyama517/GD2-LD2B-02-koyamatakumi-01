using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite sprite1; // フラグがfalseの場合のスプライト
    public Sprite sprite2; // フラグがtrueの場合のスプライト

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1; // 最初はsprite1を表示
    }

    private void Update()
    {

        SceneManegar sceneManegar;
        GameObject camera = GameObject.Find("Main Camera");
        sceneManegar = camera.GetComponent<SceneManegar>();

        if (sceneManegar != null )
        {
            if (sceneManegar.isClear)
            {
                spriteRenderer.sprite = sprite1;
            }
            else
            {
                spriteRenderer.sprite = sprite2;
            }
        }
    }
}
