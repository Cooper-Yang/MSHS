using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    static public GameManager me;

    public GameObject canvas;
    public GameObject trash;
    public GameObject summon;
    public GameObject news;
    public GameObject cards;

    public float world_interval;
    public GameObject politicDotPrefab;
    public GameObject religionDotPrefab;
    public GameObject cultureDotPrefab;
    public GameObject techDotPrefab;
    public GameObject africa;
    public GameObject northAmerica;
    public GameObject southAmerica;
    public GameObject asia;
    public GameObject europe;
    public GameObject australia;

    public float pol_gl;
    public float cul_gl;
    public float rel_gl;
    public float tech_gl;

    public List<GameObject> aliens;


    public float dot_addAmount;


    // state ctrl
    public int state = 0;
    public int splash_screen = 0;
    public int game_screen = 1;
    public int game_over = 2;
    public int good_ending_screen = 3;
    public GameObject UGotCaughtByHuman;
    public SpriteRenderer outL;
    public SpriteRenderer indL;
    public TextMeshProUGUI ending_ugui;
    private bool culDefeat = false;
    private bool polDefeat = false;
    private bool relDefeat = false;
    private bool techDefeat = false;

    [TextArea]
    public string culDefeat_text;
    [TextArea]
    public string polDefeat_text;
    [TextArea]
    public string relDefeat_text;
    [TextArea]
    public string techDefeat_text;

    public int buff;

    public enum thingy
	{
        pol, cul, rel, tech
	}

    // Start is called before the first frame update
    void Awake()
    {
        me = this;
        aliens = new List<GameObject>();
        state = game_screen;
    }

	private void Update()
	{
        SceneManagement();

    }

	public void CalculateGlobalNums()
	{
        pol_gl = (africa.GetComponent<ContinentScript>().pol_cont +
                 northAmerica.GetComponent<ContinentScript>().pol_cont +
                 southAmerica.GetComponent<ContinentScript>().pol_cont +
                 europe.GetComponent<ContinentScript>().pol_cont +
                 asia.GetComponent<ContinentScript>().pol_cont +
                 australia.GetComponent<ContinentScript>().pol_cont) / 6;
        cul_gl = (africa.GetComponent<ContinentScript>().cul_cont +
                 northAmerica.GetComponent<ContinentScript>().cul_cont +
                 southAmerica.GetComponent<ContinentScript>().cul_cont +
                 europe.GetComponent<ContinentScript>().cul_cont +
                 asia.GetComponent<ContinentScript>().cul_cont +
                 australia.GetComponent<ContinentScript>().cul_cont) / 6;
        rel_gl = (africa.GetComponent<ContinentScript>().rel_cont +
                 northAmerica.GetComponent<ContinentScript>().rel_cont +
                 southAmerica.GetComponent<ContinentScript>().rel_cont +
                 europe.GetComponent<ContinentScript>().rel_cont +
                 asia.GetComponent<ContinentScript>().rel_cont +
                 australia.GetComponent<ContinentScript>().rel_cont) / 6;
        tech_gl = (africa.GetComponent<ContinentScript>().tech_cont +
                 northAmerica.GetComponent<ContinentScript>().tech_cont +
                 southAmerica.GetComponent<ContinentScript>().tech_cont +
                 europe.GetComponent<ContinentScript>().tech_cont +
                 asia.GetComponent<ContinentScript>().tech_cont +
                 australia.GetComponent<ContinentScript>().tech_cont) / 6;
    }

    public void UpdateAlienList()
    {
        aliens.Clear();
        foreach (var alien in africa.GetComponent<ContinentScript>().myAliens)
        {
            aliens.Add(alien);
        }
        foreach (var alien in northAmerica.GetComponent<ContinentScript>().myAliens)
        {
            aliens.Add(alien);
        }
        foreach (var alien in southAmerica.GetComponent<ContinentScript>().myAliens)
        {
            aliens.Add(alien);
        }
        foreach (var alien in europe.GetComponent<ContinentScript>().myAliens)
        {
            aliens.Add(alien);
        }
        foreach (var alien in asia.GetComponent<ContinentScript>().myAliens)
        {
            aliens.Add(alien);
        }
        foreach (var alien in australia.GetComponent<ContinentScript>().myAliens)
        {
            aliens.Add(alien);
        }
    }

    public void SceneManagement()
	{
        if (NewsControl.me.culPhase >= 15 )
		{
            outL.color = new Color(0,100,0);
            indL.color = new Color(0, 170, 0);
            ending_ugui.text = "You Won.\nOur culture is trending in human society.\nIt took "+ TurnsManager._instance.turns + " turns to prevail.";
            UGotCaughtByHuman.SetActive(true);
            state = game_over;
        }
        else if (NewsControl.me.relPhase >= 15)
        {
            outL.color = new Color(0, 100, 0);
            indL.color = new Color(0, 170, 0);
            ending_ugui.text = "You Won.\nWe, the God of human.\nIt took " + TurnsManager._instance.turns + " turns to prevail.";
            UGotCaughtByHuman.SetActive(true);
            state = game_over;
        }
        else if (NewsControl.me.polPhase >= 15)
        {
            outL.color = new Color(0, 100, 0);
            indL.color = new Color(0, 170, 0);
            ending_ugui.text = "You Won.\nThere are no more politics among human.\nIt took " + TurnsManager._instance.turns + " turns to prevail.";
            UGotCaughtByHuman.SetActive(true);
            state = game_over;
        }
        else if (NewsControl.me.tecPhase >= 15)
        {
            outL.color = new Color(0, 100, 0);
            indL.color = new Color(0, 170, 0);
            ending_ugui.text = "You Won.\nHumans' inferior technology has proven their imminent defeat.\nIt took " + TurnsManager._instance.turns + " turns to prevail.";
            UGotCaughtByHuman.SetActive(true);
            state = game_over;
        }
        else if (stealthlv._instance.stealthlev >= 100)
		{
            // game over
            if (cul_gl < rel_gl && cul_gl < pol_gl && cul_gl < tech_gl)
			{
                culDefeat = true;
			}
            else if (rel_gl < cul_gl && rel_gl < pol_gl && rel_gl < tech_gl)
			{
                relDefeat = true;
			}
            else if (pol_gl < cul_gl && pol_gl < rel_gl && pol_gl < tech_gl)
			{
                polDefeat = true;
			}
            else if (tech_gl < cul_gl && tech_gl < rel_gl && tech_gl < pol_gl)
			{
                techDefeat = true;
			}
            if (culDefeat)
			{
                ending_ugui.text = culDefeat_text + "\nYour infiltration lasted for " + TurnsManager._instance.turns + " turns.\nPress R to Restart.";
            }
            else if (relDefeat)
			{
                ending_ugui.text = relDefeat_text + "\nYour infiltration lasted for " + TurnsManager._instance.turns + " turns.\nPress R to Restart.";
            }
            else if (polDefeat)
            {
                ending_ugui.text = polDefeat_text + "\nYour infiltration lasted for " + TurnsManager._instance.turns + " turns.\nPress R to Restart.";
            }
            else if (techDefeat)
            {
                ending_ugui.text = techDefeat_text + "\nYour infiltration lasted for " + TurnsManager._instance.turns + " turns.\nPress R to Restart.";
            }
            UGotCaughtByHuman.SetActive(true);
            state = game_over;
		}
        if (state == game_over)
		{
            canvas.SetActive(false);
            summon.SetActive(false);
            trash.SetActive(false);
            news.SetActive(false);
            cards.SetActive(false);
            if (Input.GetKeyDown(KeyCode.R))
			{
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);

            }
		}
    }
}
