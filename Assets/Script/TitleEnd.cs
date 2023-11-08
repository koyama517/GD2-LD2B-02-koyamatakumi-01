using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // –Ú“I‚ÌˆÊ’u
    public float speed = 2.0f;

    public bool isGoal;

    private void FixedUpdate()
    {
        Title title;
        GameObject camera = GameObject.Find("Main Camera");
        title = camera.GetComponent<Title>();
        if (title != null)
        {
            if (title.isEnd)
            {
                if (transform.position.y >= target.position.y - 0.3f)
                {
                    isGoal = true;
                }

                if (!isGoal)
                {
                    float t = Mathf.SmoothStep(0, 1, Time.deltaTime * speed);
                    transform.position = Vector3.Lerp(transform.position, target.position, t);
                }
            }
        }
    }
}
