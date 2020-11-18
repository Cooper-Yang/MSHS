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

	public float pol_tendency;
	public float cul_tendency;
	public float rel_tendency;
	public float tech_tendency;

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
}
