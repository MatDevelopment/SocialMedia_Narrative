using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    // Script based on tutorial by "Shaped by Rain Studios": https://youtu.be/vY0Sk93YUhA?si=MM12nYC_nWyXA0PH

    // Fields in the inspector window for communicating with the UI elements
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    // Defining a variable to hold the currently active dialogue and if it is playing
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    
    // To make this script a singleton we create a static instance of the script
    private static DialogueManager instance;

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
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        // Ensuring the dialogue is off when starting the game
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        // Setting the choices text length to the amount of choices
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        // Setting the choicesText list to the text children objects on each button
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        // Returns if dialogue is not playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        // Handling continuing to next line of dialogue
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    // Public method for starting a dialogue session
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        // Sets the current story to the inputted ink.json dialogue file
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    // Method for exiting out of dialogue mode
    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    // Method for continuing the story to the next line of dialogue
    private void ContinueStory()
    {
        // Checks if there is any dialogue using ink's "canContinue" boolean
        if (currentStory.canContinue)
        {
            // Setting the UI to the next line of dialogue using ink's "Continue()" which is popping the line off of a stack
            dialogueText.text = currentStory.Continue();

            // Displays the choices, if any, for given dialogue line
            DisplayChoices();
        }
        else
        {
            // If there is no lines of dialogue left it exits the dialogue mode
            ExitDialogueMode();
        }
    }

    // Method for displaying choices if there is any choices to the current part of the dialogue
    private void DisplayChoices()
    {
        // Checks the current ink Story running and returns a list of Ink Choice objects
        List<Choice> currentChoices = currentStory.currentChoices;

        // Check to see if the UI supports the amount of choices in the story
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        // Enabling and initializing all the choices up to the amount in the given line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        // Ensuring that all the remaining choices that the UI supports are hidden if not needed for given dialogue line
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    // Updates the eventsystem to be able to click the choices
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
