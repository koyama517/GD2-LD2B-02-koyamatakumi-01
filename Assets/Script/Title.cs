using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{

    public GameObject titleLogo;

    float logoStartPos;
    Vector2 logoPos;

    public float floatSpeed = 1.0f; // ïÇóVÇÃë¨ìx
    public float floatDistance = 1.0f; // è„â∫ÇÃïÇóVãóó£

    // Start is called before the first frame update
    void Start()
    {
        logoPos = titleLogo.transform.position;
        logoStartPos = logoPos.y;
    }


    private void FixedUpdate()
    {
        MoveLogo();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StageSelect");
        }

    }


    void MoveLogo()
    {
        float newY = logoStartPos + Mathf.Sin(Time.time * floatSpeed) * floatDistance;
        logoPos = new Vector2(logoPos.x, newY);

        titleLogo.transform.position = logoPos;
    }

}
