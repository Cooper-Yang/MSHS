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
    private Vector2 currentMPos;

    public Vector3 cardPos;
    public Vector3 mousePos;

    public bool mouseOn = false;
    public bool dragging;

    // Start is called before the first frame update
    void Start()
    {
        cardTransform = GetComponent<Transform>();
        originalPos = cardTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
        moveCardUp();
        dragCards();
        cardTransform.position = cardPos;
    }

    public void moveCardUp()
    {
        float lerpGoal = 1;
        float lerpTime = .1f;
        float lerpValue;
        Vector2 lerpPos;


        if (mouseOn == true)
        {
            
                lerpValue = Mathf.Lerp(cardTransform.position.y, originalPos.y + lerpGoal, Time.deltaTime / lerpTime);
                cardPos = new Vector2(cardTransform.position.x, lerpValue);
            
            
        }
        if (mouseOn == false)
        {
            lerpPos = Vector2.Lerp(cardTransform.position, originalPos, Time.deltaTime / lerpTime);
            cardPos = lerpPos;
           
        }

        
    }

    public void dragCards()
    {
        if(dragging == true)
        {
            cardPos = new Vector3(mousePos.x, mousePos.y, cardPos.z);
            mouseOn = false;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (dragging == false)
        {
            mouseOn = true;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOn = false;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
