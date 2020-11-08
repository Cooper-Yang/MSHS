using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContinentScript : MonoBehaviour
{
	public TextMeshProUGUI continentInfo;
    public List<GameObject> dots;
	public List<GameObject> aliens; // need to have a GameManager that stores all the aliens based on the continents they are on
	public int polDot_count;
	public int culDot_count;
	public int relDot_count;
	public int techDot_count;

	private void OnMouseDown()
	{
		continentInfo.text = "Aliens: " + 
							 "\nPol Ctrl: " + polDot_count + 
							 "\nCul Ctrl: " + culDot_count +
							 "\nRel Ctrl: " + relDot_count +
							 "\nTech Ctrl: " + techDot_count;
	}

	private void OnMouseUpAsButton()
	{
		continentInfo.text = "";
	}

	public void CalculateIindividualDots()
	{
		polDot_count = 0;
		culDot_count = 0;
		relDot_count = 0;
		techDot_count = 0;
		for (int i = 0; i < dots.Count; i++)
		{
			if (dots[i].name == "pol dot(Clone)")
			{
				polDot_count++;
			}
			else if (dots[i].name == "cul dot(Clone)")
			{
				culDot_count++;
			}
			else if (dots[i].name == "rel dot(Clone)")
			{
				relDot_count++;
			}
			else if (dots[i].name == "tech dot(Clone)")
			{
				techDot_count++;
			}
		}
	}
}
