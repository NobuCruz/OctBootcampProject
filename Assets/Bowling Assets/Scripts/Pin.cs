using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isFallen;
    public float pinFall = 5f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private Rigidbody pinRB;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        pinRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if pin has fallen
        isFallen = Quaternion.Angle(startRotation, transform.localRotation) > pinFall;
    }


    public void ResetPin()
    {
        pinRB.velocity = Vector3.zero;
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
