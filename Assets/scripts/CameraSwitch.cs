﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam1;
    public GameObject cam2;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1cam"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        if (Input.GetButtonDown("2cam"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
