using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alienpercentage : MonoBehaviour
{
    public float percent = 0;
    //public float delayTimer;
    //public float timer;

    int turn;
    Animator alienAnim;
    void Start()
    {
        //delayTimer = 0.1f;
        turn = TurnsManager._instance.turns;
        alienAnim = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (percent < 100)
        {
            alienAnim.SetBool("charged", false);//no animation

            if(turn< TurnsManager._instance.turns)
            {
                Debug.Log(100f / GetComponent<James_AlienScript>().genSpeed);
                percent += 100f/GetComponent<James_AlienScript>().genSpeed;
                turn = TurnsManager._instance.turns;
            }

            //timer += Time.deltaTime;
            //if (timer >= delayTimer)
            //{
            //    timer = 0;
            //    percent++;

            //}
        }
        else if (percent >= 100)
        {
            alienAnim.SetBool("charged", true);//no animation
        }
      
    }
}
