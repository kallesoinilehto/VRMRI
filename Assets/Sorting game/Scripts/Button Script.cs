using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonscript : MonoBehaviour
{
    public string nextSceneName = "MRI_Room2";

    void OnTriggerEnter(Collider other){

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
