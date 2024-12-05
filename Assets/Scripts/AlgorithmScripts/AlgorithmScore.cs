using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgorithmScoreHolder : MonoBehaviour
{
    private RectTransform rectTransform;
    private RectTransform canvasRect;
    private float timer = 0f;
    public float centerThreshold = 10f;
    private Button algorithmButton;
    private Button likeButton;
    private float likeButtonTimeBonus = 10f;
    private AlgorithmHolder algorithmHolder;

    private bool likeButtonPressed = false;
    private Animator likeButtonAnimator;

    private string algorithmCategory; 

    void Start()
    {
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
            likeButton.onClick.AddListener(OnLikeButtonClicked);
        }
        else
        {
            Debug.LogWarning("Like button not found in prefab!");
        }

        likeButtonAnimator = GetComponent<Animator>();

        algorithmCategory = GetCategoryFromName(gameObject.name);
        if (string.IsNullOrEmpty(algorithmCategory))
        {
            Debug.LogWarning("Could not determine category from the box name.");
        }
    }

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

    private string GetCategoryFromName(string name)
    {
        if (name.Contains("stress"))
        {
            return "stress";
        }
        else if (name.Contains("grind"))
        {
            return "grind";
        }
        else if (name.Contains("anger"))
        {
            return "anger";
        }

        return string.Empty; // Return empty if no match is found
    }

    private void OnBoxClicked()
    {
        Debug.Log($"Box clicked! Last centered time: {timer:F2} seconds, Category: {algorithmCategory}");
        algorithmHolder.AddScore(timer, algorithmCategory);
    }

    private void OnLikeButtonClicked()
    {
        if (!likeButtonPressed)
        {
            timer += likeButtonTimeBonus;
            likeButtonAnimator.Play("LikeClicked");
            Debug.Log($"Like button clicked! Timer increased by {likeButtonTimeBonus:F2} seconds. Total time: {timer:F2}");
            likeButtonPressed = true;
        }
        else if (likeButtonPressed)
        {
            timer -= likeButtonTimeBonus;
            likeButtonAnimator.Play("LikeNotClicked");
            Debug.Log($"Like button clicked! Timer decreased by {likeButtonTimeBonus:F2} seconds. Total time: {timer:F2}");
            likeButtonPressed = false;
        }
    }
}
