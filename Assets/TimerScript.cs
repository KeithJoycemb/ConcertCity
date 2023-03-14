using UnityEngine;
using UnityEngine.UI;

public class blinkTimer : MonoBehaviour
{
    public float timerLength = 5f;
    private float timer;
    private bool timerActive;
    public Text timerText;
    TMPro.TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();

    }
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
            timerText.text = Mathf.Round(timer).ToString();

            if (timer <= 0f)
            {
                timerActive = false;
                timerText.enabled = false;
            }
        }
    }
}
