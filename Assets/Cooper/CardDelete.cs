using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDelete : MonoBehaviour
{


    bool isOnImage;

    // Update is called once per frame

    private void Start()
    {

    }

    void Update()
    {
        if(isOnImage == true)
        {
            
            if (Input.GetMouseButtonUp(0))
            {

                AudioManager._instance.DeletCard();
                Destroy(gameObject);
            }
        }





    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "DeleteZone")
        {
            isOnImage = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeleteZone")
        {
            isOnImage = false;
        }
    }



}
