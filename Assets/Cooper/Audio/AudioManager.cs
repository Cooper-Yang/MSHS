using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    
    public AudioSource music;
    public AudioSource sFX;
    public AudioLowPassFilter musicLP;
    public AudioClip[] musicPieces;
    public AudioClip[] alienSounds;
    public AudioClip click;
    public AudioClip news;
    public AudioClip contiOnSelect;
    public AudioClip dealCard;
    public AudioClip mouseOnCard;
    public AudioClip dragCard;
    public AudioClip deleteCard;

    public bool cardOnce = true;
    bool gameStarted;
    int musicPiece;

    public static AudioManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void Update()
    {
        if (gameStarted && !music.isPlaying)
        {
            musicPiece += 1;
            if (musicPiece >= musicPieces.Length)
                musicPiece = 0;
            music.clip = musicPieces[musicPiece];
            music.Play();
        }
    }

    public void MusicStart()  //as player play the first card
    {
        if (!music.isPlaying)
        {
            musicPiece = 0;
            music.clip = musicPieces[0];
            music.Play();
            gameStarted = true;
            
        }
        
    }
    
    public void UseLowPass() //enter or exit UI
    {
        musicLP.enabled = !musicLP.enabled;

        if (music.volume > .2f)
            music.volume = .2f; //1 is max
        else
            music.volume = 0.8f;
    } 

    public void AfterPlay()
    {
        sFX.clip = click;
        sFX.Play();
    } //used a card

    public void ClickOnAliens() //remember to exit low pass   show alien stats
    {
        sFX.clip = alienSounds[Random.Range(0, alienSounds.Length)];
        sFX.Play();
        UseLowPass();
    } 

    public void BreakingNewsPop() //remember to exit low pass
    {
        sFX.clip = news;
        sFX.Play();
        UseLowPass();
    }

    
    public void DealCard() 
    {
        
        sFX.clip = dealCard;
        sFX.Play();
    }

    public void CursorOnCard() //will do on card
    {
        if (cardOnce)
        {
            sFX.clip = mouseOnCard;
            sFX.Play();
            cardOnce = false;
        }
        
        
    }

    public void DragCard() ////will do on card
    {
        sFX.clip = dragCard;
        sFX.Play();
    }

    public void DeletCard()
    {
        sFX.clip = deleteCard;
        sFX.Play();
    }
}
