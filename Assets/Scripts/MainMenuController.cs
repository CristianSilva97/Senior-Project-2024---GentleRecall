using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        // Load the Disclaimer scene
        SceneManager.LoadScene("Disclaimer");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}

