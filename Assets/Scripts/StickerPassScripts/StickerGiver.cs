using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerGiver : MonoBehaviour
{
    //list of stickers
    [SerializeField] GameObject hallwaySticker;
    [SerializeField] GameObject cannulationSticker;
    [SerializeField] GameObject beforeMRISticker;
    [SerializeField] GameObject afterMRISticker;
    [SerializeField] GameObject sortingGameSticker;
    [SerializeField] GameObject QNASticker;
    [SerializeField] GameObject quizSticker;
    void Start()
    {
        
    }

    //sets the stickers active, can be called from foreign objects. May add more stickers.
    public void GiveSticker(string sticker)
    {
        switch (sticker)
        {
            case "HallwaySticker":
                hallwaySticker.SetActive(true);
                hallwaySticker.GetComponent<StickerAnimationScript>().GiveSticker("Lobby", true);
                break;

            case "CannulationSticker":
                cannulationSticker.SetActive(true);
                cannulationSticker.GetComponent<StickerAnimationScript>().GiveSticker("Hallway 2", true);
                break;

            case "BeforeMRISticker":
                beforeMRISticker.SetActive(true);
                beforeMRISticker.GetComponent<StickerAnimationScript>().GiveSticker("MRI_Room3", true);
                break;

            case "AfterMRISticker":
                afterMRISticker.SetActive(true);
                afterMRISticker.GetComponent<StickerAnimationScript>().GiveSticker("End", true);
                break;

            case "SortingGameSticker":
                sortingGameSticker.SetActive(true);
                sortingGameSticker.GetComponent<StickerAnimationScript>().GiveSticker("Lobby", true);
                break;

            case "QNASticker":
                QNASticker.SetActive(true); 
                QNASticker.GetComponent<StickerAnimationScript>().GiveSticker("Lobby", true);
                break;

            case "QuizSticker":
                quizSticker.SetActive(true);
                quizSticker.GetComponent<StickerAnimationScript>().GiveSticker("Lobby", false);
                break;


            default:
                Debug.Log("Incorrect string in GiveSticker");
                break;
        }
    }
}
