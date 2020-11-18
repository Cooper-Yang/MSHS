using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienCardProcGen : MonoBehaviour
{
    //assign field
    
    public Text lifeSpan;
    public RectTransform culIcon;
    public RectTransform relIcon;
    public RectTransform polIcon;
    public RectTransform techIcon;

    public Image head;
    public Image eyes;
    public Image mouth;

    public Sprite[] headSpr;
    public Sprite[] eyesSpr;
    public Sprite[] mouthSpr;

    public int genSpeed;
    
    // Start is called before the first frame update
    void Start()
    {

        genSpeed = 1; //value unsure
        
        
        lifeSpan.text = "Life Span: " + Random.Range(10, 31);

        int randomStat = Random.Range(0,4);         //0 = Poli, 1= culture, 2 = religion, 3= tech 

        //head Generate
        head.sprite = headSpr[Random.Range(0, headSpr.Length)];
        eyes.sprite = eyesSpr[Random.Range(0, eyesSpr.Length)];
        mouth.sprite = mouthSpr[Random.Range(0, mouthSpr.Length)];

        Vector2 maxStat = new Vector2(165, 19);
        Vector2 minStat = new Vector2(8, 19);
        switch (randomStat)
        {
            
            case 0:
                polIcon.sizeDelta = maxStat;
                culIcon.sizeDelta = minStat;
                relIcon.sizeDelta = minStat;
                techIcon.sizeDelta = minStat;
                break;
            case 1:
                polIcon.sizeDelta = minStat;
                culIcon.sizeDelta = maxStat;
                relIcon.sizeDelta = minStat;
                techIcon.sizeDelta = minStat;
                break;
            case 2:
                polIcon.sizeDelta = minStat;
                culIcon.sizeDelta = minStat;
                relIcon.sizeDelta = maxStat;
                techIcon.sizeDelta = minStat;
                break;
            case 3:
                polIcon.sizeDelta = minStat;
                culIcon.sizeDelta = minStat;
                relIcon.sizeDelta = minStat;
                techIcon.sizeDelta = maxStat;
                break;
            case 4:
                polIcon.sizeDelta = minStat;
                culIcon.sizeDelta = minStat;
                relIcon.sizeDelta = minStat;
                techIcon.sizeDelta = maxStat;
                break;
        }



        

    }
}
