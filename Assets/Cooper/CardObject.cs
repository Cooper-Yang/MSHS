using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "EffectCard")]
public class CardObject : ScriptableObject
{
	public string cardName;
	public string description;

	public bool isConti;

	public bool politics;
	public bool culture;
	public bool religion;
	public bool technology;

	public int poliVal;
	public int culVal;
	public int reliVal;
	public int techVal;
	public int genVal;
	public int lifeVal;
	public int cardLvl;
	public int discovRate;
	//public int discovEffect;

}
