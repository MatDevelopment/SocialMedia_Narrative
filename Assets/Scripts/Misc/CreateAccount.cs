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
    [SerializeField] private AudioManager _audioManager;

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

        StartCoroutine(WaitThenStartConvo());
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

        StartCoroutine(fadeController.FadeToNewAct("Act 2", "A few days has passed and Sam has not been online in a while. Now a new friend wants to chat", false, true));

        rileyActiveButton.SetActive(true);
        rileyChatButton.SetActive(true);
        rileyFriendsPanel.SetActive(true);
    }

    // Function for waiting after creating account to show new message from sam
    private IEnumerator WaitThenStartConvo()
    {
        yield return new WaitForSeconds(5);

        DialogueState.GetInstance().newMessageSam = true;
        DialogueState.GetInstance().currentAct = "act1-1";
        _audioManager.Play("NotificationSound", 1);
    }
}
