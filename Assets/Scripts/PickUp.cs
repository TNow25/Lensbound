using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObject;
    private Rigidbody heldObjectRB;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;


    private void Update()
    {
        //mouse left click
        if(Input.GetMouseButton(0))
        {
            //no currently held object
            if(heldObject == null)
            {
                RaycastHit hit;
                //is object player is looking at able to be picked up? 
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }

            else
            {
                DropObject();
            }
        }

        if(heldObject != null)
        {
            MoveObject();
        }

    }


    void MoveObject()
    {
        //if object being held is outside of the holdArea position, move it back to the holdArea position
        if(Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = holdArea.position - heldObject.transform.position;
            heldObjectRB.AddForce(moveDirection * pickupForce);
        }
    }


    void PickupObject(GameObject pickObject)
    {
        //if object has a rigidbody component
        if(pickObject.GetComponent<Rigidbody>())
        {
            heldObjectRB = pickObject.GetComponent<Rigidbody>(); //set heldObject variable to the object player is interacting with
            heldObjectRB.useGravity = false; //object wont fall to ground
            heldObjectRB.drag = 10; //higher number, less movement when held
            heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation; //stop object from rotating. Keeps orientation of when player first picked up

            heldObjectRB.transform.parent = holdArea; //sets object position to the holdArea. 
            heldObject = pickObject;
        }
    }

    void DropObject()
    {
            heldObjectRB.useGravity = true;
            heldObjectRB.drag = 1;
            heldObjectRB.constraints = RigidbodyConstraints.None;

            heldObject.transform.parent = null;
            heldObject = null;
    }


}
