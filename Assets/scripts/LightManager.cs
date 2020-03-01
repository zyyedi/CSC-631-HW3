using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Light sunShine;
    private bool lightToggle = true;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            Debug.Log("the i button is pressed");
            if(lightToggle)
            {
                sunShine.intensity = 0.1f;
                lightToggle = false;
            }
            else
            {
                sunShine.intensity = 1f;
                lightToggle = true;
            }
            
        }
    }
}
