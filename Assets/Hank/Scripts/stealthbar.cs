using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stealthbar : MonoBehaviour
{
    public Image fillImage;
    public float charge;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        charge = gameObject.GetComponent<stealthlv>().stealthlev;
        fillImage.fillAmount = charge / 100;


    }
}
