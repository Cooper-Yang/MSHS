using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
	public bool pol;
	public bool rel;
	public bool cul;
	public bool tech;
	private void Update()
	{
		if (pol)
		{
			transform.localScale = new Vector3(GameManager.me.pol_gl / 10, transform.localScale.y, transform.localScale.z);
		}
		else if (rel)
		{
			transform.localScale = new Vector3(GameManager.me.rel_gl / 10, transform.localScale.y, transform.localScale.z);
		}
		else if (cul)
		{
			transform.localScale = new Vector3(GameManager.me.cul_gl / 10, transform.localScale.y, transform.localScale.z);
		}
		else if (tech)
		{
			transform.localScale = new Vector3(GameManager.me.tech_gl / 10, transform.localScale.y, transform.localScale.z);
		}
	}
}
