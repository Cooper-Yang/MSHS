using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienclick : MonoBehaviour
{
    public GameObject panel;
    public float charge;

    void Update()
    {
        charge = gameObject.GetComponent<alienpercentage>().percent;
    }
    public void OpenPanel()
    {
        if (charge<100) //if not charged just open the info menu
        {
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }
        else if (charge >= 100)
        {
            gameObject.GetComponent<alienpercentage>().percent = 0; //return to 0
        }
     
    }
}
