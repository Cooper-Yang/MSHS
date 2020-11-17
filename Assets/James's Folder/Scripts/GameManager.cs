using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager me;

    public float world_interval;
    public GameObject politicDotPrefab;
    public GameObject religionDotPrefab;
    public GameObject cultureDotPrefab;
    public GameObject techDotPrefab;
    public GameObject africa;
    public GameObject northAmerica;
    public GameObject southAmerica;
    public GameObject asia;
    public GameObject europe;
    public GameObject australia;

	public enum thingy
	{
        pol, cul, rel, tech
	}

    // Start is called before the first frame update
    void Awake()
    {
        me = this;
    }
}
