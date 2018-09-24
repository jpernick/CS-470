using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ===============================
// AUTHOR: Joe Pernick
// DATE: 24 September, 2018
// PURPOSE: VRScaling allows the molecules to be scaled up or down
// ===============================

public class VRScaling : MonoBehaviour
{


    public SteamVR_TrackedObject trackedobj;
    public SteamVR_TrackedObject trackedobj2;


    private SteamVR_Controller.Device controllerLeft
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedobj.index);
        }
    }
    private SteamVR_Controller.Device controllerRight
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedobj2.index);
        }
    }

    public GameObject molecule;


    public bool sideButtonPushed = false;

    int rightIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
    int leftIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);

    private SteamVR_Controller.Device rightDevice = SteamVR_Controller.Input(rightIndex);
    private SteamVR_Controller.Device leftDevice = SteamVR_Controller.Input(leftIndex);


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
        //Test to see if the button is pressed down on both controllers
        if ((leftDevice.GetPress(SteamVR_Controller.ButtonMask.Grip)) && (rightDevice.GetPress(SteamVR_Controller.ButtonMask.Grip)))
        {
            //get the x and the y position of the molecule
            int xVal = molecule.transform.position.x;
            int yVal = molecule.transform.position.y;

            //scalle the molecule up by one
            molecule.transform.localScale += new Vector3(xVal, 1, yVal);
        }


    }
}