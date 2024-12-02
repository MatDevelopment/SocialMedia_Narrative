using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgorithmScoreHolder : MonoBehaviour
{
    private Image windowImage;
    private Color WindowColor;
    private RectTransform rectTransform; 
    private RectTransform canvasRect;    
    private float timer = 0f;      
    public float centerThreshold = 10f;
    private Button algorithmButton;
    private Button likeButton;
    private float likeButtonTimeBonus = 10f;
    private AlgorithmHolder algorithmHolder;


    // Start is called before the first frame update
    void Start()
    {
        windowImage = GetComponent<Image>();
        WindowColor = windowImage.color;
        rectTransform = GetComponent<RectTransform>();
        algorithmHolder = FindAnyObjectByType<AlgorithmHolder>();
        Canvas canvas = GetComponentInParent<Canvas>();

        if (canvas != null)
        {
            canvasRect = canvas.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogWarning("Box is not inside a canvas!");
        }


        algorithmButton = GetComponent<Button>();

        if (algorithmButton != null)
        {
            algorithmButton.onClick.AddListener(OnBoxClicked);
        }
        else
        {
            Debug.LogWarning("Button component not found on this box.");
        }

        Transform likeButtonTransform = transform.Find("LikeButton");
        if (likeButtonTransform != null)
        {
            likeButton = likeButtonTransform.GetComponent<Button>();
            likeButton.onClick.AddListener(OnLikeButtonClicked); // Add listener for like button
        }
        else
        {
            Debug.LogWarning("Like button not found in prefab!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCentered())
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
        }
    }

    private bool IsCentered()
    {
        if (rectTransform == null || canvasRect == null) return false;
        Vector2 anchoredPosition = rectTransform.anchoredPosition;
        return Mathf.Abs(anchoredPosition.x) <= centerThreshold && Mathf.Abs(anchoredPosition.y) <= centerThreshold;
    }

    private string TranslateColor(Color color)
    {
        Color red = new Color(1f, 0f, 0f);
        Color blue = new Color(0f, 0f, 1f);
        Color yellow = new Color(1f, 1f, 0f);

        float tolerance = 0.1f;

        if (AreColorsSimilar(color, red, tolerance))
            return "Red";
        if (AreColorsSimilar(color, blue, tolerance))
            return "Blue";
        if (AreColorsSimilar(color, yellow, tolerance))
            return "Yellow";

        return "Unknown";
    }

    private bool AreColorsSimilar(Color c1, Color c2, float tolerance)
    {
        return Mathf.Abs(c1.r - c2.r) <= tolerance &&
               Mathf.Abs(c1.g - c2.g) <= tolerance &&
               Mathf.Abs(c1.b - c2.b) <= tolerance;
    }

    private void OnBoxClicked()
    {
        Debug.Log($"Box clicked! Last centered time: {timer:F2} seconds, Color: {TranslateColor(WindowColor)}");
        algorithmHolder.AddScore(timer, TranslateColor(WindowColor));
    }

    private void OnLikeButtonClicked()
    {
        // Add time bonus to the timer
        timer += likeButtonTimeBonus;
        Debug.Log($"Like button clicked! Timer increased by {likeButtonTimeBonus:F2} seconds. Total time: {timer:F2}");
    }
}

