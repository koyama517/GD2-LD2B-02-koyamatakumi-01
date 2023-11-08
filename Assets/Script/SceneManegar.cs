using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManegar : MonoBehaviour
{

    public bool isStart;

    //GameObject tage;

    bool isSet;

    public bool isClear;

    public bool isEnd;

    public GameObject player;

    public GameObject enemy;

    int nowScene;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        isSet = false;
        isClear = false;
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        nowScene = SceneManager.GetActiveScene().buildIndex;

        StartEase startEase;
        startEase = GetComponent<StartEase>();

        if (startEase != null )
        {
            if (startEase.isGoal)
            {
                isSet = true;
            }
        }

        if (!isStart && isSet)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isStart = true;
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                isStart = false;
                isEnd = true;
            }
        }
        if (player == null)
        {
            isStart = false;
            isEnd = true;
        }

        if( enemy == null)
        {
            isStart = false;
            isClear = true;
            isEnd = true;
        }

        NextEndEase endEase;
        endEase = GetComponent<NextEndEase>();
        if( endEase != null )
        {
            if( endEase.isGoal)
            {
                if (isClear)
                {
                    if(nowScene == 4)
                    {
                        SceneManager.LoadScene(0);
                    }
                    else
                    {
                        SceneManager.LoadScene(nowScene + 1);
                    }
                }
                else
                {
                    SceneManager.LoadScene(nowScene);
                }
            }
        }
    }
}
