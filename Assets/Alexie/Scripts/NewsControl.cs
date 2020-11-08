using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsControl : MonoBehaviour
{
    //Changeable variables
    public List<NewsControl> newsControls;
    public Text news;
    public float speed;
    public float resetTime;
    //Default Numbers
    float resetDefTime;
    Vector3 newsDefPos;
    void Start()
    {
        //Set default numbers
        newsDefPos = news.transform.position;
        resetDefTime = resetTime;
    }

    void Update()
    {
        //Normal news move and reset
        resetTime -= Time.deltaTime;

        if(resetTime <= 0)
        {
            resetTime = resetDefTime;
            news.transform.position = newsDefPos;
        }

        news.text = "Hello";//Waiting for fix
        news.transform.position += Vector3.left * speed;

        //Breaking news jump out and in

    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
