using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Transform camera;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        // Vector3 playerPos = player.transform.position;
        // Vector3 playerDirection = player.transform.forward;
        // Quaternion playerRotation = player.transform.rotation;
        
        Vector3 cameraPos = player.transform.position;
        Quaternion cameraRotation = camera.transform.rotation;
        Vector3 cameraDirection = camera.transform.forward;
        float spawnDistance = 5;
 
        Vector3 spawnPos = cameraPos + cameraDirection*spawnDistance;
 
        // Instantiate(obstacle, new Vector3(element, 0, 100 + (waveDepth * waveDepthSpacing)), Quaternion.identity);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");
            GameObject bullet = Instantiate(projectile, spawnPos, cameraRotation);
            bullet.GetComponent<Rigidbody>().AddForce(cameraDirection * 2000);
        }
            
    
    }
}
