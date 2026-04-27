using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    // T‰h‰n linkitet‰‰n inspectorissa yksi tabletin painikkeista
    [Header("UI")]
    [SerializeField] private GameObject beginButton;

    // T‰h‰n linkitet‰‰n inspectorissa audio source ja ‰‰niefekti
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    // Jos painiketta klikataan, kutsutaan t‰t‰ metodia
    public void AnswerBegin()
    {
        Debug.Log("Button clicked");
        // Kutsutaan HandleAnswer-metodia
        HandleAnswer(true);
        Debug.Log("After HandleAnswer");
    }

    private void HandleAnswer(bool playerAnswer)
    {
        // Soitetaan ‰‰niefekti kerran audio sourcessa
        audioSource.PlayOneShot(clickSound);
        Debug.Log("Sound effect played");
    }
}
