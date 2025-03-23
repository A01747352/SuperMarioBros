using UnityEngine;

public class CreditsManagerText : MonoBehaviour
{
    private float scrollSpeed = 100f;
    private RectTransform rt;
    private float startY;
    private float resetY = 994f; // The y position to reset the text to
    private Canvas parentCanvas;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        startY = rt.anchoredPosition.y;

        // Get the parent canvas
        parentCanvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        // Check if the canvas is active
        if (parentCanvas != null && parentCanvas.gameObject.activeSelf)
        {
            rt.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

            // Check if the text has scrolled past the reset point
            if (rt.anchoredPosition.y >= resetY)
            {
                rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, startY);
            }
        }
    }
}