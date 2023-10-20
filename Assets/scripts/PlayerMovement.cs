using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float sprint = 20.0f;
    public bool isSprintActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprintActive = true;
        }
        else
        {
            isSprintActive = false;
        }
        if (isSprintActive == true)
        {
            speed = sprint;
        }else if (isSprintActive == false)
        {
            speed = 10.0f;
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate (transform.forward * speed * Time.deltaTime); 
            
        }
        if(Input.GetKey(KeyCode.S)) 
        {
            transform.Translate (transform.forward * -1 * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)) 
        {
            transform.Translate (transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.Translate (transform.right * -1 * speed * Time.deltaTime);
        }
        
    }
}
