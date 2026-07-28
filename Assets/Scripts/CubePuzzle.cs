using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePuzzle : MonoBehaviour
{
    public GameObject puzzleCompleteObject;
    //public GameObject puzzle2CompleteObject;
    public GameObject puzzleCube;

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Object entered trigger: " + other.CompareTag("CubePuzzleObject"));
        // Do something when an object enters the trigger

        //if(other.tag = )
        if(other.gameObject == puzzleCube)
        {
            puzzleCompleteObject.SetActive(false);
        }
        //puzzleCompleteObject.SetActive(false);
        //if(other.gameObject == puzzle2CompleteObject)
        //{
        //    puzzle2CompleteObject.SetActive(false);
        //}
    }

    public void OnTriggerStay(Collider other)
    {
        // Do something every frame that an object is inside the trigger
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited trigger: " + other.gameObject.name);
        // Do something when an object exits the trigger

    }
}
