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
        if (GameManager.me.pol_gl>33.3)
        {
            politicDeckLevelOne.AddRange(politicDeckLevelTwo);
        }
        if (GameManager.me.pol_gl > 66.6)
        {
            politicDeckLevelOne.AddRange(politicDeckLevelThree);
        }

        if (GameManager.me.cul_gl > 33.3)
        {
            cultureDeckLevelOne.AddRange(cultureDeckLevelTwo);
        }
        if (GameManager.me.cul_gl > 66.6)
        {
            cultureDeckLevelOne.AddRange(cultureDeckLevelThree);
        }

        if (GameManager.me.rel_gl > 33.3)
        {
            religionDeckLevelOne.AddRange(religionDeckLevelTwo);
        }
        if (GameManager.me.rel_gl > 66.6)
        {
            religionDeckLevelOne.AddRange(religionDeckLevelThree);
        }

        if (GameManager.me.tech_gl > 33.3)
        {
            technologyDeckLevelOne.AddRange(technologyDeckLevelTwo);
        }
        if (GameManager.me.tech_gl > 66.6)
        {
            technologyDeckLevelOne.AddRange(technologyDeckLevelTwo);
        }


    }
}
