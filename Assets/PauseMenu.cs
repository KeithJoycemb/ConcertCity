using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    private TMPro.TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;

        if (isPaused)
        {
            text.text = "PAUSED";
            AudioListener.pause = true; // Pause audio
        }
        else
        {
            text.text = "";
            AudioListener.pause = false; // Unpause audio
        }
    }
}
