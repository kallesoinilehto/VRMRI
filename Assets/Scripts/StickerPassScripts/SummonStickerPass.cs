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
    private bool firsttime = false;
    public Vector3 holderoffset = new Vector3(0,0,0);
    public Quaternion holderrotation = new Quaternion(0, 0, 0, 0);
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
        if (scene.name != "Lobby")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        string scene = SceneManager.GetActiveScene().name;
        //since the pass is initialized in the lobby, it must give the sticker only on the second enable.
        if (firsttime == true)
        {
            Debug.Log("passed");
            //switch-case, gives the sticker corresponding to the active scene.
            switch (scene)
            {
                case "Hallway":
                    gameObject.GetComponent<StickerGiver>().GiveSticker("HallwaySticker"); break;
                case "cannulation_room":
                    gameObject.GetComponent<StickerGiver>().GiveSticker("CannulationSticker"); break;
                case "MRI_Room1":
                    gameObject.GetComponent<StickerGiver>().GiveSticker("BeforeMRISticker"); break;
                case "MRI_Room6":
                    gameObject.GetComponent<StickerGiver>().GiveSticker("AfterMRISticker"); break;
                case "MRI_Room_Sorting_Game":
                    gameObject.GetComponent<StickerGiver>().GiveSticker("SortingGameSticker"); break;
                case "MRI_Room2":
                    gameObject.GetComponent<StickerGiver>().GiveSticker("QNASticker"); break;
                case "Quiz":
                    gameObject.GetComponent<StickerGiver>().GiveSticker("QuizSticker"); break;

                default:
                    Debug.Log("Incorrect scene name");
                    break;
            }
        }
        else
        {
            Debug.Log("not passed");
            firsttime = true;
        }
    }

    public void PlaySound()
    {
        //do later: add sound to summoning the pass
    }

    //this controls the movement of the sticker pass. it follows your camera and always stays in front.
    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            //GameObject passholder = GameObject.FindGameObjectWithTag("PassHolder");
            //transform.position = passholder.transform.position + holderoffset;
            transform.position = holderoffset;
            transform.rotation = holderrotation;
        }
        else
        {
            Vector3 targetPosition = mainCamera.position + mainCamera.TransformDirection(offset);
            Quaternion targetRotation = mainCamera.rotation;

            transform.position = Vector3.SmoothDamp(
                transform.position, targetPosition, ref velocity, positionSmoothTime);

            transform.rotation = Quaternion.Slerp(
                transform.rotation, targetRotation, rotationSmoothSpeed * Time.deltaTime);
        }
    }

    //activates when a new scene is loaded.
    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
