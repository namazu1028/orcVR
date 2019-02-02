using UnityEngine;
using Valve.VR;

public class PlayerController : MonoBehaviour
{

    public SteamVR_Input_Sources hand;
    public SteamVR_Action_Boolean grabAction;

    public GameObject cameraRig;
    public GameObject controllerR;

    private Vector3 cameraRigStartPosition;
    private Vector3 controllerRStartPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (grabAction.GetStateDown(hand))
        {
            controllerRStartPosition = controllerR.transform.localPosition;
            cameraRigStartPosition = cameraRig.transform.position;
            Debug.Log(controllerRStartPosition);
            Debug.Log("GrabDown!");
        }
        if (grabAction.GetState(hand) && !grabAction.GetStateDown(hand))
        {
            var diff = controllerR.transform.localPosition - controllerRStartPosition;
            Debug.Log(diff);
            // diff = new Vector3(0, -0.1f, 0);
            cameraRig.transform.position = -diff + cameraRigStartPosition;
        }
        if (grabAction.GetStateUp(hand))
        {
            Debug.Log("GrabUp!");
        }
    }
}