using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlgorithmScore : MonoBehaviour
{
    private RectTransform rectTransform;
    private RectTransform canvasRect;
    private float timer = 0f;
    public float centerThreshold = 10f;
    private Button algorithmButton;
    private Button likeButton;
    private float likeButtonTimeBonus = 10f;
    private AlgorithmHolder algorithmHolder;

    [SerializeField] private TextMeshProUGUI postText;
    [SerializeField] private TextMeshProUGUI posterName;
    [SerializeField] private TextMeshProUGUI postTime;

    [SerializeField] private GameObject VerificationIcon;

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
        
        //VerificationIcon.SetActive(false);
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
        if (name.Contains("esteem"))
        {
            if (postText.text.Contains("family")) //1
            {
                posterName.text = "Henrik Andersen ";
                postTime.text = "2 hours ago";
            }
            if (postText.text.Contains("friends")) //2
            {
                posterName.text = "Davids Travels ";
                VerificationIcon.SetActive(true);
                postTime.text = "3 days ago";
            }
            if (postText.text.Contains("kilometers")) //3
            {
                posterName.text = "ZacOnTheSpot ";
                postTime.text = "5 hours ago";
            }
            if (postText.text.Contains("Camber")) //4
            {
                posterName.text = "MattLovesLife ";
                VerificationIcon.SetActive(true);
                postTime.text = "8 hours ago";
            }
            if (postText.text.Contains("party")) //5
            {
                posterName.text = "Vera Violette ";
                postTime.text = "3 hours ago";
            }
            return "esteem";
        }
        else if (name.Contains("grind"))
        {
            if (postText.text.Contains("Balance")) //1
            {
                posterName.text = "ClyveFitness ";
                postTime.text = "12 hours ago";
            }
            if (postText.text.Contains("PumpedUp")) //2
            {
                posterName.text = "JamesGrind ";
                VerificationIcon.SetActive(true);
                postTime.text = "5 hours ago";
            }
            if (postText.text.Contains("Smart")) //3
            {
                posterName.text = "Archi Olivia ";
                postTime.text = "4 days ago";
            }
            if (postText.text.Contains("Electibon")) //4
            {
                posterName.text = "Sophia Evelynne ";
                postTime.text = "14 hours ago";
            }
            if (postText.text.Contains("ability")) //5
            {
                posterName.text = "MarcoInvesting ";
                VerificationIcon.SetActive(true);
                postTime.text = "3 days ago";
            }
            return "grind";
        }
        else if (name.Contains("anixety"))
        {
            if (postText.text.Contains("AI")) //1
            {
                posterName.text = "CBN News ";
                VerificationIcon.SetActive(true);
                postTime.text = "10 hours ago";
            }
            if (postText.text.Contains("NASA")) //2
            {
                posterName.text = "LoxNews ";
                VerificationIcon.SetActive(true);
                postTime.text = "9 hours ago";
            }
            if (postText.text.Contains("Arctic")) //3
            {
                posterName.text = "WCA News ";
                VerificationIcon.SetActive(true);
                postTime.text = "2 days ago";
            }
            if (postText.text.Contains("Marine")) //4
            {
                posterName.text = "Pacifica News ";
                VerificationIcon.SetActive(true);
                postTime.text = "17 hours ago";
            }
            
            return "anixety";
        }

        return string.Empty; // Return empty if no match is found
    }

    public void OnBoxClicked()
    {
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
