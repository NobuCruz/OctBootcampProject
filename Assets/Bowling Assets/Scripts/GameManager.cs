using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;


    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private Pin[] pins;

    [SerializeField]
    private Camera mainCam, closeUpCam;

    private bool isGamePlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        closeUpCam.enabled = false;
        StartGame();
    }


    public void StartGame()
    {
        isGamePlaying = true;

        //Get first throw
        playerController.StartThrow();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isGamePLaying == false && Input.GetKeyUp(KeyCode.X))
        //{
        //    StartGame();
        //}
    }

    public void SetNextThrow()
    {

        Invoke(nameof(NextThrow), 3.0f);
        
    }

    void NextThrow()
    {

        int fallenPins = CalculateFallenPins();
        scoreManager.setFrameScore(fallenPins);

        if(scoreManager.currentFrame == 0)
        {
            //Debug.Log($"Game over {scoreManager.CalculateTotalScore()}");
            uiManager.ShowGameOver(scoreManager.CalculateTotalScore());
            return;
        }
        //calculate frame total for UI
        int frameTotal = 0;
        for(int i = 0; i < scoreManager.currentFrame-1;i++) 
        {
            frameTotal += scoreManager.GetFrameScore()[i];
            uiManager.SetFrameTotal(i, frameTotal);
        }
        //switch back to Main cam
        SwitchCam();

               //else
            //{
            //    Debug.Log($"Frame: {scoreManager.currentFrame}, Throw: {scoreManager.currentThrow}");
            //    scoreManager.setFrameScore(CalculateFallenPins());
            //    Debug.Log($"current Score: {scoreManager.CalculateTotalScore()}");


            //Get the ball to the start position for throwing
            playerController.StartThrow();
        }

        //Switch Back to Main camera
        
    public int CalculateFallenPins()
    {
        int count = 0;
        foreach (Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;
                pin.gameObject.SetActive(false);
            }
        }

        Debug.Log("Total Fallen Pins " + count);
        return count;
    }

    public void ResetAllPins()
    {
        foreach (Pin pin in pins)
        {
            pin.ResetPin();
        }
    }

    public void SwitchCam()
    {
        mainCam.enabled = !mainCam.enabled;
        closeUpCam.enabled = !closeUpCam.enabled;
        //SwitchCam();
    }

    
}
