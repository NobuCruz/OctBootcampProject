using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerMovementSpeed = 1.0f;
    public float arrowMinPosition = -0.5f;
    public float arrowMaxPosition = 0.5f;
    public Transform throwingArrow;
    public Transform ballSpawnPoint;
    public float throwForce = 5.0f;
    public Animator throwingArrowAnim;

    public Rigidbody[] balls;
   
    

    private float horizontalInput;
    private Vector3 ballOffset;
    private bool wasBallThrown;
    private float horizontalAxis;
    private Rigidbody selectedBall;

    // Start is called before the first frame update
    void Start()
    {
        ballOffset = ballSpawnPoint.position - throwingArrow.position;
        

        

    }

    public void StartThrow()
    {
        throwingArrowAnim.SetBool("Aiming", true);
        wasBallThrown = false;


        //Spawn A New Ball When Start Throw Is Called
        int randomNumber = GetRandomNumber(0, balls.Length);
        selectedBall = Instantiate(balls[randomNumber],ballSpawnPoint.position,Quaternion.identity);
    }


    private int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {

        MoveArrowWithConstraints();
        TryThrowBall();
    }

    private void MoveArrowWithoutConstraints()
    {
        //Moving without constraints
        horizontalInput = Input.GetAxis("Horizontal");
        throwingArrow.position += throwingArrow.transform.right * horizontalInput * playerMovementSpeed * Time.deltaTime;
    }

    private void MoveArrowWithConstraints()
    {
        //Checks if ball has not yet been thrown
        if (!wasBallThrown) //wasBallThrown == false
        {
            //Moving with constraints
        float movePosition = Input.GetAxis("Horizontal") * playerMovementSpeed * Time.deltaTime;
        throwingArrow.position = new Vector3(
            Mathf.Clamp(throwingArrow.position.x + movePosition, arrowMinPosition, arrowMaxPosition),
            throwingArrow.position.y,
            throwingArrow.position.z
            );
            //set Ball Position based on Throwing Direction Position
         // selectedBall.transform.position = throwingArrow.position + ballOffset;

        }


        
    }


    private void TryThrowBall()
    {
        //throw the ball
        if(Input.GetKeyDown(KeyCode.Space) && !wasBallThrown)
        {
            wasBallThrown = true;
           selectedBall.AddForce(throwingArrow.forward * throwForce, ForceMode.Impulse);
            throwingArrowAnim.SetBool("Aiming", false);
        }
    }

    public void ThrowBall()
    {
        if(!wasBallThrown)
        {
            wasBallThrown = true;
            selectedBall.AddForce(throwingArrow.forward * throwForce, ForceMode.Impulse);
            throwingArrowAnim.SetBool("Aiming", false);
        }
    }

    public void SetHorizontal (bool isleft)
    {
        if (isleft)
            horizontalAxis = -1;
        else
            horizontalAxis = 1;
    }


    public void ResetHorizontal()
    {
        horizontalAxis = 0;
    }
}
