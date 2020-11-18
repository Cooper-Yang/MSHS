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

    int poliVal;
    int culVal;
    int reliVal;
    int techVal;
    int genVal;
    int lifeVal;


    void Start()
    {
        cardName.text = card.cardName;
        techIcon.SetActive(card.technology);
        culIcon.SetActive(card.culture);
        reliIcon.SetActive(card.religion);
        poliIcon.SetActive(card.politics);

        description.text = card.description;

        poliVal = card.poliVal;
        culVal = card.culVal;
        reliVal = card.reliVal;
        techVal = card.techVal;
        genVal = card.genVal;
        lifeVal = card.lifeVal;
    }



    
}
