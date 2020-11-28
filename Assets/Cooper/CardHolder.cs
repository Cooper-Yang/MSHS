using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//this is a singelton 
public class CardHolder : MonoBehaviour
{
    public static CardHolder _instance;

    public List<CardObject> allCard = new List<CardObject>();
    //sourcePol,sourceRel,sourceCol,sourceTech
    public List<CardObject> politicDeckLevelOne = new List<CardObject>();
    public List<CardObject> politicDeckLevelTwo = new List<CardObject>();
    public List<CardObject> politicDeckLevelThree = new List<CardObject>();

    public List<CardObject> religionDeckLevelOne = new List<CardObject>();
    public List<CardObject> religionDeckLevelTwo = new List<CardObject>();
    public List<CardObject> religionDeckLevelThree = new List<CardObject>();

    public List<CardObject> cultureDeckLevelOne = new List<CardObject>();
    public List<CardObject> cultureDeckLevelTwo = new List<CardObject>();
    public List<CardObject> cultureDeckLevelThree = new List<CardObject>();

    public List<CardObject> technologyDeckLevelOne = new List<CardObject>();
    public List<CardObject> technologyDeckLevelTwo = new List<CardObject>();
    public List<CardObject> technologyDeckLevelThree = new List<CardObject>();

    bool p1 = true;
    bool p2 = true;
    bool c1 = true;
    bool c2 = true;
    bool r1 = true;
    bool r2 = true;
    bool t1 = true;
    bool t2 = true;

    public static CardHolder Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        allCard= Resources.LoadAll("EffectCard", typeof(CardObject)).Cast<CardObject>().ToList();

        for (int i = 0; i < allCard.Count; i++)
        {
            if (allCard[i].politicsSource)
            {
                switch (allCard[i].cardLvl)
                {
                    case 1:
                        politicDeckLevelOne.Add(allCard[i]);
                        break;
                    case 2:
                        politicDeckLevelTwo.Add(allCard[i]);
                        break;
                    case 3:
                        politicDeckLevelThree.Add(allCard[i]);
                        break;
                    default:
                        Debug.LogError(allCard[i].cardName + "'s level is not set!");
                        break;
                }

            }

            if (allCard[i].cultureSource)
            {
                switch (allCard[i].cardLvl)
                {
                    case 1:
                        cultureDeckLevelOne.Add(allCard[i]);
                        break;
                    case 2:
                        cultureDeckLevelTwo.Add(allCard[i]);
                        break;
                    case 3:
                        cultureDeckLevelThree.Add(allCard[i]);
                        break;
                    default:
                        Debug.LogError(allCard[i].cardName + "'s level is not set!");
                        break;
                }

            }

            if (allCard[i].religionSource)
            {
                switch (allCard[i].cardLvl)
                {
                    case 1:
                        religionDeckLevelOne.Add(allCard[i]);
                        break;
                    case 2:
                        religionDeckLevelTwo.Add(allCard[i]);
                        break;
                    case 3:
                        religionDeckLevelThree.Add(allCard[i]);
                        break;
                    default:
                        Debug.LogError(allCard[i].cardName + "'s level is not set!");
                        break;
                }

            }

            if (allCard[i].technologySource)
            {
                switch (allCard[i].cardLvl)
                {
                    case 1:
                        technologyDeckLevelOne.Add(allCard[i]);
                        break;
                    case 2:
                        technologyDeckLevelTwo.Add(allCard[i]);
                        break;
                    case 3:
                        technologyDeckLevelThree.Add(allCard[i]);
                        break;
                    default:
                        Debug.LogError(allCard[i].cardName + "'s level is not set!");
                        break;
                }

            }
        }
    }

    private void Update()
    {
        
        if (GameManager.me.pol_gl>33.3 && p1)
        {
            politicDeckLevelOne.AddRange(politicDeckLevelTwo);
            p1 = false;
        }
        if (GameManager.me.pol_gl > 66.6 && p2)
        {
            politicDeckLevelOne.AddRange(politicDeckLevelThree);
            p2 = false;
        }

        if (GameManager.me.cul_gl > 33.3 && c1)
        {
            cultureDeckLevelOne.AddRange(cultureDeckLevelTwo);
            c1 = false;
        }
        if (GameManager.me.cul_gl > 66.6 && c2)
        {
            cultureDeckLevelOne.AddRange(cultureDeckLevelThree);
            c2 = false;
        }

        if (GameManager.me.rel_gl > 33.3 && r1)
        {
            religionDeckLevelOne.AddRange(religionDeckLevelTwo);
            r1 = false;
        }
        if (GameManager.me.rel_gl > 66.6 && r2)
        {
            religionDeckLevelOne.AddRange(religionDeckLevelThree);
            r2 = false;
        }

        if (GameManager.me.tech_gl > 33.3 && t1)
        {
            technologyDeckLevelOne.AddRange(technologyDeckLevelTwo);
            t1 = false;
        }
        if (GameManager.me.tech_gl > 66.6 && t2)
        {
            technologyDeckLevelOne.AddRange(technologyDeckLevelTwo);
            t2 = false;
        }


    }
}
