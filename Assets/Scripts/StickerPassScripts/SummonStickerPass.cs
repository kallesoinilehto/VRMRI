using OVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SummonStickerPass : MonoBehaviour
{
    private Transform mainCamera;
    public Vector3 offset = new Vector3(0, 0, 1f);
    public float positionSmoothTime = 0.15f;
    public float rotationSmoothSpeed = 8f;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main.transform;
        }
        //saves the object to another object before deactivating the pass, so it can be activated in any scene.
        GameObject.FindGameObjectWithTag("passReference").GetComponent<ReferencePass>().SetPass(gameObject);
        gameObject.SetActive(false);
     
    }

    //turns off the pass when a new scene starts, also sets a new camera to follow.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mainCamera = Camera.main.transform;
        gameObject.SetActive(false);
    }

    public void PlaySound()
    {
        //do later: add sound to summoning the pass
    }

    //this controls the movement of the sticker pass. it follows your camera and always stays in front.
    void LateUpdate()
    {
        Vector3 targetPosition = mainCamera.position + mainCamera.TransformDirection(offset);
        Quaternion targetRotation = mainCamera.rotation;

        transform.position = Vector3.SmoothDamp(
            transform.position, targetPosition, ref velocity, positionSmoothTime);

        transform.rotation = Quaternion.Slerp(
            transform.rotation, targetRotation, rotationSmoothSpeed * Time.deltaTime);
    }

    //activates when a new scene is loaded.
    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
