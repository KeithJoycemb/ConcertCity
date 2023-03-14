using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float displayLength = 5f;
    private float displayTime;
    private bool imageActive;
    public Image displayImage;

    void Start()
    {
        imageActive = false;
        displayImage.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !imageActive)
        {
            imageActive = true;
            displayTime = displayLength;
            displayImage.enabled = true;
        }

        if (imageActive)
        {
            displayTime -= Time.deltaTime;

            if (displayTime <= 0f)
            {
                imageActive = false;
                displayImage.enabled = false;
            }
        }
    }
}
