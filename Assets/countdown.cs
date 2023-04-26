using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class countdown : MonoBehaviour
{
    public float countdownTime = 3.0f; // The initial countdown time
    public TMP_Text countdownText; // The Text component to display the countdown
    private float currentTime; // The current countdown time

    private void Awake()
    {
        currentTime = countdownTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            // Load the new scene when the countdown reaches zero
            SceneManager.LoadScene(3);
        }

        // Round the current time to an integer and display it in the Text component
        countdownText.text = Mathf.CeilToInt(currentTime).ToString();
    }
}
