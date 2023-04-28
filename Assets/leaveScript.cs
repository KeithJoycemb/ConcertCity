using UnityEngine;
using UnityEngine.SceneManagement;

public class leaveScript : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("help im scared");
            SceneManager.LoadScene(0);
        }
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;

        if (isPaused)
        {
            text.text = "press 'L' For main menu";
            AudioListener.pause = true; // Pause audio
         
        }
        else
        {
            text.text = "";
            AudioListener.pause = false; // Unpause audio
        }
        
    }
}
