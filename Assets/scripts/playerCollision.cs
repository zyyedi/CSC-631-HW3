
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    private bool firstHit = true;

    void OnCollisionEnter(Collision info)
    {
        if(firstHit)
        {
            Debug.Log(info.collider.tag);
        }

        if(info.collider.tag == "obstacles")
        {
            Debug.Log("we hit an obstacle");

            movement.enabled = false;
        }


        if (info.collider.name == "Ground")
        {
            Debug.Log("resetting jump");
            movement.jumpEligible = true;
            movement.jumpFC = 0;
        }
    }
}
