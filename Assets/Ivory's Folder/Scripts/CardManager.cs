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
    }

    // Update is called once per frame
    void Update()
    {
        
        //DealCard();

        if (Input.GetKeyDown(KeyCode.Space)&& deck.Count<=10)
        {
            SpawnCard();
            DealCard();
            Debug.Log("card out");
        }
    }

    void SpawnCard()
    {
        int randnum = Random.Range(0, cards.Length);
        GameObject newCard = Instantiate(cards[randnum], new Vector2(cardSpawnPos.x, cardSpawnPos.y), Quaternion.identity);
        newCard.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        newCard.transform.localScale = new Vector3(newCard.transform.localScale.x*.1f, newCard.transform.localScale.y * .1f, newCard.transform.localScale.z * .1f);
        deck.Add(newCard);

    }

    void DealCard()
    {
        
        if (deck.Count > 0)
        {

            
            Vector2 lerpPos;
            Vector3 lerpScale;
            int theCardNum = deck.Count - 1;
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
