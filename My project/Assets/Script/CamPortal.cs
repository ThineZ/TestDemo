using UnityEngine;

public class CamPortal : MonoBehaviour
{
    [Header("Player Camera")]
    public Transform MainCam;
    public Transform CameraTwo;
    public Transform PlayerObject;

    //[Header("Portals")]
    //public Transform Portal;
    //public Transform OtherPortal;

    [SerializeField] private bool isTracking = false;

    public Vector3 CurrentPlayerCamPos;
    public Vector3 CurrentCameraTwoPos;

    void CamRotatioFollow()
    {
        //Get the rotation of the 2nd Camera to follow the Main Camera
        float angularDiff = Quaternion.Angle(MainCam.rotation, PlayerObject.rotation);
        Quaternion portalRotationDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        Vector3 newCamDirection = portalRotationDiff * MainCam.forward;

        CameraTwo.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);
    }

    void CamFollow()
    {
        // Get the Player Camera Movement and mimics that action
        CurrentPlayerCamPos = PlayerObject.position;
        CurrentCameraTwoPos = CameraTwo.position;

        //To Find the the value different of position x,y,z then use this value to add in to player cam pos to desire camera two position
        Vector3 offsetValue = new Vector3 (CurrentPlayerCamPos.x - CurrentCameraTwoPos.x, 
                                           CurrentPlayerCamPos.y - CurrentCameraTwoPos.y, 
                                           CurrentPlayerCamPos.z - CurrentCameraTwoPos.z);

        Vector3 appliedOffset = new Vector3(CurrentPlayerCamPos.x - offsetValue.x,
                                            CurrentPlayerCamPos.y - offsetValue.y,
                                            CurrentPlayerCamPos.z - offsetValue.z);

        // Apply the "offsetPos to the Camera Two
        CameraTwo.position = new Vector3 (appliedOffset.x, appliedOffset.y, appliedOffset.z);

        Debug.Log("Current Camera Two Pos " + CameraTwo.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "TargetedSpaces")
        {
            isTracking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TargetedSpaces")
        {
            isTracking = false;
        }
    }

    private void Update()
    {
        if (isTracking)
        {
            CamFollow();
            CamRotatioFollow();
            Debug.Log("Camera Two Started Tracking");
        }
        else if (isTracking == false)
        {
            Debug.Log("Camera Two Stoped Tracking");
        }
    }
}
