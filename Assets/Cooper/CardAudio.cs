using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAudio : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource aS;
    public bool canDragPlay;
    public bool canOnPlay;
    public AudioClip drag ;
    public AudioClip on ;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        canDragPlay = true;
        canOnPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dragCard()
    {
        if (canDragPlay)
        {
            aS.clip = drag;
            aS.Play();
            canDragPlay = false;
        }
    }

    public void OnCard()
    {
        if (canOnPlay)
        {
            aS.clip = on;
            aS.Play();
            canOnPlay = false;
        }
    }
}
