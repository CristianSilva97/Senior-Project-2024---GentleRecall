using UnityEngine;
using UnityEngine.UI; // For Buttons and RawImage
using UnityEngine.SceneManagement;
using TMPro; // For TextMeshPro elements

public class WhoIsThisController : MonoBehaviour
{
    [Header("Upload Phase")]
    public Button uploadButton;
    public RawImage previewImage;
    public Button confirmButton;

    [Header("Question Phase")]
    public GameObject questionPanel;
    public TMP_Text questionText;
    public Button[] answerButtons;

    [Header("Message Phase")]
    public GameObject messagePanel;
    public TMP_Text happyMessageText;
    public Button continueButton;

    [Header("Navigation")]
    public string finalSceneName = "FinalScene";

    public int correctAnswerIndex = 0; // The index of the correct answer

    void Start()
    {
        // Initial State: Show upload UI, hide question and message panels
        questionPanel.SetActive(false);
        messagePanel.SetActive(false);

        uploadButton.onClick.AddListener(UploadPlaceholderImage);
        confirmButton.onClick.AddListener(ShowQuestion);
        continueButton.onClick.AddListener(GoToFinalScene);

        // Setup answer buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int indexCopy = i;
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(indexCopy == correctAnswerIndex));
        }
    }

    void UploadPlaceholderImage()
    {
        // Simulate loading a placeholder image if desired
        // previewImage.texture = somePlaceholderTexture;
        // This is optional as maybe the RawImage already has a placeholder assigned
    }

    void ShowQuestion()
    {
        // Hide upload and confirm UI
        uploadButton.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(false);

        // Show the question UI
        questionPanel.SetActive(true);
        questionText.text = "Who is this person?";
        ResetAnswers(); // Ensure all answers are interactable
    }

    void OnAnswerSelected(bool isCorrect)
    {
        if (isCorrect)
        {
            // Correct answer
            questionPanel.SetActive(false);
            happyMessageText.text = "They say: 'I love you and I'm proud of your progress!'";
            messagePanel.SetActive(true);
        }
        else
        {
            // Incorrect answer
            // Just update the question text and keep the question panel visible
            messagePanel.SetActive(false);
            questionText.text = "Try again!";
            questionPanel.SetActive(true);
            ResetAnswers();
        }
    }

    void ResetAnswers()
    {
        // Re-enable all answer buttons so the player can try again
        foreach (Button btn in answerButtons)
        {
            btn.interactable = true;
        }
    }

    void GoToFinalScene()
    {
        SceneManager.LoadScene(finalSceneName);
    }
}
