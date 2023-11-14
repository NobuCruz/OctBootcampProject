using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check for collision with any object
        //Debug.Log("ball has collided with" + collision.gameObject.name);



        if (collision.gameObject.CompareTag("Pin"))
        {
            Debug.Log("The objecrt we collided with is " + collision.gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pit"))
        {
            gameManager.SetNextThrow();
            
            //Destrow Ball GameObject
            Destroy(gameObject);
        }
        else if(other.CompareTag("closeUpCam"))
        {
            //change camera position
            gameManager.SwitchCam();
        }

        
    }
}
