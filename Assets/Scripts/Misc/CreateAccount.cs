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
}
