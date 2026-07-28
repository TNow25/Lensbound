using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldCopyOff : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject worldCopy;

    public GameObject player;

    // Update is called once per frame

        public void OnTriggerEnter(Collider other)
        {
            //Debug.Log("Object entered trigger: " + other.gameObject.name);
            // Do something when an object enters the trigger
            //inTrigger = true;

            //if(other.tag = )
            Debug.Log("Enetered trigger");

            if(other.CompareTag("Player"))
            {
                if (worldCopy.activeInHierarchy == true)
                {
                    worldCopy.SetActive(false);
                }
            }


            //if (worldCopy.activeInHierarchy == true)
            //{
            //    worldCopy.SetActive(false);
            //}

        }

        public void OnTriggerStay(Collider other)
        {
        //Debug.Log(other);
            if (other.CompareTag("Player"))
            {
                if (worldCopy.activeInHierarchy == true)
                {
                    worldCopy.SetActive(false);
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
        //Debug.Log("Object exited trigger: " + other.gameObject.name);
        // Do something when an object exits the trigger
        //inTrigger = false;
            if (other.CompareTag("Player"))
            {
                if (worldCopy.activeInHierarchy == false)
                {
                    worldCopy.SetActive(true);
                }
            }

            //else if (worldCopy.activeInHierarchy == false)
            //{
            //    worldCopy.SetActive(true);
            //}
            //worldCopy.SetActive(true);

        }
    
}
