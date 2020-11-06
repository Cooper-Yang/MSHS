using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienlife : MonoBehaviour
{
    public float lifespan = 0;
    public float delayTimer;
    public float timer;


    void Start()
    {
        delayTimer = 2f;

        
    }

    void Update()
    {
        if (lifespan < 100)
        {
            
            timer += Time.deltaTime;
            if (timer >= delayTimer)
            {
                timer = 0;
                lifespan++;

            }
        }
        else if (lifespan >= 100)
        {
            Destroy(gameObject);
        }
    }
}
