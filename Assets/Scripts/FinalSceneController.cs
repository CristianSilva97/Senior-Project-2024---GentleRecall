using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class FinalSceneController : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text finalMessageText;  // Assign in Inspector with your final message
    public Button mainMenuButton;
    public Button visitLinkButton;

    [Header("Navigation")]
    public string mainMenuSceneName = "MainMenu";  // Replace with your main menu scene name
    public string url = "http://example.com";       // Replace with your desired link
    public float delayBeforeButtons = 5f;           // 5 second delay

    void Start()
    {
        // Hide the buttons initially
        mainMenuButton.gameObject.SetActive(false);
        visitLinkButton.gameObject.SetActive(false);

        // Set button listeners
        mainMenuButton.onClick.AddListener(OnMainMenuPressed);
        visitLinkButton.onClick.AddListener(OnVisitLinkPressed);

        // Start the coroutine to show buttons after a delay
        StartCoroutine(ShowButtonsAfterDelay(delayBeforeButtons));
    }

    IEnumerator ShowButtonsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        mainMenuButton.gameObject.SetActive(true);
        visitLinkButton.gameObject.SetActive(true);
    }

    void OnMainMenuPressed()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    void OnVisitLinkPressed()
    {
        Application.OpenURL(url);
    }
}
