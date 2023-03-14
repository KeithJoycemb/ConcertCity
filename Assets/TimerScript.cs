using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timerLength = 5f;
    private float timer;
    private bool timerActive;
    public TMP_Text timerText;

    void Start()
    {
        timerActive = false;
        timerText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !timerActive)
        {
            timerActive = true;
            timer = timerLength;
            timerText.enabled = true;
        }

        if (timerActive)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F2");

            if (timer <= 0f)
            {
                timerActive = false;
                timerText.enabled = false;
            }
        }
    }
}