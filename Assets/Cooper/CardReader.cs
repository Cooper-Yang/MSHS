using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardReader : MonoBehaviour
{
    public Image backGround;
    public Sprite contiBack;
    public Sprite normalBack;
    public CardObject card;
    public Text cardName;

    public GameObject techIcon;
    public GameObject culIcon;
    public GameObject reliIcon;
    public GameObject poliIcon;
    public Text description;

    public bool isConti;

    public int poliVal;
    public int culVal;
    public int reliVal;
    public int techVal;
    public float genVal;
    public int lifeVal;

    public int cardLvl; //Coop: for what
    public int discovRate;
    //int discovEffect;

    void Start()
    {
        //loadCardScriptableObj();
        

    }

    public void loadCardScriptableObj(float influencePol, float influenceRel, float influenceCol, float influenceTech)
    {
        //random
        float influenceAll = influencePol + influenceRel + influenceCol + influenceTech;
        float num = Random.value;
        /*if(num < influencePol/influenceAll)//politics
        {
            card = CardHolder._instance.politicDeckLevelOne[Random.Range(0, CardHolder._instance.politicDeckLevelOne.Count)];
        }
        else if(num < influencePol / influenceAll + influenceRel / influenceAll)//religion
        {
            card = CardHolder._instance.religionDeckLevelOne[Random.Range(0, CardHolder._instance.religionDeckLevelOne.Count)];
        }
        else if(num< influencePol / influenceAll + influenceRel / influenceAll + influenceCol / influenceAll)//culture
        {
            card = CardHolder._instance.cultureDeckLevelOne[Random.Range(0, CardHolder._instance.cultureDeckLevelOne.Count)];
        }
        else if(num< influencePol / influenceAll + influenceRel / influenceAll + influenceCol / influenceAll + influenceTech / influenceAll)//technology
        {
            card = CardHolder._instance.technologyDeckLevelOne[Random.Range(0, CardHolder._instance.technologyDeckLevelOne.Count)];
        }*/

        if (num < 25)//politics
        {
            card = CardHolder._instance.politicDeckLevelOne[Random.Range(0, CardHolder._instance.politicDeckLevelOne.Count)];
        }
        else if (num >=25 && num <50)//religion
        {
            card = CardHolder._instance.religionDeckLevelOne[Random.Range(0, CardHolder._instance.religionDeckLevelOne.Count)];
        }
        else if (num >= 50 && num < 75)//culture
        {
            card = CardHolder._instance.cultureDeckLevelOne[Random.Range(0, CardHolder._instance.cultureDeckLevelOne.Count)];
        }
        else if (num >= 75 && num < 100)//technology
        {
            card = CardHolder._instance.technologyDeckLevelOne[Random.Range(0, CardHolder._instance.technologyDeckLevelOne.Count)];
        }

        cardName.text = card.cardName;
        techIcon.SetActive(card.technology);
        culIcon.SetActive(card.culture);
        reliIcon.SetActive(card.religion);
        poliIcon.SetActive(card.politics);

        description.text = card.description;

        isConti = card.isConti;
        if (isConti)
        {
            backGround.sprite = contiBack;
            description.text = "This card affects all aliens in the same continent." + description.text;
        }
        else
        {
            backGround.sprite = normalBack;
        }

        poliVal = card.poliVal;
        culVal = card.culVal;
        reliVal = card.reliVal;
        techVal = card.techVal;
        genVal = card.genVal;
        lifeVal = card.lifeVal;

        cardLvl = card.cardLvl;
        discovRate = card.discovRate;
    }


}
