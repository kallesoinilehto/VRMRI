using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuestionManager2 : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI returnText;
    [SerializeField] private GameObject yesButton;
    [SerializeField] private GameObject noButton;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip wrongClip;
    [SerializeField] private AudioClip fireworksClip;

    [Header("QuizData")]
    [TextArea]
    private string[] questions = {"Onnistuuko kuvaus, jos liikkuu?",
        "Pitääkö silmälasit jättää pois ennen kuvauksia?",
        "Jäädäänkö huoneeseen yksin?",
        "Saako kuvauksen aikana liikuttaa päätä?",
        "Pitääkö avaimet jättää pois ennen kuvauksia?",
        "Pitääkö silmien olla kiinni?",
        "Saako puhelimen ottaa kuvauksiin mukaan?",
        "Saako hengittää normaalisti?",
        "Saako hoitohenkilökuntaan yhteyden kuvauksen aikana?",
        "Tuleeko pimeää?" };
    private bool[] correctAnswers = { false, true, true, false, true, false, false, true, true, false };

    [Header("Settings")]
    [SerializeField] private float answerDelay = 1f;
    [SerializeField] private int countdownSeconds = 10;
    [SerializeField] private string returnSceneName = "Lobby";

    private int currentQuestionIndex = 0;
    private int score = 0;

    private void Start()
    {
        returnText.enabled = false;

        if (questions.Length != correctAnswers.Length)
        {
            Debug.LogError("Questions and CorrectAnswers arrays must be same length!");
            return;
        }

        DisplayQuestion();
    }

    public FireworksManager fireworksManager1;
    public FireworksManager fireworksManager2;
    public FireworksManager fireworksManager3;

    private void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];
            yesButton.SetActive(true);
            noButton.SetActive(true);
        }
        else
        {
            EndQuiz();
        }
    }
    public void AnswerYes()
    {
        HandleAnswer(true);
    }

    public void AnswerNo()
    {
        HandleAnswer(false);
    }

    private void HandleAnswer(bool playerAnswer)
    {
        if (currentQuestionIndex >= correctAnswers.Length)
        {
            return;
        }

        bool isCorrect = correctAnswers[currentQuestionIndex] == playerAnswer;

        if (isCorrect)
        {
            Debug.Log("isCorrect");
            score++;
            audioSource.PlayOneShot(correctClip);
            yesButton.SetActive(false);
            noButton.SetActive(false);
        }
        else
        {
            Debug.Log("isWrong");
            audioSource.PlayOneShot(wrongClip);
            yesButton.SetActive(false);
            noButton.SetActive(false);
        }

        StartCoroutine(NextQuestionAfterDelay());
    }

    private IEnumerator NextQuestionAfterDelay()
    {
        yield return new WaitForSeconds(answerDelay);
        currentQuestionIndex++;
        DisplayQuestion();
    }

    private void EndQuiz()
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);

        if (score > 5)
        {
            StartCoroutine(PlayFireworksWithDelay());
        }

        questionText.text = $"Vastasit {score}/{questions.Length} oikein!";
        returnText.enabled = true;

        StartCoroutine(ReturnCountdown());
    }

    private IEnumerator PlayFireworksWithDelay()
    {
        audioSource.PlayOneShot(fireworksClip);

        fireworksManager1.PlayFireworks();
        yield return new WaitForSeconds(0.5f);

        fireworksManager2.PlayFireworks();
        yield return new WaitForSeconds(0.5f);

        fireworksManager3.PlayFireworks();
    }

    private IEnumerator ReturnCountdown()
    {
        int timer = countdownSeconds;

        while (timer > 0)
        {
            returnText.text = $"Palataan huoneeseen {timer} sekunnin kuluttua...";
            yield return new WaitForSeconds(1f);
            timer--;
        }

        SceneManager.LoadScene(returnSceneName);
    }
}