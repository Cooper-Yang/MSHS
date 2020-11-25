using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMvmt : MonoBehaviour
    ,IPointerEnterHandler
    ,IPointerExitHandler
    ,IPointerDownHandler
    ,IPointerUpHandler

{

    private Transform cardTransform;
    private Vector2 originalPos;
    public Vector2 originalScal;
    private Vector2 currentMPos;
    private Vector2 targetScale;

    public Vector3 cardPos;
    public Vector3 cardScal;
    public Vector3 mousePos;

    public bool mouseOn = false;
    public bool dragging;

    CardAudio cA;

    // Start is called before the first frame update
    void Start()
    {
        cardTransform = GetComponent<Transform>();
        originalPos = cardTransform.position;
        originalScal = cardTransform.localScale;
        cardScal = originalScal;
        targetScale = originalScal;
        cA = GetComponent<CardAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.me.state == GameManager.me.game_screen)
		{
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
            moveCardUp();
            dragCards();
            cardTransform.position = cardPos;
            cardTransform.localScale = cardScal;
        } 
    }




    public void moveCardUp()
    {
        float lerpGoal = 1;
        float lerpTime = .1f;
        float lerpValue;
        float scaleLerpGoal = .07f;
        float scaleLerpValue;
        Vector2 lerpPos;
        

        if (mouseOn == true)
        {
            lerpValue = Mathf.Lerp(cardTransform.position.y, originalPos.y + lerpGoal, Time.deltaTime / lerpTime);
            cardPos = new Vector2(cardTransform.position.x, lerpValue);
            //AudioManager._instance.CursorOnCard();
            scaleLerpValue = Mathf.Lerp(cardTransform.localScale.x, originalScal.x + scaleLerpGoal, Time.deltaTime / lerpTime);
            cardScal = new Vector2(scaleLerpValue, scaleLerpValue);
            this.transform.SetAsLastSibling();
        }
        if (mouseOn == false)
        {
            lerpPos = Vector2.Lerp(cardTransform.position, originalPos, Time.deltaTime / lerpTime);
            cardPos = lerpPos;
            //AudioManager._instance.cardOnce = true;
            scaleLerpValue = Mathf.Lerp(cardTransform.localScale.x, targetScale.x , Time.deltaTime / lerpTime);
            cardScal = new Vector2(scaleLerpValue, scaleLerpValue);
        }

        
    }

    public void dragCards()
    {
        if(dragging == true)
        {
            cardPos = new Vector3(mousePos.x, mousePos.y, cardPos.z);
            mouseOn = false;
            cA.dragCard();
            // shrink card
            // if close to any of the aliens, the closer it gets the smaller it is
            if (gameObject.tag == "EffectCard" && !GetComponent<CardReader>().isConti) // if im a non conti effect card
            {
                
                float shortestDis = 1000;
                foreach (var alien in GameManager.me.aliens)
                {
                    
                    if (alien != null &&Vector2.Distance(cardTransform.position, alien.transform.position) < shortestDis  )
                    {
                        shortestDis = Vector2.Distance(cardTransform.position, alien.transform.position);
                    }
                }
                float clampedVal = originalScal.x * shortestDis * 0.5f;
                clampedVal = Mathf.Clamp(clampedVal, 0.02f, originalScal.x);
                targetScale = new Vector2(clampedVal, clampedVal);
                
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cA.OnCard();
        if (dragging == false)
        {
            mouseOn = true;
            
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOn = false;
        //contiImOn = null;
        cA.canDragPlay = true;
        cA.canOnPlay = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        CardManager.me.CardBeingHeld = gameObject;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        CardManager.me.CardBeingHeld = null;
        targetScale = originalScal;
        //contiImOn = null;
    }
}
