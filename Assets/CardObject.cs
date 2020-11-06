using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardObject : ScriptableObject
{
	public string cardName;

	public Sprite background;

	public Sprite artwork;

	public Sprite icon;
	public string description;
	public int lifeSpan;
	public int generateSpeed;
}
