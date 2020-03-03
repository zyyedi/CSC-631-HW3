using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private const float Speed = 50;

    public static void ReactToHit(RaycastHit hit)
    {
        Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Jump(rb);
        }
    }

    private static void Jump(Rigidbody rig)
    {
        rig.AddForce(rig.transform.up * Speed, ForceMode.Impulse);
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