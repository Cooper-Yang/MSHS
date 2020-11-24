using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class agedisplay : MonoBehaviour
{
    public Text ageNum;
    public int age;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        age = transform.parent.GetComponent<James_AlienScript>().lifeSpan;
        ageNum.text = age.ToString();
    }
}
    