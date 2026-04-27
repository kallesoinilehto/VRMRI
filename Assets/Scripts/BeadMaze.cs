using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadMaze : MonoBehaviour
{
    // t‰h‰n linkitet‰‰n inspectorissa helmipujotteluradan valo
    public Light feedbackLight;

    // alussa valo on pois p‰‰lt‰
    void Start()
    {
        feedbackLight.enabled = false;
    }

    // jos radan joku box collidereista tˆrm‰‰ yhteen helmen box collidereista, kutsutaan t‰t‰ metodia
    void OnTriggerEnter(Collider other)
    {
        // valo on nyt p‰‰ll‰
        feedbackLight.enabled = true;
        
        // helmen box collidereilla on tag "bead"
        if (other.gameObject.tag == "bead")
        {
            // kutsutaan LightOffWithDelay-korutiinia
            StartCoroutine(LightOffWithDelay(1f));
        }
    }

    IEnumerator LightOffWithDelay(float delay)
    {
        // valon v‰ri on nyt punainen
        feedbackLight.color = Color.red;
        Debug.Log("Collision");

        // annetun viiveen (1f, voi muuttaa) mittainen viive
        yield return new WaitForSeconds(delay);

        // valo on nyt pois p‰‰lt‰
        feedbackLight.enabled = false;
    }
}
