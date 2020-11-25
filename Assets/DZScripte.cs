using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DZScripte : MonoBehaviour
{
    public Sprite normal;
    public Sprite onImage;

    bool isOnImage;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().sprite = normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnImage == true)
        {
            this.GetComponent<Image>().sprite = onImage;
            if (Input.GetMouseButtonUp(0))
            {

                this.GetComponent<Image>().sprite = normal;
            }
        }
        else if (isOnImage == false)
        {
            this.GetComponent<Image>().sprite = normal;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        isOnImage = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnImage = false;
    }

}
