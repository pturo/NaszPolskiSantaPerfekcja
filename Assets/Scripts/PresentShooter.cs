using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PresentShooter : MonoBehaviour
{
    public GameObject present;
    public Text presentCounter;
    public float presentThrowingSpeed = 10f;
    public int amount = 0;
    // Start is called before the first frame update
    void Start()
    {
        CountPresents();
    }

    // Update is called once per frame
    void Update()
    {
        shootPresent();
    }

    public void shootPresent()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire") && amount > 0)
        {
            GameObject instPresent = Instantiate(present, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instPresentRigidbody = instPresent.GetComponent<Rigidbody>();
            instPresentRigidbody.AddForce(Vector3.forward * presentThrowingSpeed);
            amount--;
            CountPresents();
        }
    }

    public void CountPresents()
    {
        presentCounter = GameObject.Find("PresentAmount").GetComponent<Text>();
        presentCounter.text = "Ilość prezentów: " + amount + "/5";
        if (amount == 0)
        {
            presentCounter.text = "Nie masz już amunicji!";
        }
    }
}
