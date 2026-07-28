using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voidTrigger : MonoBehaviour
{

    public GameObject player;

    public GameObject endPuzzleCube;
    public GameObject endPuzzleCubeRespawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = new Vector3(-18.0f, 9.5f, -95.0f);
        }


        if(other.CompareTag("EndPuzzleCube"))
        {
            endPuzzleCube.transform.position = endPuzzleCubeRespawn.transform.position;
        }
    }
}
