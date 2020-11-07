using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private CardAnimation CA;
    public List<GameObject> deck = new List<GameObject>();
    public List<CardAnimation> CAs = new List<CardAnimation>();

    private float Posy = -3.12f;
    private float midPosx = 0f;
    private float mid2Posx = -0.5f;

    private Vector2 cardSpawnPos;
    private Vector3 cardFinalScale;
    public bool onLerp = false;

    private Vector2 screenPosition;
    private Vector2 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        cardSpawnPos = new Vector2(-10f, 9.2f);
        cardFinalScale = new Vector3(1.9f, 2.4f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //DealCard();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCard();
            DealCard();
        }
    }

    void SpawnCard()
    {
        GameObject newCard = Instantiate(card, new Vector2(cardSpawnPos.x, cardSpawnPos.y), Quaternion.identity);
        newCard.transform.localScale = new Vector3(newCard.transform.localScale.x*.1f, newCard.transform.localScale.y * .1f, newCard.transform.localScale.z * .1f);
        CardAnimation newCA = newCard.GetComponent<CardAnimation>();

        deck.Add(newCard);
        CAs.Add(newCA);
    }

    void DealCard()
    {
        
        if (deck.Count > 0)
        {

            
            Vector2 lerpPos;
            Vector3 lerpScale;
            GameObject thisCard = deck[deck.Count - 1];
            StartCoroutine(LerpTime(5));

            IEnumerator LerpTime( float duration)
            {
                float time = 0;

                while (time < duration-4.5)
                {
                    lerpPos = Vector2.Lerp(thisCard.transform.position, new Vector2(midPosx, Posy), time/duration);
                    lerpScale = Vector3.Lerp(thisCard.transform.localScale, cardFinalScale, time / duration);
                    time += Time.deltaTime;
                    thisCard.transform.position = lerpPos;
                    thisCard.transform.localScale = lerpScale;
                    yield return null;
                }
                
                thisCard.transform.localScale = cardFinalScale;
                thisCard.transform.position = new Vector2(midPosx, Posy);
                thisCard.transform.GetComponent<CardAnimation>().enabled= true;
                //thisCard.transform.position = thisCard.GetComponent<CardAnimation>().cardPos;
                //yield return null;

            }



        }
        
    }



}
