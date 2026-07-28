using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public bool inTrigger = false;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered trigger: " + other.gameObject.name);
        // Do something when an object enters the trigger
        inTrigger = true;

        //if(other.tag = )
    }

    public void OnTriggerStay(Collider other)
    {
        // Do something every frame that an object is inside the trigger
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited trigger: " + other.gameObject.name);
        // Do something when an object exits the trigger
        inTrigger = false;
    }
}
