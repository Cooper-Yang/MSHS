using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class James_AlienScript : MonoBehaviour
{
	public enum Continent
	{
		africa, northAmerica, southAmerica, asia, europe, australia
	}
	public Continent myCon;

    public int pol_Influence; // 0~100
    public int rel_Influence; // 0~100
    public int cul_Influence; // 0~100
    public int tech_Influence; // 0~100

	private float radius = 0; // caculated with total influence

	// these should be in GameManager
    public float world_interval;
	private float timer;
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

	private void Start()
	{
		timer = world_interval;
	}

	private void Update()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			timer = world_interval;
			GenerateDots(gameObject);
		}
	}

	// 根据影响力长小点点
	public void GenerateDots(GameObject alien)
	{
		James_AlienScript aS = alien.GetComponent<James_AlienScript>();
		// calculate total influence
		int influence_Total = aS.pol_Influence + aS.rel_Influence + aS.cul_Influence + aS.tech_Influence;
		// calculate radius based on total influence
		radius = influence_Total / 100;
		// roll which type of dot to spawn
		int rnd = Random.Range(0, influence_Total+1);
		if (rnd <= aS.pol_Influence)
		{
			// pol dot
			GameObject dot = Instantiate(politicDotPrefab);
			SetParent(dot);
			dot.transform.position = transform.position + Random.insideUnitSphere * radius;
			dot.transform.position = new Vector3(dot.transform.position.x, dot.transform.position.y, 0);
		}
		else if (rnd > aS.pol_Influence && rnd <= aS.pol_Influence + aS.rel_Influence)
		{
			// rel dot
			GameObject dot = Instantiate(religionDotPrefab);
			SetParent(dot);
			dot.transform.position = transform.position + Random.insideUnitSphere * radius;
			dot.transform.position = new Vector3(dot.transform.position.x, dot.transform.position.y, 0);
		}
		else if (rnd > aS.pol_Influence + aS.rel_Influence && rnd <= influence_Total - aS.tech_Influence)
		{
			// cul dot
			GameObject dot = Instantiate(cultureDotPrefab);
			SetParent(dot);
			dot.transform.position = transform.position + Random.insideUnitSphere * radius;
			dot.transform.position = new Vector3(dot.transform.position.x, dot.transform.position.y, 0);
		}
		else if (rnd > influence_Total - aS.tech_Influence)
		{
			// tech dot
			GameObject dot = Instantiate(techDotPrefab);
			SetParent(dot);
			dot.transform.position = transform.position + Random.insideUnitSphere * radius;
			dot.transform.position = new Vector3(dot.transform.position.x, dot.transform.position.y, 0);
		}
		else
		{
			Debug.LogError("没随机到点点");
		}
	}

	private void SetParent(GameObject dot) // need to set the parent of the dot based on the alien's continent to show dots only on that continent
	{
		switch (myCon)
		{
			case Continent.africa:
				dot.transform.parent = africa.transform;
				africa.GetComponent<ContinentScript>().dots.Add(dot);
				africa.GetComponent<ContinentScript>().CalculateIindividualDots();
				break;
			case Continent.northAmerica:
				dot.transform.parent = northAmerica.transform;
				northAmerica.GetComponent<ContinentScript>().dots.Add(dot);
				break;
			case Continent.southAmerica:
				dot.transform.parent = southAmerica.transform;
				southAmerica.GetComponent<ContinentScript>().dots.Add(dot);
				break;
			case Continent.asia:
				dot.transform.parent = asia.transform;
				asia.GetComponent<ContinentScript>().dots.Add(dot);
				break;
			case Continent.europe:
				dot.transform.parent = europe.transform;
				europe.GetComponent<ContinentScript>().dots.Add(dot);
				break;
			case Continent.australia:
				dot.transform.parent = australia.transform;
				australia.GetComponent<ContinentScript>().dots.Add(dot);
				break;
		}
	}
}
