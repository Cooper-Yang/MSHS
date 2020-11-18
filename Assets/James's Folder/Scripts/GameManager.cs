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

    public float pol_gl;
    public float cul_gl;
    public float rel_gl;
    public float tech_gl;

	public enum thingy
	{
        pol, cul, rel, tech
	}

    // Start is called before the first frame update
    void Awake()
    {
        me = this;
    }

    public void CalculateGlobalNums()
	{
        pol_gl = (africa.GetComponent<ContinentScript>().pol_cont +
                 northAmerica.GetComponent<ContinentScript>().pol_cont +
                 southAmerica.GetComponent<ContinentScript>().pol_cont +
                 europe.GetComponent<ContinentScript>().pol_cont +
                 asia.GetComponent<ContinentScript>().pol_cont +
                 australia.GetComponent<ContinentScript>().pol_cont) / 6;
        cul_gl = (africa.GetComponent<ContinentScript>().cul_cont +
                 northAmerica.GetComponent<ContinentScript>().cul_cont +
                 southAmerica.GetComponent<ContinentScript>().cul_cont +
                 europe.GetComponent<ContinentScript>().cul_cont +
                 asia.GetComponent<ContinentScript>().cul_cont +
                 australia.GetComponent<ContinentScript>().cul_cont) / 6;
        rel_gl = (africa.GetComponent<ContinentScript>().rel_cont +
                 northAmerica.GetComponent<ContinentScript>().rel_cont +
                 southAmerica.GetComponent<ContinentScript>().rel_cont +
                 europe.GetComponent<ContinentScript>().rel_cont +
                 asia.GetComponent<ContinentScript>().rel_cont +
                 australia.GetComponent<ContinentScript>().rel_cont) / 6;
        tech_gl = (africa.GetComponent<ContinentScript>().tech_cont +
                 northAmerica.GetComponent<ContinentScript>().tech_cont +
                 southAmerica.GetComponent<ContinentScript>().tech_cont +
                 europe.GetComponent<ContinentScript>().tech_cont +
                 asia.GetComponent<ContinentScript>().tech_cont +
                 australia.GetComponent<ContinentScript>().tech_cont) / 6;
    }
}
