using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{
    [Header("Dialogue Panels")]
    [SerializeField] private GameObject samDialoguePanel;
    [SerializeField] private GameObject rileyDialoguePanel;
    [SerializeField] private GameObject feedPanel;
    [SerializeField] private GameObject chatPanel;
    [SerializeField] private GameObject profilePanel;

    [Header("Dialogue Managers")]
    [SerializeField] private DialogueManager dialogueManagerSam;
    [SerializeField] private DialogueManager dialogueManagerRiley;

    [Header("UI Animators")]
    [SerializeField] private Animator homeButtonAnimator;
    [SerializeField] private Animator chatButtonAnimator;

    [Header("Notification Icons")]
    [SerializeField] private GameObject samNotificationIcon;
    [SerializeField] private GameObject rileyNotificationIcon;
    public bool newMessageSam = false;
    public bool newMessageRiley = false;

    [Header("Algorithm")]
    [SerializeField] private AlgorithmHolder algorithmHolder;
    private bool listeningToAlgorithm = true;
    [SerializeField] private float algorithmThreshold = 100f;
    public string finalTheme = "";

    [Header("Misc")]
    [SerializeField] private GameObject rileyFriendRequest;

    // String for player name
    public string playerName = "Player";

    // String for the name of the animation for the selected player icon
    public string playerPortrait = "player";

    // String that controls what dialogue is shown: "sam", "riley" or ""
    public string currentDialogue = "";

    // Bools to control what dialogue to trigger based on narrative structure
    public string currentAct = "act1-1";

    // Bools for ignoring in Act 3
    public bool samIgnored = false;
    public bool rileyIgnored = false;

    // Bools for ending in Act 3
    public bool samDone = false;
    public bool rileyDone = false;

    // To make this script a singleton we create a static instance of the script
    private static DialogueState instance;

    // In the awake method the instance is then initialized so that it runs once throughout the entire game
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("There is more than one DialogueState in the scene");
        }
        instance = this;
    }

    // Static method for accessing the singleton instance from other scripts
    public static DialogueState GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        // Code that changes what page is active based on the "currentDialogue" string
        if (currentDialogue == "sam" && !samDialoguePanel.activeInHierarchy)
        {
            samDialoguePanel.SetActive(true);
            dialogueManagerSam.RefreshUI();
        }
        else if (currentDialogue != "sam" && samDialoguePanel.activeInHierarchy)
        {
            samDialoguePanel.SetActive(false);
        }

        if (currentDialogue == "riley" && !rileyDialoguePanel.activeInHierarchy)
        {
            rileyDialoguePanel.SetActive(true);
            dialogueManagerRiley.RefreshUI();
        }
        else if (currentDialogue != "riley" && rileyDialoguePanel.activeInHierarchy)
        {
            rileyDialoguePanel.SetActive(false);
        }

        if (currentDialogue == "feed" && !feedPanel.activeInHierarchy)
        {
            feedPanel.SetActive(true);
            homeButtonAnimator.Play("HomeClicked");
        }
        else if (currentDialogue != "feed" && feedPanel.activeInHierarchy)
        {
            feedPanel.SetActive(false);
            homeButtonAnimator.Play("HomeNotClicked");
        }

        if (currentDialogue == "chat" && !chatPanel.activeInHierarchy)
        {
            chatPanel.SetActive(true);
            chatButtonAnimator.Play("ChatClicked");
        }
        else if (currentDialogue != "chat" && chatPanel.activeInHierarchy)
        {
            chatPanel.SetActive(false);
            chatButtonAnimator.Play("ChatNotClicked");
        }
        if (currentDialogue == "profile" && !profilePanel.activeInHierarchy)
        {
            profilePanel.SetActive(true);
        }
        else if (currentDialogue != "profile" && profilePanel.activeInHierarchy)
        {
            profilePanel.SetActive(false);
        }

        // Code for handling the notification icons based on if there is a new message or not
        if (newMessageSam && !samNotificationIcon.activeInHierarchy)
        {
            samNotificationIcon.SetActive(true);
        }
        else if (!newMessageSam && samNotificationIcon.activeInHierarchy)
        {
            samNotificationIcon.SetActive(false);
        }

        if (newMessageRiley && !rileyNotificationIcon.activeInHierarchy)
        {
            rileyNotificationIcon.SetActive(true);
        }
        else if (!newMessageRiley && rileyNotificationIcon.activeInHierarchy)
        {
            rileyNotificationIcon.SetActive(false);
        }

        // Code for Listening to algorithm scores to define theme for act 2
        if (listeningToAlgorithm)
        {
            if (algorithmHolder.angerScore >= algorithmThreshold && currentAct == "act1-2")
            {
                finalTheme = "anxiety";
                rileyFriendRequest.SetActive(true);
                listeningToAlgorithm = false;
                print(finalTheme);
            }
            else if (algorithmHolder.stressScore >= algorithmThreshold && currentAct == "act1-2")
            {
                finalTheme = "lowselfesteem";
                rileyFriendRequest.SetActive(true);
                listeningToAlgorithm = false;
                print(finalTheme);
            }
            else if (algorithmHolder.grindScore >= algorithmThreshold && currentAct == "act1-2")
            {
                finalTheme = "grind";
                rileyFriendRequest.SetActive(true);
                listeningToAlgorithm = false;
                print(finalTheme);
            }
        }
    }

    public void ShowChat()
    {
        currentDialogue = "chat";
    }
}
