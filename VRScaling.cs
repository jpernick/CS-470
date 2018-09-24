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

    //tracks the movement of the left controller
    private SteamVR_Controller.Device controllerLeft
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedobj.index);
        }
    }
    //tracks the movement of the right controller
    private SteamVR_Controller.Device controllerRight
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedobj2.index);
        }
    }

    public GameObject molecule;


    public bool sideButtonPushed = false;

    //figures out which is the left controller and which is the right controller
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
        //Test to see if the button is pressed down on the left controller
        if (leftDevice.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            //get the x and the y position of the molecule
            int xVal = molecule.transform.position.x;
            int yVal = molecule.transform.position.y;

            //IF the left grip button is pressed scale the molecule down one
            molecule.transform.localScale += new Vector3(xVal, -1, yVal);
        }
        //Test to see if the button is pressed down on the right controller
        if (rightDevice.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            //get the x and the y position of the molecule
            int xVal = molecule.transform.position.x;
            int yVal = molecule.transform.position.y;

            //IF the right grip button is pressed scale the molecule up one
            molecule.transform.localScale += new Vector3(xVal, 1, yVal);


        }
    }
}