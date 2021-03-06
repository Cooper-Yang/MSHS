﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager me;

    public static int polIndRan = -1;
    public static int culIndRan = -1;
    public static int tecIndRan = -1;
    public static int relIndRan = -1;

    //[SerializeField] private GameObject card;
    [SerializeField] private GameObject[] cards;
    [SerializeField] private CardMvmt CM;
    public List<GameObject> deck = new List<GameObject>();

    public Text cardCount;

    private float Posy = -3.7f;
    private float midPosx = -6f;
    //private float mid2Posx = -0.5f;

    private Vector2 cardSpawnPos;
    private Vector3 cardFinalScale;
    public bool onLerp = false;

    public GameObject CardBeingHeld;

    // Start is called before the first frame update
    void Start()
    {
        me = this;
        cardSpawnPos = new Vector2(-88f, 27f);
        cardFinalScale = new Vector3(0.058f, 0.058f, 0.058f);
        for (int i = 0; i < 10; i++)
        {
            deck.Add(null);
        }
        for (int i = 0; i < 5; i++)
        {
            SpawnAlienCard(i);
            DealCard(i);
        }
    }

    private void Update()
    {
        int cardNum = 10;
        for (int i = 0; i < deck.Count; i++)
        {
            if (deck[i] == null)
            {
                cardNum--;
            }
        }
        cardCount.text = cardNum + "/10";
    }

    public bool SendCard(float influencePol, float influenceRel, float influenceCol, float influenceTech)
    {
        
        int dealIndex = 0;
        bool candeal = false;
        for (int i = 0; i < deck.Count; i++)
        {
            if (deck[i] == null)
            {
                candeal = true;
                dealIndex = i;
                break;
            }
        }

        if (candeal)
        {
            
            //random here
            int num = Random.Range(0, 3);
            if(num == 0)//alien 
            {
                SpawnAlienCard(dealIndex);
                DealCard(dealIndex);
            }
            if (num == 1 || num ==2)//effect 
            {
                SpawnEffectCard(dealIndex, influencePol, influenceRel, influenceCol, influenceTech);
                DealCard(dealIndex);
            }

            
            Debug.Log("card out");

            return true;
        }

        return false;
    }

    public bool SendAlienCard()
    {
        int dealIndex = 0;
        bool candeal = false;
        for (int i = 0; i < deck.Count; i++)
        {
            if (deck[i] == null)
            {
                candeal = true;
                dealIndex = i;
                break;
            }
        }

        if (candeal)
        {
            SpawnAlienCard(dealIndex);
            DealCard(dealIndex);

            Debug.Log("alien card out");

            return true;
        }

        return false;
    }

    public void CardArgmt()//not working
    {
        for (int i = 0; i < deck.Count; i++)
        {
            if (deck[i] == null)
            {
                if (i <= deck.Count - 2)
                {
                    deck[i] = deck[i + 1];

                    deck[i].transform.position = new Vector2(midPosx + i * 1.3f, Posy);
                    deck[i + 1] = null;
                }
                

            }
        }

    }

    void SpawnEffectCard(int index, float influencePol, float influenceRel, float influenceCol, float influenceTech)
    {
        int randnum = 1; //card's random, decides whether alien card or effect cards
        GameObject newCard = Instantiate(cards[randnum], new Vector2(cardSpawnPos.x, cardSpawnPos.y), Quaternion.identity);

        newCard.GetComponent<CardReader>().loadCardScriptableObj(influencePol, influenceRel, influenceCol, influenceTech);
                                                //float sourcePol, float sourceRel, float sourceCol, float sourceTech

        newCard.transform.SetParent(GameObject.FindGameObjectWithTag("cardplace").transform);
        newCard.transform.localScale = new Vector3(newCard.transform.localScale.x*.1f, newCard.transform.localScale.y * .1f, newCard.transform.localScale.z * .1f);
        deck[index] = newCard;

    }

    void SpawnAlienCard(int index)
    {
        int randnum = 0;
        GameObject newCard = Instantiate(cards[randnum], new Vector2(cardSpawnPos.x, cardSpawnPos.y), Quaternion.identity);
        newCard.transform.SetParent(GameObject.FindGameObjectWithTag("cardplace").transform);
        newCard.transform.localScale = new Vector3(newCard.transform.localScale.x * .1f, newCard.transform.localScale.y * .1f, newCard.transform.localScale.z * .1f);
        deck[index] = newCard;
    }

    void DealCard(int index)
    {
        
        if (deck.Count > 0)
        {

            
            Vector2 lerpPos;
            Vector3 lerpScale;
            int theCardNum = index;
            GameObject thisCard = deck[theCardNum];
            StartCoroutine(LerpTime(5));

            IEnumerator LerpTime( float duration)
            {
                float time = 0;

                while (time < duration-4.5)
                {
                    lerpPos = Vector2.Lerp(thisCard.transform.position, new Vector2(midPosx+ (theCardNum) *1.3f, Posy), time/duration);
                    lerpScale = Vector3.Lerp(thisCard.transform.localScale, cardFinalScale, time / duration);
                    time += Time.deltaTime;
                    thisCard.transform.position = lerpPos;
                    thisCard.transform.localScale = lerpScale;
                    yield return null;
                }
                
                thisCard.transform.localScale = cardFinalScale;
                thisCard.transform.position = new Vector2(midPosx + (theCardNum) * 1.3f, Posy);
                thisCard.transform.GetComponent<CardMvmt>().enabled= true;
                thisCard.transform.GetComponent<CardDelete>().enabled = true;
                //thisCard.transform.position = thisCard.GetComponent<CardAnimation>().cardPos;
                //yield return null;

            }



        }
        
    }



}
