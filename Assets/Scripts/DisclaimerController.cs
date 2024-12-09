using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisclaimerController : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject quitButton;
    public float delay = 5f; // 5 seconds delay

    private float timer;

    void Start()
    {
        // Hide the buttons at the start
        continueButton.SetActive(false);
        quitButton.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay && continueButton.activeSelf == false)
        {
            // Show the buttons after 5 seconds
            continueButton.SetActive(true);
            quitButton.SetActive(true);
        }
    }

    public void OnContinueButtonPressed()
    {
        SceneManager.LoadScene("1stPuzzle");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
