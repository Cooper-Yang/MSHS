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

    public int cul;
    public int rel;
    public int pol;
    public int tech;
    public int lifeSpanNumber;
    public int genSpeed;
    public int discoverRate;
    
    // Start is called before the first frame update
    void Start()
    {

        genSpeed = 3; //value unsure
        discoverRate = 2;//small


        lifeSpanNumber = 9;
        lifeSpan.text = "Life Span: " +lifeSpan;

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
                cul = 0;
                rel = 0;
                pol = 100;
                tech =0;
                break;
            case 1:
                polIcon.sizeDelta = minStat;
                culIcon.sizeDelta = maxStat;
                relIcon.sizeDelta = minStat;
                techIcon.sizeDelta = minStat;
                cul = 100;
                rel = 0;
                pol = 0;
                tech = 0;
                break;
            case 2:
                polIcon.sizeDelta = minStat;
                culIcon.sizeDelta = minStat;
                relIcon.sizeDelta = maxStat;
                techIcon.sizeDelta = minStat;
                cul = 0;
                rel = 100;
                pol = 0;
                tech = 0;
                break;
            case 3:
                polIcon.sizeDelta = minStat;
                culIcon.sizeDelta = minStat;
                relIcon.sizeDelta = minStat;
                techIcon.sizeDelta = maxStat;
                cul = 0;
                rel = 0;
                pol = 0;
                tech = 100;
                break;
        }



        

    }
}
