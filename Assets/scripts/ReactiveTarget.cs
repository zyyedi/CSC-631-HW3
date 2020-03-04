using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private float Speed = 50;
    public Transform scene1;

    public void ReactToHit(RaycastHit hit)
    {
        Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Jump(rb);
        }
    }

    private void Jump(Rigidbody rig)
    {
        rig.AddForce(scene1.up * Speed, ForceMode.Impulse);
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}