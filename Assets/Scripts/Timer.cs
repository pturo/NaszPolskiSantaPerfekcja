using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeft = 60;
    public Text countdownText;
    public GameObject loseGamePanel;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = "Policaj Cię zamknie za: " + timeLeft.ToString() + " sek!";
        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Skończył się czas!";
            loseGamePanel.SetActive(true);
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
