using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class NewsControl : MonoBehaviour
{
    public float testPol;
    public float testCul;
    public float testRel;
    public float testTec;
    //Changeable variables
    public bool readingNews = false;//Break news pop out
    public bool rollingNews = false;//Normal news rolling

    public List<string> normalRandNews;//Random news list
    public List<string> breakNewsList;//Break news list
    public Text normalNews;//Text for normal news
    public Text breakNewsText;

    public float speed; //0~1
    public float resetTime; //For testing

    public GameObject breakNews;//put break news here
    //Do not change Numbers
    float resetDefTime; //For testing
    Vector3 newsDefPos;
    int selectNormalNews;
    int selectBreakNews;
    public int polPhase = 0;
    public int culPhase = 0;
    public int relPhase = 0;
    public int tecPhase = 0;

    void Start()
    {
        //Set default numbers
        newsDefPos = normalNews.transform.position;
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
            normalNews.transform.position = newsDefPos;
            selectNormalNews = Random.Range(0, normalRandNews.Count);
            rollingNews = true;
        }

        normalNews.text = normalRandNews[selectNormalNews];

        if(rollingNews == true)
        {
            normalNews.transform.position += Vector3.left * speed;
        }

        //Breaking news pop out and in
        //GetComponent<ContinentScript>().pol_cont
        if (testPol>=6.66 && polPhase == 0)
        {
            if(readingNews == false)
                selectBreakNews = Random.Range(0, 2);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1; 
                readingNews = false;
            }
        }
        if (testPol >= 13.32 && polPhase == 1)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(2, 4);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 19.98 && polPhase == 2)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(4, 6);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 26.64 && polPhase == 3)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(6, 8);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 33.3 && polPhase == 4)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(8, 10);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 39.96 && polPhase == 5)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(10, 12);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 46.62 && polPhase == 6)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(12, 14);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 53.28 && polPhase == 7)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(14, 16);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 59.94 && polPhase == 8)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(16, 18);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 66.6 && polPhase == 9)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(18, 20);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 73.26 && polPhase == 10)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(20, 22);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 79.92 && polPhase == 11)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(22, 24);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 86.58 && polPhase == 12)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(24, 26);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 93.24 && polPhase == 13)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(26, 28);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        if (testPol >= 99.9 && polPhase == 14)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(28, 30);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
            {
                polPhase += 1;
                readingNews = false;
            }
        }
        //————————————————————————————————————————
        if (testCul >= 6.66 && culPhase == 0)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(30, 32);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 13.32 && culPhase == 1)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(32, 34);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 19.98 && culPhase == 2)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(34, 36);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 26.64 && culPhase == 3)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(36, 38);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 33.3 && culPhase == 4)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(38, 40);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 39.96 && culPhase == 5)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(40, 42);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 46.62 && culPhase == 6)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(42, 44);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 53.28 && culPhase == 7)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(44, 46);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 59.94 && culPhase == 8)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(46, 48);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 66.6 && culPhase == 9)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(48, 50);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 73.26 && culPhase == 10)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(50, 52);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 79.92 && culPhase == 11)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(52, 54);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 86.58 && culPhase == 12)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(54, 56);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 93.24 && culPhase == 13)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(56, 58);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        if (testCul >= 99.9 && culPhase == 14)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(58, 60);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                culPhase += 1;
        }
        //-------------------------------------------
        if (testRel >= 6.66 && relPhase == 0)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(60, 62);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 13.32 && relPhase == 1)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(62, 64);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 19.98 && relPhase == 2)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(64, 66);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 26.64 && relPhase == 3)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(66, 68);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 33.3 && relPhase == 4)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(68, 70);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 39.96 && relPhase == 5)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(70, 72);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 46.62 && relPhase == 6)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(72, 74);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 53.28 && relPhase == 7)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(74, 76);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 59.94 && relPhase == 8)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(76, 78);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 66.6 && relPhase == 9)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(78, 80);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 73.26 && relPhase == 10)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(80, 82);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 79.92 && relPhase == 11)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(82, 84);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 86.58 && relPhase == 12)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(84, 86);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 93.24 && relPhase == 13)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(86, 88);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        if (testRel >= 99.9 && relPhase == 14)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(88, 90);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                relPhase += 1;
        }
        //------------------------------------------
        if (testTec >= 6.66 && tecPhase == 0)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(90, 92);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 13.32 && tecPhase == 1)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(92, 94);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 19.98 && tecPhase == 2)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(94, 96);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 26.64 && tecPhase == 3)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(96, 98);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 33.3 && tecPhase == 4)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(98, 100);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 39.96 && tecPhase == 5)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(100, 102);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 46.62 && tecPhase == 6)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(102, 104);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 53.28 && tecPhase == 7)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(104, 106);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 59.94 && tecPhase == 8)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(106, 108);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 66.6 && tecPhase == 9)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(108, 110);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 73.26 && tecPhase == 10)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(110, 112);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 79.92 && tecPhase == 11)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(112, 114);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 86.58 && tecPhase == 12)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(114, 116);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 93.24 && tecPhase == 13)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(116, 118);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }
        if (testTec >= 99.9 && tecPhase == 14)
        {
            if (readingNews == false)
                selectBreakNews = Random.Range(118, 120);
            readingNews = true;
            if (Input.GetMouseButtonUp(0) && readingNews == true)
                tecPhase += 1;
        }

        if (readingNews == true)
        {
            breakNews.SetActive(true);
            breakNewsText.text = breakNewsList[selectBreakNews];
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
