using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardReader : MonoBehaviour
{
    public CardObject card;

    public Text cardName;
    
    public Image background;
    public Image artwork;

    public Image icon;
    public Text description;
    public Text lifeSpan;
    public Text generateSpeed;

    void Start()
    {
        cardName.text = card.cardName;
        background.sprite = card.background;
        artwork.sprite = card.artwork;
        icon.sprite = card.icon;
        description.text = card.description;
        lifeSpan.text = card.lifeSpan.ToString();
        generateSpeed.text = card.generateSpeed.ToString();
    }

    
}
