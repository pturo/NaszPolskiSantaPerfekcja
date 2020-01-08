using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentSpotChecker : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject present;

    private void Start()
    {
        present = GameObject.FindGameObjectWithTag("PresentSpot");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PresentSpot"))
        {
            collider.attachedRigidbody.isKinematic = true;
            displayWinPanel();
            Time.timeScale = 0f;
        }
    }

    private void displayWinPanel()
    {
        winPanel.SetActive(true);
    }
}
