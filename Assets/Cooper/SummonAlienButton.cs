using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAlienButton : MonoBehaviour
{
    public void SummonAlien()
    {
        CardManager.me.SendAlienCard();
        stealthlv._instance.changeDisValue(10); //increase by 10
        //discover
    }
}
