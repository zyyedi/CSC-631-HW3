using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    public float forwardForce = 30f;
    public float lateralForce = 30f;
    public float upwardForce = 30f;
    public float speedLimit = 10f;
    public float stopForce = .10f;

    public bool jumpEligible = true;
    public int jumpFC = 0;
    public int maxJumpF = 10;

    private Vector3 lateralVector;
    private Vector3 forwardVector;
    private Vector3 upwardVector;
    

    private bool movement = false;


    void Start()
    {
        lateralVector = new Vector3(lateralForce * Time.deltaTime, 0, 0);
        forwardVector = new Vector3(0, 0, forwardForce * Time.deltaTime);
        upwardVector = new Vector3(0, upwardForce * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // move the player in the forward direction
        // playerRB.AddForce(forwardVector, ForceMode.VelocityChange);

        // move the player left and right onscreen
        //Debug.Log("player velocity: " + playerRB.velocity.magnitude);

        if (Input.GetKey("w"))
        {
            playerRB.AddForce(forwardVector, ForceMode.VelocityChange);
            movement = true;
        }

        if (Input.GetKey("a"))
        {
            playerRB.AddForce(-lateralVector, ForceMode.VelocityChange);
            movement = true;
            
        }

        if (Input.GetKey("s"))
        {
            playerRB.AddForce(-forwardVector, ForceMode.VelocityChange);
            movement = true;
          
        }

        if (Input.GetKey("d"))
        {
            playerRB.AddForce(lateralVector, ForceMode.VelocityChange);
            movement = true;
         
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpEligible)
            {
                playerRB.AddForce(upwardVector, ForceMode.VelocityChange);

                if (jumpFC < maxJumpF)
                {
                    jumpFC++;
                }
                else
                {
                    jumpEligible = false;
                }

            }
        }

        if(!movement)
        {
            if (playerRB.velocity.magnitude >= 0)
            {
                playerRB.AddForce(playerRB.velocity.normalized * -stopForce, ForceMode.VelocityChange);
            }
        }
        
        if(playerRB.velocity.magnitude > speedLimit)
        {

            float deltaSpeed = (playerRB.velocity.magnitude - speedLimit);
            Debug.Log("Speeding delta" + deltaSpeed);
            playerRB.AddForce(playerRB.velocity.normalized * -deltaSpeed, ForceMode.VelocityChange);
        }


        movement = false;
    }
}
