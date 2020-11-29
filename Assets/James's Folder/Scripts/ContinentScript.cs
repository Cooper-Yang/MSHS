using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContinentScript : MonoBehaviour
{
	public James_AlienScript.Continent ContiName;
	public TextMeshProUGUI continentInfo;
    public List<GameObject> myDots;
	public List<GameObject> myAliens;
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
	public bool onStay = false;
	public Collision2D collidedCard;


    private void Update()
    {
		if (GameManager.me.state == GameManager.me.game_screen)
		{
			if (collidedCard != null)
			{
				//Debug.Log(ContiName+": "+collidedCard.gameObject.name);
				//foreach (var alien in myAliens)
				//         {
				//	if (alien == collidedCard.gameObject)
				//             {
				//		collidedCard = null;
				//             }
				//         }
			}


			if (CardManager.me.CardBeingHeld != null) // if player is holding a card
			{
				// enable aliens' colliders if its not a conti effect card, disable aliens' colliders otherwise
				if (CardManager.me.CardBeingHeld.tag == "EffectCard") // check if its an effect card
				{
					if (CardManager.me.CardBeingHeld.GetComponent<CardReader>().isConti) // if its a conti card
					{
						GetComponent<PolygonCollider2D>().enabled = true;
						foreach (var alien in myAliens)
						{
							alien.GetComponent<CircleCollider2D>().enabled = false;
						}
					}
					else // if its not a conti card
					{
						GetComponent<PolygonCollider2D>().enabled = false;
						foreach (var alien in myAliens)
						{
							alien.GetComponent<CircleCollider2D>().enabled = true;
						}
					}
				}
				else // if its an alien card, disable aliens' colliders
				{
					foreach (var alien in myAliens)
					{
						alien.GetComponent<CircleCollider2D>().enabled = false;
					}
					GetComponent<PolygonCollider2D>().enabled = true;
				}
			}
			else // if player is not holding a card
			{
				GetComponent<PolygonCollider2D>().enabled = true;
				foreach (var alien in myAliens)
				{
					alien.GetComponent<CircleCollider2D>().enabled = false;
				}
			}

			ContiGlow();
			if (onStay == true)
			{
				//Debug.Log(1111);
				if (Input.GetMouseButtonUp(0))
				{
					doThingsToCards(collidedCard);
					//onStay = false;
				}
			}
		}
	}

    private void OnMouseDown()
	{
		continentInfo.text = "\nPolitic: " + (int)pol_cont + "%" + 
							 "\nCultural: " + (int)cul_cont + "%" +
							 "\nReligious: " + (int)rel_cont + "%" +
							 "\nTechnical: " + (int)tech_cont + "%";
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
			if (alien == null)
				continue;
			
			James_AlienScript aS = alien.GetComponent<James_AlienScript>();
			for (int i = 0; i < aS.myDots.Count; i++)
			{
				if (aS.myDots[i].name == "pol dot(Clone)")
				{
					//pol_cont += aS.radius * pol_tendency;
					pol_cont += 0.75f;
				}
				else if (aS.myDots[i].name == "cul dot(Clone)")
				{
					//cul_cont += aS.radius * cul_tendency;
					cul_cont += 0.75f;
				}
				else if (aS.myDots[i].name == "rel dot(Clone)")
				{
					//rel_cont += aS.radius * rel_tendency;
					rel_cont += 0.75f;
				}
				else if (aS.myDots[i].name == "tech dot(Clone)")
				{
					//tech_cont += aS.radius * tech_tendency;
					tech_cont += 0.75f;
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
		onStay = true;
		if (Input.GetMouseButton(0) )
        {
			if (collision.gameObject.tag == "AlienCard" || collision.gameObject.tag == "EffectCard")
			{

				canGlow = true;
			}
			
        }
		//bool alreadyProcessed = false;
  //      foreach (var alien in myAliens)
  //      {
		//	if (alien == collision.gameObject)
  //          {
		//		alreadyProcessed = true;
  //          }
  //      }
		//if (!alreadyProcessed)
		//{
		//	collidedCard = collision;
		//}
		//Debug.Log(1);

	}

    private void OnCollisionStay2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("AlienCard")|| collision.gameObject.CompareTag("EffectCard"))
		{
			collidedCard = collision;
			print("collision staying with conti");
		}
		
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
		onStay = false;
		canGlow = false;
		//if (collidedCard != null)
  //      {
		//	//Debug.Log(collidedCard.gameObject.name);
		//	//collidedCard.gameObject.GetComponent<CardMvmt>().contiImOn = null;
		//	collidedCard = null;
		//}
	}

	public void doThingsToCards(Collision2D collision)
	{
		//Debug.Log("night");
		if (collision.gameObject.tag == "AlienCard")
		{
			canGlow = false;
			//Debug.Log("before summon");
			summonAlien(collision); //use alien card
			AudioManager._instance.AfterPlay();
			AudioManager._instance.MusicStart();
			onStay = false;
		}
		if (collision.gameObject.tag == "EffectCard")
		{
			canGlow = false;
			//Debug.Log("before effect affect"); 
			affectAlien(collision); //use effect card
			AudioManager._instance.AfterPlay();
			onStay = false;

		}
	}


	public void affectAlien(Collision2D collision)
    {
		GameObject otherCard = collision.gameObject;
		CardReader cR = otherCard.GetComponent<CardReader>();
        if (cR.isConti)
        {
            //miss apply conti effect (use StartCoroutine(gameobject.NumberChangedVFX(x, x, x, x));) Coop: how to know which alien? 
            //probly a conti hold a list of alien? works with line 10 probly
            foreach (var alien in myAliens)
            {
				print("conti effect card used");
				James_AlienScript ja = alien.GetComponent<James_AlienScript>();
				
				ja.pol_Influence += cR.poliVal;
				ja.cul_Influence += cR.culVal;
				ja.rel_Influence += cR.reliVal;
				ja.tech_Influence += cR.techVal;
				StartCoroutine(ja.NumberChangedVFX(cR.poliVal, cR.culVal, cR.reliVal, cR.techVal));
				ja.lifeSpan += cR.lifeVal;
			}
		}
		else
        {
			//miss apply single effect
			Debug.Log("not conti");
		}

		//change discover value
		stealthlv._instance.changeDisValue(cR.discovRate);

		TurnsManager._instance.nextTurn();
		//miss +discov here (use + cR.discoverRate) is it still missing? ain't line 186 does the job?
		Destroy(collision.gameObject);
	}

	

	public void summonAlien(Collision2D collision)
    {
		
		//save data

		Collider2D contiCollider = GetComponent<PolygonCollider2D>();
		Bounds thisbound = contiCollider.bounds;

        float randx = Random.Range(thisbound.min.x, thisbound.max.x);
        float randy = Random.Range(thisbound.min.y, thisbound.max.y);

        List<Collider2D> alienCollider = new List<Collider2D>();
        for (int i = 0; i < myAliens.Count; i++)
        {
            alienCollider.Add(myAliens[i].GetComponent<CircleCollider2D>());
        }

        List<Bounds> alienBounds = new List<Bounds>();
        for (int i = 0; i < alienCollider.Count; i++)
        {
            alienBounds.Add(alienCollider[i].bounds);
        }

        

        float posx = 0;
		float posy = 0;

		while(!contiCollider.OverlapPoint(new Vector2(randx,randy)))
        {

            randx = Random.Range(thisbound.min.x, thisbound.max.x);
            randy = Random.Range(thisbound.min.y, thisbound.max.y);

        }
		bool overlap = true;
		int repeatTime = 0;

		if (myAliens.Count > 0)
		{
			while (overlap && repeatTime < 10000)
			{
				randx = Random.Range(thisbound.min.x, thisbound.max.x);
				randy = Random.Range(thisbound.min.y, thisbound.max.y);

				for (int i = 0; i < myAliens.Count; i++)
				{

					if (Vector2.Distance(myAliens[i].transform.position, new Vector2(randx, randy)) < 0.3)
					{
						overlap = true;
						break;
					}
					else
						overlap = false;
				}

				if (!contiCollider.OverlapPoint(new Vector2(randx, randy)))
				{
					overlap = true;
				}
				repeatTime++;

			}
		}


		posx = randx;
		posy = randy;

		GameObject otherCard = collision.gameObject;
		AlienCardProcGen acp = otherCard.GetComponent<AlienCardProcGen>();
		int cul = acp.cul;
		int rel = acp.rel;
		int pol = acp.pol;
		int tech = acp.tech;
		int lifeSpan = acp.lifeSpanNumber;
		int genSpeed = acp.genSpeed;
		int discoverRate = acp.discoverRate;
		Sprite head = acp.head.sprite;
		Sprite mouth = acp.mouth.sprite;
		Sprite eye = acp.eyes.sprite;


		//change discover value
		stealthlv._instance.changeDisValue(acp.discoverRate);

		//generate alien
		GameObject aliens = Instantiate(alienPrefab, GameObject.FindGameObjectWithTag("AlienCanvas").transform);
		aliens.GetComponent<James_AlienScript>().myCon = ContiName;
        aliens.transform.position = new Vector3(posx, posy, aliens.transform.position.z);
        //aliens.transform.SetParent();
        aliens.GetComponent<James_AlienScript>().pol_Influence = pol;
		aliens.GetComponent<James_AlienScript>().rel_Influence = rel;
		aliens.GetComponent<James_AlienScript>().cul_Influence = cul;
		aliens.GetComponent<James_AlienScript>().tech_Influence = tech;
		aliens.GetComponent<James_AlienScript>().lifeSpan = lifeSpan;
		aliens.GetComponent<James_AlienScript>().genSpeed = genSpeed;
		aliens.GetComponent<James_AlienScript>().discoverRate = discoverRate;
		aliens.GetComponent<James_AlienScript>().head.sprite = head;
		aliens.GetComponent<James_AlienScript>().mouth.sprite = mouth;
		aliens.GetComponent<James_AlienScript>().eyes.sprite = eye;
		//destroy card
		TurnsManager._instance.nextTurn();
		//miss +discov here (use + acp.discoverRate)
		
		Destroy(collision.gameObject.GetComponent<Collider2D>());
		Destroy(collision.gameObject);
		
	}
}
