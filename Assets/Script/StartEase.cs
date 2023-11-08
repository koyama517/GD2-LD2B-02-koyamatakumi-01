using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEase : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // –Ú“I‚ÌˆÊ’u
    public float speed = 0.5f;

    public bool isGoal;

    private void FixedUpdate()
    {
        if (transform.position.y <= target.position.y + 0.1f)
        {
            isGoal = true;
        }

        if (!isGoal) {
            float t = Mathf.SmoothStep(0, 1, Time.deltaTime * speed);
            transform.position = Vector3.Lerp(transform.position, target.position, t);
        }
    }
}
