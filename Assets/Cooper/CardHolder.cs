using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a singelton 
public class CardHolder : MonoBehaviour
{
    public static CardHolder _instance;


    public List<CardObject> deck = new List<CardObject>();
   

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

    void Start()
    {
        newCard();
    }

    public void newCard() //add card
    {
        GameObject theCard = (GameObject)Resources.Load("AlienHankCard");
        Instantiate(theCard, transform);
    }

    public void playCard(int cardNum) //play a certain card
    {

    }

    public void displayDeck()
    {

    }
}
