using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumberLeft : MonoBehaviour {

    public static int totalNumber;

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        totalNumber = 100;
	}

    // Update is called once per frame

    public void Update()
    {
        text.text = "Number: " + totalNumber;
        if(totalNumber <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void gameOver()
    {

    }
}
