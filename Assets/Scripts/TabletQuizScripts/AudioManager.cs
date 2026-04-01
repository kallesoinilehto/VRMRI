using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject beginButton;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    public void AnswerBegin()
    {
        Debug.Log("Button clicked");
        HandleAnswer(true);
        Debug.Log("After HandleAnswer");
    }

    private void HandleAnswer(bool playerAnswer)
    {
        audioSource.PlayOneShot(clickSound);
        Debug.Log("Sound effect played");
    }
}
