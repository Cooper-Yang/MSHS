using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject[] cards;
    [SerializeField] private CardMvmt CM;
    public List<GameObject> deck = new List<GameObject>();

    private float Posy = -3.7f;
    private float midPosx = -7f;
    private float mid2Posx = -0.5f;

    private Vector2 cardSpawnPos;
    private Vector3 cardFinalScale;
    public bool onLerp = false;


    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {

        

    }
    public bool SendCard()
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

            SpawnCard(dealIndex);
            DealCard(dealIndex);
            Debug.Log("card out");

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

    void SpawnCard(int index)
    {
        int randnum = Random.Range(0, cards.Length);
        GameObject newCard = Instantiate(cards[randnum], new Vector2(cardSpawnPos.x, cardSpawnPos.y), Quaternion.identity);
        newCard.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        newCard.transform.localScale = new Vector3(newCard.transform.localScale.x*.1f, newCard.transform.localScale.y * .1f, newCard.transform.localScale.z * .1f);
        deck[index] = newCard;

    }

    void SpawnAlienCard(int index)
    {
        int randnum = 0;
        GameObject newCard = Instantiate(cards[randnum], new Vector2(cardSpawnPos.x, cardSpawnPos.y), Quaternion.identity);
        newCard.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
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
