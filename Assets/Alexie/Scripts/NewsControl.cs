using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsControl : MonoBehaviour
{
    //Changeable variables
    public bool readingNews = false;//Break news pop out
    public bool rollingNews = false;//Normal news rolling

    public List<NewsControl> newsControls;
    public Text news;//Text for normal news

    public float speed; //0~1
    public float resetTime; //For testing

    public GameObject breakNews;//put break news here
    //Default Numbers
    float resetDefTime; //For testing
    Vector3 newsDefPos;
    void Start()
    {
        //Set default numbers
        newsDefPos = news.transform.position;
        resetDefTime = resetTime;
    }

    void Update()
    {
        resetTime -= Time.deltaTime;//For testing time
        //Normal news move and reset

        if (resetTime <= 0)
        {
            rollingNews = false;
            resetTime = resetDefTime;
            news.transform.position = newsDefPos;
            rollingNews = true;
        }



        news.text = "Hi, this is rolling news.";//Waiting for fix
        news.transform.position += Vector3.left * speed;

        //Breaking news jump out and in
        if (Input.GetKeyDown(KeyCode.B))//Press B to call break news
        {
            readingNews = true;
        }
        else if (Input.GetMouseButtonDown(0) && readingNews == true)
        {
            readingNews = false;
        }
        if (readingNews == true)
        {
            breakNews.SetActive(true);
        }
        else
        {
            breakNews.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
