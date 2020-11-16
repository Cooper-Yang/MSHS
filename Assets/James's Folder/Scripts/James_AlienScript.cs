using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class James_AlienScript : MonoBehaviour
{
	public enum Continent
	{
		africa, northAmerica, southAmerica, asia, europe, australia
	}
	public Continent myCon;

    public float pol_Influence; // 0~100
    public float rel_Influence; // 0~100
    public float cul_Influence; // 0~100
    public float tech_Influence; // 0~100

	private float radius = 0; // caculated with total influence

	private float timer; // for generating dots
	
	public GameObject polVfxIcon;
	public GameObject relVfxIcon;
	public GameObject culVfxIcon;
	public GameObject techVfxIcon;


	private void Start()
	{
		timer = GameManager.me.world_interval;
		polVfxIcon.GetComponent<Image>().fillAmount = pol_Influence / 100;
		culVfxIcon.GetComponent<Image>().fillAmount = cul_Influence / 100;
		relVfxIcon.GetComponent<Image>().fillAmount = rel_Influence / 100;
		techVfxIcon.GetComponent<Image>().fillAmount = tech_Influence / 100;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			StartCoroutine(NumberChangedVFX(20, 0, 15, -30));
		}
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			timer = GameManager.me.world_interval;
			GenerateDots(gameObject);
		}
	}

	// 根据影响力长小点点
	public void GenerateDots(GameObject alien)
	{
		James_AlienScript aS = alien.GetComponent<James_AlienScript>();
		// calculate total influence
		float influence_Total = aS.pol_Influence + aS.rel_Influence + aS.cul_Influence + aS.tech_Influence;
		// calculate radius based on total influence
		radius = influence_Total / 100;
		// roll which type of dot to spawn
		float rnd = Random.Range(0, influence_Total+1);
		if (rnd <= aS.pol_Influence)
		{
			// pol dot
			GameObject dot = Instantiate(GameManager.me.politicDotPrefab);
			SetParent(dot);
			dot.transform.position = transform.position + Random.insideUnitSphere * radius;
			dot.transform.position = new Vector3(dot.transform.position.x, dot.transform.position.y, 0);
		}
		else if (rnd > aS.pol_Influence && rnd <= aS.pol_Influence + aS.rel_Influence)
		{
			// rel dot
			GameObject dot = Instantiate(GameManager.me.religionDotPrefab);
			SetParent(dot);
			dot.transform.position = transform.position + Random.insideUnitSphere * radius;
			dot.transform.position = new Vector3(dot.transform.position.x, dot.transform.position.y, 0);
		}
		else if (rnd > aS.pol_Influence + aS.rel_Influence && rnd <= influence_Total - aS.tech_Influence)
		{
			// cul dot
			GameObject dot = Instantiate(GameManager.me.cultureDotPrefab);
			SetParent(dot);
			dot.transform.position = transform.position + Random.insideUnitSphere * radius;
			dot.transform.position = new Vector3(dot.transform.position.x, dot.transform.position.y, 0);
		}
		else if (rnd > influence_Total - aS.tech_Influence)
		{
			// tech dot
			GameObject dot = Instantiate(GameManager.me.techDotPrefab);
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
				dot.transform.parent = GameManager.me.africa.transform;
				GameManager.me.africa.GetComponent<ContinentScript>().dots.Add(dot);
				GameManager.me.africa.GetComponent<ContinentScript>().CalculateIindividualDots();
				break;
			case Continent.northAmerica:
				dot.transform.parent = GameManager.me.northAmerica.transform;
				GameManager.me.northAmerica.GetComponent<ContinentScript>().dots.Add(dot);
				GameManager.me.northAmerica.GetComponent<ContinentScript>().CalculateIindividualDots();
				break;
			case Continent.southAmerica:
				dot.transform.parent = GameManager.me.southAmerica.transform;
				GameManager.me.southAmerica.GetComponent<ContinentScript>().dots.Add(dot);
				GameManager.me.southAmerica.GetComponent<ContinentScript>().CalculateIindividualDots();
				break;
			case Continent.asia:
				dot.transform.parent = GameManager.me.asia.transform;
				GameManager.me.asia.GetComponent<ContinentScript>().dots.Add(dot);
				GameManager.me.asia.GetComponent<ContinentScript>().CalculateIindividualDots();
				break;
			case Continent.europe:
				dot.transform.parent = GameManager.me.europe.transform;
				GameManager.me.europe.GetComponent<ContinentScript>().dots.Add(dot);
				GameManager.me.europe.GetComponent<ContinentScript>().CalculateIindividualDots();
				break;
			case Continent.australia:
				dot.transform.parent = GameManager.me.australia.transform;
				GameManager.me.australia.GetComponent<ContinentScript>().dots.Add(dot);
				GameManager.me.australia.GetComponent<ContinentScript>().CalculateIindividualDots();
				break;
		}
	}

	public IEnumerator NumberChangedVFX(float pol, float cul, float rel, float tech) // input change amount
	{
		// show the corresponding icons
		if (pol > 0)
		{
			polVfxIcon.transform.localScale = new Vector3(1, 1, 1);
			polVfxIcon.SetActive(true);
		}
		else if (pol < 0)
		{
			polVfxIcon.transform.localScale = new Vector3(1, -1, 1);
			polVfxIcon.SetActive(true);
		}
		if (cul > 0)
		{
			culVfxIcon.transform.localScale = new Vector3(1, 1, 1);
			culVfxIcon.SetActive(true);
		}
		else if (cul < 0)
		{
			culVfxIcon.transform.localScale = new Vector3(1, -1, 1);
			culVfxIcon.SetActive(true);
		}
		if (rel > 0)
		{
			relVfxIcon.transform.localScale = new Vector3(1, 1, 1);
			relVfxIcon.SetActive(true);
		}
		else if (rel < 0)
		{
			relVfxIcon.transform.localScale = new Vector3(1, -1, 1);
			relVfxIcon.SetActive(true);
		}
		if (tech > 0)
		{
			techVfxIcon.transform.localScale = new Vector3(1, 1, 1);
			techVfxIcon.SetActive(true);
		}
		else if (tech < 0)
		{
			techVfxIcon.transform.localScale = new Vector3(1, -1, 1);
			techVfxIcon.SetActive(true);
		}
		yield return new WaitForSeconds(1);
		// hide all icons
		polVfxIcon.SetActive(false);
		culVfxIcon.SetActive(false);
		relVfxIcon.SetActive(false);
		techVfxIcon.SetActive(false);
	}
}
