using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : MonoBehaviour
{
    [Header("Dialogue Panels")]
    [SerializeField] private GameObject samDialoguePanel;
    [SerializeField] private GameObject rileyDialoguePanel;

    public string currentDialogue = "sam";

    // To make this script a singleton we create a static instance of the script
    private static DialogueState instance;

    // In the awake method the instance is then initialized so that it runs once throughout the entire game
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("There is more than one DialogueManager in the scene");
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
    }

}
