using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public int numberVariable; //Variable Declaration
    public bool isDoingSomething = false; //variable initialization
    public float speed = 10.0f;
    public string name = "Ot";

    public Transform cubeTransform;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        isDoingSomething=true; //variable Assignment
        Debug.Log("Hello world!");
        Debug.Log("The new variables are" + this);

        cubeTransform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The number variable is: " + numberVariable);
        if (5 > 3 || isDoingSomething == true)
        {
            cubeTransform.Rotate(Vector3.up * Time.deltaTime * speed); //rotate thing every second x=0, y=0, z=1 (with time*deltatime) at this speed (with * speed)
        }
        
    }
}
