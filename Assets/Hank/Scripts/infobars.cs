using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class infobars : MonoBehaviour
{
    public float religion;
    public float politics;
    public float culture;
    public float tech;

    public Image religionbar;
    public Image politicsbar;
    public Image culturebar;
    public Image techbar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        religionbar.fillAmount = religion / 100;
        politicsbar.fillAmount = politics / 100;
        culturebar.fillAmount = culture / 100;
        techbar.fillAmount = tech / 100;
    }
}
