﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ===============================
// AUTHOR: Joe Pernick
// DATE: 24 September, 2018
// PURPOSE: VRScaling on the right controller that allows the molecules to be scaled up 
// ===============================

public class VRScalingRight : MonoBehaviour
{


    public SteamVR_TrackedObject trackedobj;
    

    //tracks the movement of the left controller
    private SteamVR_Controller.Device controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedobj.index);
        }
    }
   

    public GameObject molecule;


    public bool gripButtonPushed = false;


    void Start()
    {


        //if the molecule cannot be retrieved by setting it in the Unity Editor, look for it.
        if (molecule == null)
        {
            molecule = GameObject.FindGameObjectWithTag("Mol");
        }

        trackedobj = GetComponent<SteamVR_TrackedObject>();
        // Debug.Log(trackedobj.index);

    }

    void Update()
    {
        //Test to see if the button is pressed down on the left controller
        if (controller.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            //get the x and the y position of the molecule
            float xVal = molecule.transform.position.x;
            float yVal = molecule.transform.position.y;

            //IF the right grip button is pressed scale the molecule up by 1
            molecule.transform.localScale += new Vector3(xVal, 1.0f, yVal);
            gripButtonPushed = true;
            //Debug.Log(gripButtonPushed);
        }

    }
}