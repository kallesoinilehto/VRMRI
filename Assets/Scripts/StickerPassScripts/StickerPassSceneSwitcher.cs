using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //the scene to be loaded. Used by buttons on the pass.
    [SerializeField] private string NextScene;

    //switches the scene, as simple as that.
    public void SwitchTheScene()
    {
        SceneManager.LoadScene(NextScene);
    }

}
