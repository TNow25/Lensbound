using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
    public Transform RayPoint;

    public GameObject objectToRemove;
    public GameObject objectToAdd;
    public GameObject lens;

    //public GameObject player;

    TriggerDetection triggerDetection;
    TriggerDetection wallTrigger;
    [SerializeField] GameObject trigger;
    public Camera cam;
    private float distance = 10f;
    private string targetTag = "DisappearingObject";
    private string ignoreTag = "IgnoreTag";
    private string wallTag = "DisappearingWall";
    private string endWallTag = "End Wall";

    public LayerMask ignoreLayer;
    //public LayerMask cameraLayer;
    Player player;
    [SerializeField]
    //private LayerMask mask;

    private void Start()
    {
        triggerDetection = trigger.GetComponent<TriggerDetection>();
        player = GetComponent<Player>();
        wallTrigger = trigger.GetComponent<TriggerDetection>();
        //cam = GetComponent<Camera>;
    }

    // Update is called once per frame
    void Update()
    {
        raycast();
    }

    public void raycast()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, ~ignoreLayer))
        {
            //Debug.Log("Hit: " + hit.collider.tag);

            //Code for end puzzle. Perspective puzzle where object disappears and makes other object active
            if (hit.collider.CompareTag(targetTag) && lens.activeInHierarchy == true && triggerDetection.inTrigger == true)
            {
                //probably best to not include the need for clicking with this puzzle

                //if (Input.GetKeyDown(KeyCode.Mouse0))
                //{
                    Debug.Log("Object Gone");
                    hit.collider.gameObject.SetActive(false);
                    //objectToRemove.SetActive(false);
                    objectToAdd.SetActive(true);
                //}
            }

            //used for walls. Makes walls disappear
            if(hit.collider.CompareTag(wallTag) && lens.activeInHierarchy == true && player.isTriggered == true)
            {
                //only disappear when clicked. Like taking a photo
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }


            //used for final wall to take player to finish screen
            if (hit.collider.CompareTag(endWallTag) && lens.activeInHierarchy == true && player.isTriggered == true)
            {
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;  
                }
            }

        }           





        //    if(hit.collider.CompareTag(ignoreTag))
        //    {
        //        Debug.Log("Ignore Layer");
        //    }

        //    if(hit.collider.CompareTag(targetTag))
        //    {
        //        Debug.Log(targetTag);

        //        if(lens.activeInHierarchy == true)
        //        {
        //            Debug.Log("Lense active");
                    
        //            if(triggerDetection.inTrigger == true)
        //            {
        //                Debug.Log("True");
        //            }
        //        }
        //    }

        //}

        /*
        if (Physics.Raycast(RayPoint.position, transform.TransformDirection(RayPoint.transform.forward), out hit, 10000))
        {
            Debug.DrawRay(RayPoint.position, transform.TransformDirection(RayPoint.transform.forward) * hit.distance, Color.yellow);

            if (hit.transform.name == "DisappearingObject" && lens.activeInHierarchy == true && triggerDetection.inTrigger == true)
            {
                objectToRemove.SetActive(false);
                objectToAdd.SetActive(true);
            }

        }
        */





        //if(hit.transform.tag.Equals("DisappearingObject") && lense.activeInHierarchy == true)
        //{
        //    objectToRemove.SetActive(false);
        //}
        //if (hit.transform.name == "DisappearingObject" && lense.activeInHierarchy == true)
        //{
        //    objectToRemove.SetActive(false);
        //}
    }




public void hitChangingObject()
    {
        if (objectToRemove != null && lens.activeInHierarchy == true)
        {
            objectToRemove.SetActive(false);

            objectToAdd.SetActive(true);
        }
    }

}
