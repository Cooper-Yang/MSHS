using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "EffectCard")]
public class CardObject : ScriptableObject
{
	

	[Header("Card Infor(First letter of each word need to capitalize)")]
	[Header("File name is the number on card excel.")]
	public string cardName;
	[Header("!!! SET CARD LEVEL !!!")]
	public int cardLvl;
	
	[Header("Improvise the description. No need to mention if it's continent card")]
	
	public string description;
	
	[Header("Check if this is Continent Card")]
	public bool isConti;
	
	[Header("Check what is(are) the resource(s) of this card")]
	public bool politicsSource;
	public bool cultureSource;
	public bool religionSource;
	public bool technologySource;

	[Header("Check what kind(s) of value(s) this card changes")]
	public bool politics;
	public bool culture;
	public bool religion;
	public bool technology;
	
	[Header("Fill Changing values")]
	public int poliVal;
	public int culVal;
	public int reliVal;
	public int techVal;

	[Header("Change Generation Speed")]
	public float genVal;

	[Header("Discover value (small:+2/-5 medium:+5/-8 large:+10/-15)")]
	public int discovRate;

	[Header("Change life span (small:+2 medium:+3 large:+6)")]
	public int lifeVal;
	
	
	//public int discovEffect;

}
