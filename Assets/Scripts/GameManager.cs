using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Animator anim;

    public Card firstCard;
    public Card secondCard;

    public GameObject endTxt;
    public Text timeTxt;
    

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    float time = 10.0f;
    float direction = 0.1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        anim.SetBool("isMove", false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time < 0.0f)
        {
            endTxt.SetActive(true);
        }
        if (time > 10.0f)
        {
            timeTxt.color = Color.white;
        }
        else
        {
            timeTxt.color = new Color(255 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);
            anim.SetBool("isMove", true);
        }
    }

    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if(cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    
}
