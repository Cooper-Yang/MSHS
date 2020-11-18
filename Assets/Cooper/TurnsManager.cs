using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnsManager : MonoBehaviour
{
    public static TurnsManager _instance;

    public static TurnsManager Instance
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


    public int turns;

    // Start is called before the first frame update
    void Start()
    {
        turns = 0;
    }

    public void nextTurn()
    {
        turns++;
        Debug.Log("Turn #" + turns);
    }
}
