using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private float speed = 50;

    public void ReactToHit(RaycastHit hit)
    {
        Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            jump(rb);
        }
    }

    private void jump(Rigidbody rig)
    {
        rig.AddForce(rig.transform.up * speed, ForceMode.Impulse);
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