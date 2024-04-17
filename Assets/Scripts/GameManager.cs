using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    float time = 0.0f;
    public int DeathCount;
    public GameObject imageDeath1;
    public GameObject imageDeath2;
    public GameObject imageDeath3;

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
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time > 30f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
            }
            else if (cardCount != 0)
            {
                if (DeathCount == 1)
                {

                    firstCard.DestroyCard();
                    secondCard.DestroyCard();
                    DeathCount -= 1;
                    imageDeath1.SetActive(false);
                }
                else if (DeathCount == 2)
                {
                    firstCard.DestroyCard();
                    secondCard.DestroyCard();
                    DeathCount -= 2;
                    imageDeath1.SetActive(false);
                    imageDeath2.SetActive(false);
                }
            }

        }

        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            DeathCount++;
            if (DeathCount == 1)
            {
                imageDeath1.SetActive(true);
                firstCard = null;
                secondCard = null;
            }
            if (DeathCount == 2)
            {
                imageDeath2.SetActive(true);
                firstCard = null;
                secondCard = null;
            }
            if (DeathCount == 3)
            {
                imageDeath3.SetActive(true);
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
            }
        }
        firstCard = null;
        secondCard = null;
    }
}
