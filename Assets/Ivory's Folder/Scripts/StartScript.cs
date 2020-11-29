using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public int phase = 0;

    public Text leftclick;
    public Text leftclick2;
    public Text rightclick;

    public GameObject phase0;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    public GameObject phase5;
    public GameObject phase6;
    public GameObject phase7;
    public GameObject phase8;
    public GameObject phase9;
    public GameObject phase10;
    public GameObject phase11;
    public GameObject phase12;
    public GameObject phase13;
    public GameObject phase14;


    void Start()
    {
        leftclick.enabled = false;
        leftclick2.enabled = false;
        rightclick.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            phase++;

        }
        if (Input.GetMouseButtonDown(1))
        {
            if (phase > 1) //wont go back to phase 0 
            {
                phase--;
            }
        }

        if (phase == 0)
        {
            phase0.SetActive(true);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 1)
        {
            leftclick.enabled = true;
            rightclick.enabled = false;


            phase0.SetActive(false);
            phase1.SetActive(true);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 2)
        {
            rightclick.enabled = true;

            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(true);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 3)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(true);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 4)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(true);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);

        }
        else if (phase == 5)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(true);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 6)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(true);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 7)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(true);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 8)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(true);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 9)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(true);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 10)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(true);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 11)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(true);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 12)
        {
            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(true);
            phase13.SetActive(false);
            phase14.SetActive(false);
        }
        else if (phase == 13)
        {
            leftclick.enabled = true;
            leftclick2.enabled = false;

            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(true);
            phase14.SetActive(false);
        }
        else if (phase == 14)
        {
            leftclick.enabled = false;
            leftclick2.enabled = true;

            phase0.SetActive(false);
            phase1.SetActive(false);
            phase2.SetActive(false);
            phase3.SetActive(false);
            phase4.SetActive(false);
            phase5.SetActive(false);
            phase6.SetActive(false);
            phase7.SetActive(false);
            phase8.SetActive(false);
            phase9.SetActive(false);
            phase10.SetActive(false);
            phase11.SetActive(false);
            phase12.SetActive(false);
            phase13.SetActive(false);
            phase14.SetActive(true);
        }
        else if (phase >= 15)
        {
            SceneManager.LoadScene(1);
        }


    }
}
