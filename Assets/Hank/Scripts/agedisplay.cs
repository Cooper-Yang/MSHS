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
        lifespanNum = transform.parent.GetComponent<James_AlienScript>().howlongdoiliveanditwontchange;
        lifespan.text = lifespanNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentageNum = transform.parent.GetComponent<James_AlienScript>().lifeSpan;
        currentage.text = currentageNum.ToString();
    }
}
    