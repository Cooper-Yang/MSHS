using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealthlv : MonoBehaviour
{
    public int stealthlev;

    public static stealthlv _instance;

    public static stealthlv Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
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
    }

    public void changeDisValue(int num)
    {
        stealthlev += num;

        if (stealthlev < 0)
            stealthlev = 0;
    }


}
