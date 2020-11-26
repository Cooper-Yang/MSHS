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
        James_AlienScript jas = gameObject.GetComponentInParent<James_AlienScript>();
        
        
        religionbar.fillAmount = jas.rel_Influence / 100;
        politicsbar.fillAmount = jas.pol_Influence / 100;
        culturebar.fillAmount = jas.cul_Influence / 100;
        techbar.fillAmount = jas.tech_Influence / 100;


        //Debug.Log(jas.tech_Influence);

        
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            AudioManager._instance.UseLowPass();
        }
    }
}
