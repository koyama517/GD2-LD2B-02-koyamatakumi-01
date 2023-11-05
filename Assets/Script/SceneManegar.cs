using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManegar : MonoBehaviour
{

    public bool isStart;

    public GameObject player;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isStart)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isStart = true;
            }
        }

        if (isStart)
        {
            if(player == null)
            {
                SceneManager.LoadScene("proto");
            }

            if (enemy == null)
            {
                SceneManager.LoadScene("protoStage");
            }

        }

    }
}
