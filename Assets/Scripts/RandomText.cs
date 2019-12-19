using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RandomText : MonoBehaviour
{
    public Text textObject;

    public void Start()
    {
        RandomTextDisplay();
    }
    public void RandomTextDisplay()
    {
        // Random texts
        string[] texts = new string[5];
        texts[0] = "No i czego się tak wystraszyłeś? Lalki Momo?";
        texts[1] = "Ho ho ho! Wesołych Świąt w pierdlu jak Cię złapią!";
        texts[2] = "Tylko tchórze się chowają za tą pauzą!";
        texts[3] = "Piękny skok w bok jak widać!";
        texts[4] = "Uwaga, polisja! Zapraszamy do więzienia! :)";

        UnityEngine.Random r = new UnityEngine.Random();

        string myString = texts[UnityEngine.Random.Range(0, texts.Length)];
        textObject.text = myString;
    }
}
