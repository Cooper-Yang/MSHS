using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alienpercentage : MonoBehaviour
{
    public float percent = 0;
    public float delayTimer;
    public float timer;

    Animator alienAnim;
    void Start()
    {
        delayTimer = 0.1f;

        alienAnim = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (percent < 100)
        {
            alienAnim.SetBool("charged", false);//no animation

            timer += Time.deltaTime;
            if (timer >= delayTimer)
            {
                timer = 0;
                percent++;

            }
        }
        else if (percent >= 100)
        {
            alienAnim.SetBool("charged", true);//no animation
        }
      
    }
}
