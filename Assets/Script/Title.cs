using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{

    public GameObject titleLogo;

    public float logoStartPos;
    Vector2 logoPos;

    public float floatSpeed = 1.0f; // ïÇóVÇÃë¨ìx
    public float floatDistance = 1.0f; // è„â∫ÇÃïÇóVãóó£
   
    public bool isEnd;

    // Start is called before the first frame update
    void Start()
    {
        logoPos = new Vector2(0, 1.5f);
        logoStartPos = logoPos.y;
        isEnd = false;
        Application.targetFrameRate = 60;
    }


    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TitleEnd endEase;
        GameObject titleE = GameObject.Find("title");
        endEase = titleE.GetComponent<TitleEnd>();

        if (endEase != null)
        {
            if (endEase.isGoal)
            {
                SceneManager.LoadScene(1);
            }
        }

        titleManegar manegar;
        GameObject title = GameObject.Find("title");
        manegar = title.GetComponent<titleManegar>();

        if (manegar.isSet && !isEnd)
        {
            MoveLogo();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isEnd = true;
            }
        }
    }


    void MoveLogo()
    {
        float newY = logoStartPos + Mathf.Sin(Time.time * floatSpeed) * floatDistance;
        logoPos = new Vector2(logoPos.x, newY);

        titleLogo.transform.position = logoPos;
    }

}
