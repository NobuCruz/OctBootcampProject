using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private Pin[] pins;

    private bool isGamePLaying = false;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }


    public void StartGame()
    {
        isGamePLaying = true;
        SetNextThrow();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePLaying == false && Input.GetKeyUp(KeyCode.X))
        {

        }
    }

    public void SetNextThrow()
    {
        CalculateFallenPins();
        //Get the ball to the start position for throwing
        playerController.StartThrow();
    }

    public void CalculateFallenPins()
    {
        int count = 0;
        foreach (Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;
            }
        }

        Debug.Log("Total Fallen Pins " + count);
    }
}
