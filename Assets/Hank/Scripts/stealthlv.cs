using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealthlv : MonoBehaviour
{
    public int stealthlev;

    public int smallInc;
    public int midInc;
    public int bigInc;
    public int smallDec;
    public int midDec;
    public int bigDec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stealthlev >= 100) //gameover
        {

        }
    }

    void SmallIncrease()
    {
        stealthlev += smallInc;
    }
    void MidIncrease()
    {
        stealthlev += midInc;
    }
    void BigIncrease()
    {
        stealthlev += bigInc;
    }
    void SmallDecrease()
    {
        if (stealthlev < smallDec)
        {
            stealthlev = 0;
        }
        else
        {
            stealthlev -= smallDec;
        }
        
    }
    void MidDecrease()
    {
        if (stealthlev < midDec)
        {
            stealthlev = 0;
        }
        else
        {
            stealthlev -= midDec;
        }
    }
    void BigDecrease()
    {
        if (stealthlev < bigDec)
        {
            stealthlev = 0;
        }
        else
        {
            stealthlev -= bigDec;
        }
    }


}
