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
        DialogueState.GetInstance().act1_done = false;
        DialogueState.GetInstance().act2_active = true;

        rileyActiveButton.SetActive(true);
        rileyChatButton.SetActive(true);
        rileyFriendsPanel.SetActive(true);
    }
}
