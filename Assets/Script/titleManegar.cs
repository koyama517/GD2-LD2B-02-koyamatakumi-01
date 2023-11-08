using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleManegar : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isStart;

    GameObject tage;

    public bool isSet;

    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        isSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartEase startEase;
        startEase = GetComponent<StartEase>();

        if (startEase != null)
        {
            if (startEase.isGoal)
            {
                isSet = true;
            }
        }
    }
}