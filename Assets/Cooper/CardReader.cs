using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardReader : MonoBehaviour
{
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
    public int genVal;
    public int lifeVal;

    public int cardLvl; //Coop: for what
    public int discovRate;
    //int discovEffect;

    void Start()
    {
        cardName.text = card.cardName;
        techIcon.SetActive(card.technology);
        culIcon.SetActive(card.culture);
        reliIcon.SetActive(card.religion);
        poliIcon.SetActive(card.politics);

        description.text = card.description;
        
        isConti = card.isConti;
        if (isConti)
        {
            description.text = "This card affects all aliens in the same continent." + description.text;
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
