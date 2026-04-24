using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReferencePass : MonoBehaviour
{
    //sets the pass object to memory.
    GameObject stickerPass;
    public void SetPass(GameObject pass)
    {
        stickerPass = pass;
    }

    //returns the pass object
    public GameObject GetPass()
    {
        return stickerPass;
    }

    public void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Lobby")
        {
            stickerPass.SetActive(true);
        }
    }
}
