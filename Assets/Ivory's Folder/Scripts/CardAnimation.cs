using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    private Vector2 screenPosition;
    private Vector2 worldPosition;
    private Transform cardTransform;
    private Vector2 originalPos;
    private Vector2 currentMPos;

    public Vector2 cardPos;

    public bool mouseOn = false;
    public bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        cardTransform = GetComponent<Transform>();
        originalPos = new Vector2(0f, -3.12f);
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        moveCardUp();
        cardTransform.position = cardPos;
    }

    public void moveCardUp()
    {
        float lerpGoal = 1;
        float lerpTime = .1f;
        float lerpValue;

        if (mouseOn == true)
        {
            lerpValue = Mathf.Lerp(cardTransform.position.y, originalPos.y + lerpGoal, Time.deltaTime / lerpTime);
            cardPos = new Vector2(cardTransform.position.x, lerpValue);
            //cardTransform.position = new Vector2(cardTransform.position.x, lerpValue);
        }
        if (mouseOn == false)
        {
            cardPos = originalPos;
            //cardTransform.position = originalPos;
        }
        
    }

    void OnMouseEnter()
    {
        mouseOn = true;
        currentMPos = screenPosition;


    }


    void OnMouseExit()
    {

        mouseOn = false;


    }
}
