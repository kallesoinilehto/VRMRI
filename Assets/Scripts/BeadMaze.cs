using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadMaze : MonoBehaviour
{
    public Light feedbackLight;

    void Start()
    {
        feedbackLight.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        feedbackLight.enabled = true;
        
        if (other.gameObject.tag == "bead")
        {
            feedbackLight.color = Color.red;
            Debug.Log("Collision");
        }
    }
}
