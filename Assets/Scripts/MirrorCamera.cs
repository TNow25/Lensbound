using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform mirrorPortal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - mirrorPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;


        float angularDifferenceBetweenPortalsRotations = Quaternion.Angle(portal.rotation, mirrorPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalsRotations, Vector3.down);
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
