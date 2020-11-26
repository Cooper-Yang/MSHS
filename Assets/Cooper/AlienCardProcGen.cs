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

    public int propertyMin;
    public int propertyMax;
    public int lifeMin;
    public int lifeMax;
    public int totalAbility;

    public List<float> properties;
    
    // Start is called before the first frame update
    void Start()
    {
        // initialize list
        for (int i = 0; i < 5; i++)
        {
            properties.Add(0);
        }
        genSpeed = 3; //value unsure
        discoverRate = 2;//small

        //head Generate
        head.sprite = headSpr[Random.Range(0, headSpr.Length)];
        eyes.sprite = eyesSpr[Random.Range(0, eyesSpr.Length)];
        mouth.sprite = mouthSpr[Random.Range(0, mouthSpr.Length)];

        SetValues();
        lifeSpan.text = "Life Span: " + lifeSpanNumber;
    }

    private void SetValues()
    {
        // roll numbers
        for (int i = 0; i < properties.Count; i++)
        {
            properties[i] = Random.Range(0, totalAbility);
            totalAbility -= (int)properties[i];
        }
        // shuffle numbers
        for (int i = 0; i < properties.Count; i++)
        {
            float temp = properties[i];
            int randomIndex = Random.Range(i, properties.Count);
            properties[i] = properties[randomIndex];
            properties[randomIndex] = temp;
        }
        // set numbers
        cul = (int) (properties[0] / 100 * propertyMax);
        rel = (int)(properties[1] / 100 * propertyMax);
        pol = (int)(properties[2] / 100 * propertyMax);
        tech = (int)(properties[3] / 100 * propertyMax);
        lifeSpanNumber = 9 + (int)(properties[4] / 100 * lifeMax);
        // set bar
        culIcon.sizeDelta = new Vector2((100-8)*properties[0]/100, 19);
        relIcon.sizeDelta = new Vector2((100-8)*properties[1]/100, 19);
        polIcon.sizeDelta = new Vector2((100-8)*properties[2]/100, 19);
        techIcon.sizeDelta = new Vector2((100-8)*properties[3]/100, 19);
    }
}
