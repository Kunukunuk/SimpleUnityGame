using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour {

    public List<int> cardNum = new List<int>();
    public GameObject card;
    bool inital = true;
    bool player = true;

    private void Awake()
    {
        for(int i =0; i < 100; i++)
        {
            cardNum.Add(Random.Range(1, 16));
        }
    }
    public void click()
    {
        if (inital)
        {
            for(int i = 0; i < 6; i++)
            {
                draw();
            }
            inital = false;
        }
        else if (cardNum.Count != 0)
        {
            draw();
        }  
     
    }

    public void draw()
    {
        if (player)
        {
            CardNumber.number = cardNum[0];
            cardNum.RemoveAt(0);
            card = Instantiate(card, transform.position, transform.rotation);
            card.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
            player = false;
        }
        else if (!player)
        {
            CardNumber.number = cardNum[0];
            cardNum.RemoveAt(0);
            card = Instantiate(card, transform.position, transform.rotation);
            card.transform.SetParent(GameObject.FindGameObjectWithTag("Player1").transform);
            player = true;
        }
    }
}
