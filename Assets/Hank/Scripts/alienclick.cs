using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienclick : MonoBehaviour
{
    public GameObject panel;
    public float charge;

    GameObject CM; //get cardManager

    private void Start()
    {
        CM = GameObject.Find("CardManager");
    }

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
            if (CM.GetComponent<CardManager>().SendCard())//if can deal card then deal card
            {
                gameObject.GetComponent<alienpercentage>().percent = 0; //return to 0
            }
            else
            gameObject.GetComponent<alienpercentage>().percent = 100;//if not then keep the card at 100 percent
        }
     
    }
}
