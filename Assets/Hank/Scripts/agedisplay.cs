using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class agedisplay : MonoBehaviour
{
    public Text currentage;
    public int currentageNum;
    public Text lifespan;
    public int lifespanNum;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifespanNum = transform.parent.GetComponent<James_AlienScript>().lifeSpan;
        lifespan.text = lifespanNum.ToString();
    }
}
    