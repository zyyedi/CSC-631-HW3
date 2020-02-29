
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public Rigidbody obstacleRB;
    public float forwardForce = 10f;
    private Vector3 forwardVector;


    void Start()
    {
        forwardVector = new Vector3(0, 0, forwardForce * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        obstacleRB.AddForce(-forwardVector, ForceMode.VelocityChange);
    }
}

