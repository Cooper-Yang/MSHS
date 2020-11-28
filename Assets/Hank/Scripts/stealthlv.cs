using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stealthlv : MonoBehaviour
{
    public int stealthlev;

    public static stealthlv _instance;

    public stealthbar st;

    public Image highlight;
    public float glowDuration = 20f;
    public bool canGlow;
    Color thiscolor;


    public static stealthlv Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        thiscolor = st.fillImage.color;
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        stealthlev = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stealthlev >= 100) //gameover
        {

        }
        if(canGlow == true)
        {
            DisValueGlow();
        }
        if (canGlow == false)
        {
            glowDuration = 20f;
        }
        highlight.fillAmount = st.fillImage.fillAmount + 0.01f;

    }

    public void changeDisValue(int num)
    {
        stealthlev += num;
        canGlow = true;

        if (stealthlev < 0)
            stealthlev = 0;
    }

    public void DisValueGlow()
    {
        glowDuration -= .1f;

        if(glowDuration < 20f)
        {
            highlight.gameObject.SetActive(true);
        }
        if (glowDuration < 15f)
        {
            highlight.gameObject.SetActive(false);
        }
        if (glowDuration < 10f)
        {
            highlight.gameObject.SetActive(true);
        }
        if (glowDuration <= 0f)
        {
            highlight.gameObject.SetActive(false);
            canGlow = false;
        }




    }


}
