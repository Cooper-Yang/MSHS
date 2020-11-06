using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class James_AlienScript : MonoBehaviour
{
    public int pol_Influence; // 0~100
    public int rel_Influence; // 0~100
    public int cul_Influence; // 0~100
    public int tech_Influence; // 0~100
    public float world_interval;
	private float timer;
	public float fullSpd; // fullSpd for generating dots
	public GameObject politicDotPrefab;
	public GameObject religionDotPrefab;
	public GameObject cultureDotPrefab;
	public GameObject techDotPrefab;

	private float xRange;
	private float yRange;

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
		int influence_Total = aS.pol_Influence + aS.rel_Influence + aS.cul_Influence + aS.tech_Influence;
		xRange = influence_Total / 50;
		yRange = influence_Total / 50;

		int rnd = Random.Range(0, influence_Total+1);
		if (rnd <= aS.pol_Influence)
		{
			// pol dot
			GameObject dot = Instantiate(politicDotPrefab);
			Vector3 posMax = new Vector3(alien.transform.position.x + xRange, alien.transform.position.y + yRange, 0);
			Vector3 posMin = new Vector3(alien.transform.position.x - xRange, alien.transform.position.y - yRange, 0);
			dot.transform.position = new Vector3(Random.Range(posMin.x, posMax.x), Random.Range(posMin.y, posMax.y), 0);
		}
		else if (rnd > aS.pol_Influence && rnd <= aS.pol_Influence + aS.rel_Influence)
		{
			// rel dot
			GameObject dot = Instantiate(religionDotPrefab);
			Vector3 posMax = new Vector3(alien.transform.position.x + xRange, alien.transform.position.y + yRange, 0);
			Vector3 posMin = new Vector3(alien.transform.position.x - xRange, alien.transform.position.y - yRange, 0);
			dot.transform.position = new Vector3(Random.Range(posMin.x, posMax.x), Random.Range(posMin.y, posMax.y), 0);
		}
		else if (rnd > aS.pol_Influence + aS.rel_Influence && rnd <= influence_Total - aS.tech_Influence)
		{
			// cul dot
			GameObject dot = Instantiate(cultureDotPrefab);
			Vector3 posMax = new Vector3(alien.transform.position.x + xRange, alien.transform.position.y + yRange, 0);
			Vector3 posMin = new Vector3(alien.transform.position.x - xRange, alien.transform.position.y - yRange, 0);
			dot.transform.position = new Vector3(Random.Range(posMin.x, posMax.x), Random.Range(posMin.y, posMax.y), 0);
		}
		else if (rnd > influence_Total - aS.tech_Influence)
		{
			// tech dot
			GameObject dot = Instantiate(techDotPrefab);
			Vector3 posMax = new Vector3(alien.transform.position.x + xRange, alien.transform.position.y + yRange, 0);
			Vector3 posMin = new Vector3(alien.transform.position.x - xRange, alien.transform.position.y - yRange, 0);
			dot.transform.position = new Vector3(Random.Range(posMin.x, posMax.x), Random.Range(posMin.y, posMax.y), 0);
		}
		else
		{
			Debug.LogError("没随机到点点");
		}
	}
}
