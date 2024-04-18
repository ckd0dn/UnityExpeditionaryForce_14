using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform UICanvus;

    public Animator anim;

    public Card firstCard;
    public Card secondCard;

    public GameObject endTxt;
    public Text timeTxt;
    

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    public int DeathCount;
    public GameObject imageDeath1;
    public GameObject imageDeath2;
    public GameObject imageDeath3;

    public GameObject plusTxt;
    public GameObject minusTxt;
    Vector2 createPoint;

    float time = 30.0f;

    public List<Card> cardList = new List<Card>();

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
            if(cardCount > 0)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
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

    public void Clear()
    {
        Time.timeScale = 0.0f;
        endTxt.SetActive(true);
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            cardList.Remove(firstCard);
            cardList.Remove(secondCard);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            time += 3f;
            PlusTime();

            if (cardCount == 0)
            {
                Invoke("Clear", 0.5f);
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
            time -= 1f;
            MinusTime();

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

    public void Hint()
    {
        int r = Random.Range(0, cardList.Count);

        for (int i = 0; i < cardList.Count; i++)
        {
            if (r != i)
            {
                if (cardList[r].idx == cardList[i].idx)
                {
                    cardList[r].backImage.color = Color.yellow;
                    cardList[i].backImage.color = Color.yellow;
                }
            }
        }
    }

    public void PlusTime()
    {
        GameObject go = Instantiate(plusTxt, plusTxt.transform.position, plusTxt.transform.rotation, UICanvus);
        Destroy(go, 0.5f);
    }
    
    public void MinusTime()
    {
        GameObject go = Instantiate(minusTxt, minusTxt.transform.position, minusTxt.transform.rotation, UICanvus);
        Destroy(go, 0.5f);

    }
}
