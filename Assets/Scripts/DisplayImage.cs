using UnityEngine;
using UnityEngine.UI;

public class DisplayImage : MonoBehaviour
{
    public Image image;
    public float displayTime = 2f;

    private bool isDisplaying = false;

    private void Start()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDisplaying)
        {
            isDisplaying = true;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            Invoke("HideImage", displayTime);
        }
    }

    private void HideImage()
    {
        isDisplaying = false;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }
}
