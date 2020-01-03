using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PresentShooter : MonoBehaviour
{
    public GameObject present;
    public float presentThrowingSpeed = 10f;
    public int amount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
