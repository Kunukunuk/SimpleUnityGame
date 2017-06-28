using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardNumber : MonoBehaviour {

    public static int number;
    public int damage;
    Text text;
 
    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = "" + number;
        
    }

    public int getD()
    {
        return damage;
    }

}
