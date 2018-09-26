using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ===============================
// AUTHOR: Michelle Mismas
// DATE: 24 September, 2018
// PURPOSE: VRScaleMolecule allows the user to scale the size of the Molecules
// 			using the grip on the left controller
// ===============================
public class VRScaleMolecule : MonoBehaviour {

    public SteamVR_TrackedObject trackedobj;

    public SteamVR_ControllerManager controllerManager;

    private SteamVR_Controller.Device leftController;
    private int leftIndex;
    private SteamVR_Controller.Device rightController;
    private int rightIndex;
    
    //private SteamVR_Controller.Device controller
    //{
    //    get
    //    {
    //        return SteamVR_Controller.Input((int)trackedobj.index);
    //    }
    //}

    //private SteamVR_Controller.Device secondaryController
    //{
    //    get
    //    {
    //        return SteamVR_Controller.Input((int)trackedobjL.index);
    //    }
    //}

    public GameObject molecule;

    public bool leftGripButtonDown = false;
    public bool rightGripButtonDown = false;

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    // Use this for initialization
    void Start () {

        //if the molecule cannot be retrieved by setting it in the Unity Editor, look for it.
        if (molecule == null)
        {
            molecule = GameObject.FindGameObjectWithTag("Mol");
        }

        trackedobj = GetComponent<SteamVR_TrackedObject>();
        controllerManager = GetComponent<SteamVR_ControllerManager>();

        leftIndex = (int)controllerManager.left.GetComponent<SteamVR_TrackedObject>().index;
        if(leftIndex != -1)
        {
            leftController = SteamVR_Controller.Input(leftIndex);
        }
        rightIndex = (int)controllerManager.right.GetComponent<SteamVR_TrackedObject>().index;
        if(rightIndex != -1)
        {
            rightController = SteamVR_Controller.Input(rightIndex);
        }
        // Debug.Log(trackedobj.index);

    }

    // Update is called once per frame
    void Update () {
        if (rightController.GetPress(gripButton))
        {
            molecule.transform.SetParent(this.transform);
            molecule.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (leftController.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            scaleSelected(molecule);
        }
    }

    void scaleSelected(GameObject selected)
    {
        Vector3 velocity = leftController.velocity;
        Vector3 newScale = Vector3.zero;

        float max = Mathf.Max(Mathf.Max(Mathf.Abs(velocity.x), Mathf.Abs(velocity.y)), Mathf.Abs(velocity.z));

        if (max == Mathf.Abs(velocity.x))
        {
            newScale = selected.transform.localScale + new Vector3(velocity.x, 0, 0);
        }
        else if (max == Mathf.Abs(velocity.y))
        {
            newScale = selected.transform.localScale + new Vector3(0, velocity.y, 0);
        }
        else if (max == Mathf.Abs(velocity.z))
        {
            newScale = selected.transform.localScale + new Vector3(0, 0, velocity.z);
        }

        selected.transform.localScale = Vector3.Lerp(selected.transform.localScale, newScale, Time.deltaTime);
    }
}
