using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{
    [Header("Dialogue Panels")]
    [SerializeField] private GameObject samDialoguePanel;
    [SerializeField] private GameObject rileyDialoguePanel;
    [SerializeField] private GameObject feedPanel;

    [Header("Notification Icons")]
    [SerializeField] private GameObject samNotificationIcon;
    [SerializeField] private GameObject rileyNotificationIcon;

    [Header("Misc")]
    [SerializeField] private GameObject rileyFriendRequest;

    // String for player name
    public string playerName = "Player";

    // String for the name of the animation for the selected player icon
    public string playerPortrait = "player";

    // String that controls what dialogue is shown: "sam", "riley" or ""
    public string currentDialogue = "";

    // Bools to control what dialogue to trigger based on narrative structure
    public bool act1_active = true;
    public bool act2_active = false;
    public bool act3_active = false;

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
        if (currentDialogue == "sam" && !samDialoguePanel.activeInHierarchy)
        {
            samDialoguePanel.SetActive(true);
        }
        else if (currentDialogue != "sam")
        {
            samDialoguePanel.SetActive(false);
        }

        if (currentDialogue == "riley" && !rileyDialoguePanel.activeInHierarchy)
        {
            rileyDialoguePanel.SetActive(true);
        }
        else if (currentDialogue != "riley")
        {
            rileyDialoguePanel.SetActive(false);
        }

        if (currentDialogue == "feed" && !feedPanel.activeInHierarchy)
        {
            feedPanel.SetActive(true);
        }
        else if (currentDialogue != "feed")
        {
            feedPanel.SetActive(false);
        }
    }

}
