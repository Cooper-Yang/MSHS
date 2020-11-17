﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDelete : MonoBehaviour
{

    Image deleteZone;
    // Update is called once per frame

    private void Start()
    {
        deleteZone = GameObject.Find("DeleteZone").GetComponent<Image>();
    }

    void Update()
    {
        if(transform.position.y > 5)
        {
            deleteZone.color = new Color(deleteZone.color.r, deleteZone.color.g, deleteZone.color.b,0.5f);
            //Debug.Log(transform.position.y); 
            if (Input.GetMouseButtonUp(0))
            {

                
                deleteZone.color = new Color(deleteZone.color.r, deleteZone.color.g, deleteZone.color.b, 0);
                Destroy(gameObject);
            }
        }
        else
        {
            deleteZone.color = new Color(deleteZone.color.r, deleteZone.color.g, deleteZone.color.b, 0);
        }
        
        


        
        //
    }
}