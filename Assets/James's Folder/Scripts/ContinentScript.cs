using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContinentScript : MonoBehaviour
{
	public TextMeshProUGUI continentInfo;
    public List<GameObject> myDots;
	public List<GameObject> myAliens; // need to have a GameManager that stores all the aliens based on the continents they are on
	public float pol_cont;
	public float cul_cont;
	public float rel_cont;
	public float tech_cont;

	public GameObject alienPrefab;

	public float pol_tendency;
	public float cul_tendency;
	public float rel_tendency;
	public float tech_tendency;

	//glow sprite
	public Sprite normalSprite;
	public Sprite glowSprite;
	public bool canGlow;

    private void Update()
    {
		ContiGlow();

	}

    private void OnMouseDown()
	{
		continentInfo.text = "Aliens: " + 
							 "\nPol Ctrl: " + pol_cont + 
							 "\nCul Ctrl: " + cul_cont +
							 "\nRel Ctrl: " + rel_cont +
							 "\nTech Ctrl: " + tech_cont;
	}

	private void OnMouseUpAsButton()
	{
		continentInfo.text = "";
	}

	private void OnMouseExit()
	{
		continentInfo.text = "";
	}

	public void CalculateIindividualDots()
	{
		pol_cont = 0;
		cul_cont = 0;
		rel_cont = 0;
		tech_cont = 0;
		foreach (GameObject alien in myAliens)
		{
			James_AlienScript aS = alien.GetComponent<James_AlienScript>();
			for (int i = 0; i < aS.myDots.Count; i++)
			{
				if (aS.myDots[i].name == "pol dot(Clone)")
				{
					pol_cont += aS.radius * pol_tendency;
				}
				else if (aS.myDots[i].name == "cul dot(Clone)")
				{
					cul_cont += aS.radius * cul_tendency;
				}
				else if (aS.myDots[i].name == "rel dot(Clone)")
				{
					rel_cont += aS.radius * rel_tendency;
				}
				else if (aS.myDots[i].name == "tech dot(Clone)")
				{
					tech_cont += aS.radius * tech_tendency;
				}
			}
		}
	}

	void ContiGlow()
    {
		if(canGlow == true)
        {
			this.GetComponent<SpriteRenderer>().sprite = glowSprite;
        }
		else
			this.GetComponent<SpriteRenderer>().sprite = normalSprite;

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Input.GetMouseButton(0) )
        {
			if (collision.gameObject.tag == "AlienCard" || collision.gameObject.tag == "EffectCard")
			{

				canGlow = true;
			}
			
        }
		
		//Debug.Log(1);

	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Input.GetMouseButtonUp(0))
        {
			Debug.Log("night");
			if (collision.gameObject.tag == "AlienCard")
			{
				canGlow = false;
				
				summonAlien(collision);
			}
			if(collision.gameObject.tag == "EffectCard")
            {
				canGlow = false;

				affectAlien(collision);
			}
		}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
		canGlow = false;
	}

	public void affectAlien(Collision2D collision)
    {
		GameObject otherCard = collision.gameObject;
		CardReader cR = otherCard.GetComponent<CardReader>();
        if (cR.isConti)
        {
			//miss apply conti effect (use StartCoroutine(gameobject.NumberChangedVFX(x, x, x, x));) Coop: how to know which alien? 
			//probly a conti hold a list of alien? works with line 10 probly
		}
		else
        {
			//miss apply single effect
		}
		TurnsManager._instance.nextTurn();
		//miss +discov here (use + cR.discoverRate)
		Destroy(collision.gameObject);
	}

	public void summonAlien(Collision2D collision)
    {
		//save date
		GameObject otherCard = collision.gameObject;
		AlienCardProcGen acp = otherCard.GetComponent<AlienCardProcGen>();
		int cul = acp.cul;
		int rel = acp.rel;
		int pol = acp.pol;
		int tech = acp.tech;
		int lifeSpan = acp.lifeSpanNumber;
		int genSpeed = acp.genSpeed;
		int discoverRate = acp.discoverRate;
		//generate alien
		GameObject aliens = Instantiate(alienPrefab, GameObject.FindGameObjectWithTag("AlienCanvas").transform);
		aliens.transform.position = new Vector3(aliens.transform.position.x+Random.Range(-2f,2f), aliens.transform.position.y + Random.Range(-2f, 2f), aliens.transform.position.z);
		//aliens.transform.SetParent();
		aliens.GetComponent<James_AlienScript>().pol_Influence = pol;
		aliens.GetComponent<James_AlienScript>().rel_Influence = rel;
		aliens.GetComponent<James_AlienScript>().cul_Influence = cul;
		aliens.GetComponent<James_AlienScript>().tech_Influence = tech;
		aliens.GetComponent<James_AlienScript>().lifeSpan = lifeSpan;
		aliens.GetComponent<James_AlienScript>().genSpeed = genSpeed;
		aliens.GetComponent<James_AlienScript>().discoverRate = discoverRate;
		//destroy card
		TurnsManager._instance.nextTurn();
		//miss +discov here (use + acp.discoverRate)
		Destroy(collision.gameObject);
	}
}
