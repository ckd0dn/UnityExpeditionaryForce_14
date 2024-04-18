using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public Card card;
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7};
        
        arr = arr.OrderBy(x  => Random.Range(0f, 7f)).ToArray();

        GameManager.instance.cardList = new List<Card>();

        for (int i = 0; i < 16; i++) 
        {
            Card go = Instantiate(card, this.transform);

            GameManager.instance.cardList.Add(go);

            float space = 1.4f;

            float x = (i % 4) * space - 2.1f; // ¸ò
            float y = (i / 4) * space - 3.0f; // ³ª¸ÓÁö

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.instance.cardCount = arr.Length;
    }

}
