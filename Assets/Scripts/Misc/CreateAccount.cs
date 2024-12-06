using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateAccount : MonoBehaviour
{
    [Header("Show On Start")]
    [SerializeField] private bool showOnStart = true;

    [Header("UI Elements")]
    [SerializeField] private GameObject createAccountPanel;
    [SerializeField] private TextMeshProUGUI nameInput;
    [SerializeField] private Animator profileButtonAnimator;
    [SerializeField] private Animator playerNameAnimator;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private GameObject friendsPanel;

    [Header("Riley UI")]
    [SerializeField] private GameObject rileyActiveButton;
    [SerializeField] private GameObject rileyChatButton;
    [SerializeField] private GameObject rileyFriendsPanel;
    [SerializeField] private GameObject rileyFriendRequest;

    [Header("Fade Controller")]
    [SerializeField] private FadeController fadeController;
    //[SerializeField] private TextMeshProUGUI fadeTitle;
    //[SerializeField] private TextMeshProUGUI fadeText;

    private void Start()
    {
        if (showOnStart)
        {
            createAccountPanel.SetActive(true);
        }
    }

    public void CreateButton()
    {
        DialogueState.GetInstance().playerName = nameInput.text;
        playerNameText.text = nameInput.text;
        createAccountPanel.SetActive(false);
    }

    public void SelectPlayerPortrait(string portraitName)
    {
        DialogueState.GetInstance().playerPortrait = portraitName;
        profileButtonAnimator.Play(portraitName);
        playerNameAnimator.Play(portraitName);
    }

    public void OpenFriendsPanel()
    {
        if (!friendsPanel.activeInHierarchy)
        {
            friendsPanel.SetActive(true);
        }
        else if (friendsPanel.activeInHierarchy)
        {
            friendsPanel.SetActive(false);
        }
    }

    public void AcceptFriendRequest()
    {
        rileyFriendRequest.SetActive(false);
        DialogueState.GetInstance().currentAct = "act2-1";

        StartCoroutine(fadeController.FadeToNewAct("Act 2", "A few days has passed and Sam has not been online in a while. Now a new friend wants to chat"));

        rileyActiveButton.SetActive(true);
        rileyChatButton.SetActive(true);
        rileyFriendsPanel.SetActive(true);
    }

    //public IEnumerator FadeToNewAct(string fadeControllerTitle, string fadeControllerText)
    //{
    //    fadeTitle.text = fadeControllerTitle;
    //    fadeText.text = fadeControllerText;

    //    fadeController.FadeOut();
    //    fadeController.ShowText();
    //    yield return new WaitForSeconds(5);
    //    fadeController.HideText();
    //    fadeController.FadeIn();
    //}
}
