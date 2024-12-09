using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SearchService;
using System.Linq;
using Ink;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    // Script based on tutorial by "Shaped by Rain Studios": https://youtu.be/vY0Sk93YUhA?si=MM12nYC_nWyXA0PH

    [Header("Dialogue Name")]
    [SerializeField] private string dialogueName;
    [SerializeField] private FadeController fadeScript;
    private DialogueTrigger dialogueTrigger;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private TextAsset inkIgnored;
    [SerializeField] private FakeKeyboardTyping fakeKeyboardTyping;

    // Fields in the inspector window for communicating with the UI elements
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    private Animator layoutAnimator;

    [Header("Dialogue History")]
    [SerializeField] private GameObject[] messageHistory;
    [SerializeField] private Animator history1Animator;
    [SerializeField] private Animator history2Animator;
    private TextMeshProUGUI[] historyText;
    private List<string> previousMessages = new List<string>();
    private List<string> previousTags = new List<string>();

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    [SerializeField] private Image uiFillImage;
    [SerializeField] private float choiceTimerDuration = 20f;
    private float updateTimerRate = 0.05f;
    private float remainingTime = 20;

    // Defining a variable to hold the currently active dialogue and if it is playing
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private bool waitingForResponse = false;
    private bool timerEnabled = false;
    private float timerDuration = 20f;
    private bool timerStopped = false;
    private bool chatIgnored = false;

    // Defining the tags we look for in the dialogue to define who is speaking and the layout.
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

    private void Start()
    {
        // Makes the timer start off as default
        ResetTimer();

        // Ensuring the dialogue is off when starting the game
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        // Getting the layout animator component to change layout based on tags
        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        // Getting the layout animator component to change layout based on tags
        dialogueTrigger = GetComponent<DialogueTrigger>();

        // Setting the choices text length to the amount of choices
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        // Setting the choicesText list to the text children objects on each button
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        // Setting the history text length to the amount of choices
        historyText = new TextMeshProUGUI[messageHistory.Length];
        int index2 = 0;

        // Setting the historyText list to the text children objects on each frame
        foreach (GameObject message in messageHistory)
        {
            historyText[index2] = message.GetComponentInChildren<TextMeshProUGUI>();
            index2++;
            message.SetActive(false);
        }
    }

    private void Update()
    {
        // Returns if dialogue is not playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        // Starts the timer for automatically changing to the next text after a certain time
        if (currentStory.currentChoices.Count == 0 && waitingForResponse == false)
        {
            StartCoroutine(WaitThenContinue(3));
        }

        // Specifically for act 3, where if the timer ever runs out, the chat will change to the ignored script instead
        if (DialogueState.GetInstance().currentAct == "act3-1" && !chatIgnored)
        {
            // Code for stopping timer in progress if other chat is ignored
            if (dialogueName == "sam" && DialogueState.GetInstance().rileyIgnored && !timerStopped)
            {
                ResetTimer();
                StopAllCoroutines();
                timerStopped = true;
                Debug.Log($"Dialogue: {dialogueName} timer is stopped: {timerStopped}");
            }
            else if (dialogueName == "riley" && DialogueState.GetInstance().samIgnored && !timerStopped)
            {
                ResetTimer();
                StopAllCoroutines();
                timerStopped = true;
                Debug.Log($"Dialogue: {dialogueName} timer is stopped: {timerStopped}");
            }

            // Changing ink file and resetting UI
            if (dialogueName == "sam" && DialogueState.GetInstance().samIgnored)
            {
                currentStory = new Story(inkIgnored.text);
                chatIgnored = true;
                fakeKeyboardTyping.ResetKeyboardTypingMechanic();
                ContinueStory();
            }
            else if (dialogueName == "riley" && DialogueState.GetInstance().rileyIgnored)
            {
                currentStory = new Story(inkIgnored.text);
                chatIgnored = true;
                fakeKeyboardTyping.ResetKeyboardTypingMechanic();
                ContinueStory();
            }
        }

        // Handling continuing to next line of dialogue faster by pressing space before timer is up
        if (Input.GetKeyDown(KeyCode.Space) && DialogueState.GetInstance().currentDialogue == dialogueName && currentStory.currentChoices.Count == 0 && waitingForResponse == true)
        {
            waitingForResponse = false;
            StopAllCoroutines();
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

        switch (DialogueState.GetInstance().currentAct)
        {
            case "act1-1":
                DialogueState.GetInstance().currentAct = "act1-2";
                DialogueState.GetInstance().samActive = false;
                break;
            case "act2-1":
                DialogueState.GetInstance().currentAct = "act2-2";
                dialogueTrigger.StartDialogue();
                break;
            case "act2-2":
                DialogueState.GetInstance().currentAct = "act2-3";
                dialogueTrigger.StartDialogue();
                break;
            case "act2-3":
                DialogueState.GetInstance().currentAct = "act3-1";
                StartCoroutine(fadeScript.FadeToNewAct("Act 3", "After your talk with Riley a few days has passed. Sam has finally returned, but has something troubling him, while Riley still wants your attention. A choice has to be made...", true, true));
                DialogueState.GetInstance().samActive = true;
                break;
            case "act3-1":
                if (dialogueName == "sam")
                {
                    DialogueState.GetInstance().samDone = true;
                    
                    // Ensuring that only one can be engaged with
                    if (!DialogueState.GetInstance().samIgnored)
                    {
                        DialogueState.GetInstance().rileyIgnored = true;
                    }
                }
                else if (dialogueName == "riley")
                {
                    DialogueState.GetInstance().rileyDone = true;

                    // Ensuring that only one can be engaged with
                    if (!DialogueState.GetInstance().rileyIgnored)
                    {
                        DialogueState.GetInstance().samIgnored = true;
                    }
                }

                // If both dialogues are done then end the game
                if (DialogueState.GetInstance().samDone && DialogueState.GetInstance().rileyDone)
                {
                    if (!DialogueState.GetInstance().samIgnored && !DialogueState.GetInstance().rileyIgnored)
                    {
                        StartCoroutine(fadeScript.FadeToEnd("The Best Ending", "You were able to both help and connect with both Sam and Riley in their time of need"));
                    }
                    else if (!DialogueState.GetInstance().samIgnored && DialogueState.GetInstance().rileyIgnored)
                    {
                        StartCoroutine(fadeScript.FadeToEnd("The Sam Only Ending", "You were able to help sam, but neglected Riley. You remain good friends with Sam but Riley has stopped trying to reach you"));
                    }
                    else if (DialogueState.GetInstance().samIgnored && !DialogueState.GetInstance().rileyIgnored)
                    {
                        StartCoroutine(fadeScript.FadeToEnd("The Riley Only Ending", "You chose to talk with Riley, but neglected Sam. Sam has chosen to distance himself from you, but atleast you are able to write to Riley"));
                    }
                    else if (DialogueState.GetInstance().samIgnored && DialogueState.GetInstance().rileyIgnored)
                    {
                        StartCoroutine(fadeScript.FadeToEnd("The Worst Ending", "You chose to ignore both Sam and Riley. Both have chosen to distance themselves from you as you neglected them when they needed you most"));
                    }
                }
                break;
            default:
                Debug.Log($"Act state not accounted for: {DialogueState.GetInstance().currentAct}");
                break;
        }
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

            // Handling of tags in the dialogue
            HandleTags(currentStory.currentTags, true);

            // Updates chat history
            previousMessages.Add(dialogueText.text);

            if (previousMessages.Count > 1)
            {
                int index = 0;
                // Enabling and initializing all chat history frames and their texts
                foreach (GameObject message in messageHistory)
                {
                    if (previousMessages.Count - 2 - index >= 0)
                    {
                        messageHistory[index].gameObject.SetActive(true);
                        historyText[index].text = previousMessages[previousMessages.Count - 2 - index];

                        if (index == 0 && previousTags[previousTags.Count - 2 - index] == "left")
                        {
                            history1Animator.Play("HistoryLeft1");
                        } 
                        else if (index == 0 && previousTags[previousTags.Count - 2 - index] == "right")
                        {
                            history1Animator.Play("HistoryRight1");
                        }
                        else if (index == 1 && previousTags[previousTags.Count - 2 - index] == "left")
                        {
                            history2Animator.Play("HistoryLeft2");
                        }
                        else if (index == 1 && previousTags[previousTags.Count - 2 - index] == "right")
                        {
                            history2Animator.Play("HistoryRight2");
                        }

                        index++;
                    }
                }
            }
            
            // Setting the notification icon on if new message is given when not on the page
            if (DialogueState.GetInstance().currentDialogue != dialogueName)
            {
                _audioManager.Play("NotificationSound", 1);
                if (dialogueName == "sam")
                {
                    DialogueState.GetInstance().newMessageSam = true;
                }
                else if (dialogueName == "riley")
                {
                    DialogueState.GetInstance().newMessageRiley = true;
                }
            }
            else if (DialogueState.GetInstance().currentDialogue == dialogueName)
            {
                _audioManager.Play("ChatMessageSound", 1);
            }

        }
        else
        {
            // If there is no lines of dialogue left it exits the dialogue mode
            ExitDialogueMode();
        }
    }

    // Method used for handling all tags in the current line of dialogue which tages a list of strings as input
    private void HandleTags(List<string> currentTags, bool logTag)
    {
        // looping through each tag and handling them accordingly
        foreach (string tag in currentTags)
        {
            // First the key:value pairs are parsed using the Split() method where
            string[] splitTag = tag.Split(':');

            // Testing to see if the split happened correctly
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be parsed correctly" + tag);
            }

            // The first string in the array is the key and the second is the value
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            // A switch case then handles each tag
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    if (tagValue == "Player")
                    {
                        displayNameText.text = DialogueState.GetInstance().playerName;
                    }
                    else
                    {
                        displayNameText.text = tagValue;
                    }
                    break;
                case PORTRAIT_TAG:
                    if (tagValue == "player")
                    {
                        portraitAnimator.Play(DialogueState.GetInstance().playerPortrait);
                    }
                    else
                    {
                        portraitAnimator.Play(tagValue);
                    }
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    if (logTag)
                    {
                        previousTags.Add(tagValue);
                    }
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }

    // Method for displaying choices if there is any choices to the current part of the dialogue
    private void DisplayChoices()
    {
        // Checks the current ink Story running and returns a list of Ink Choice objects
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentStory.currentChoices.Count != 0)
        {
            // Checks if there is a timer enabled for choosing options
            try
            {
                timerEnabled = (bool)currentStory.variablesState["timerEnabled"];
            }
            catch
            {
                timerEnabled = false;
                Debug.Log("No timerEnabled bool in current Ink File");
            }

            try
            {
                timerDuration = (float)currentStory.variablesState["timerDuration"];
            }
            catch
            {
                timerDuration = choiceTimerDuration;
                Debug.Log("No timerDuration float in current Ink File");
            }

            // if the other dialogue is ignored then stop the timer on this dialogue:
            if (dialogueName == "sam" && DialogueState.GetInstance().rileyIgnored && timerEnabled)
            {
                timerEnabled = false;
            }
            else if (dialogueName == "riley" && DialogueState.GetInstance().samIgnored && timerEnabled)
            {
                timerEnabled = false;
            }

            if (timerEnabled)
            {
                StartCoroutine(ChoiceTimer(timerDuration));
            }
        }

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

        // StartCoroutine(SelectFirstChoice());
    }

    // Updates the eventsystem to be able to click the choices
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    private IEnumerator WaitThenContinue(float waitTime)
    {
        waitingForResponse = true;
        yield return new WaitForSeconds(waitTime);
        if (waitingForResponse == true)
        {
            ContinueStory();
            waitingForResponse = false;
        }
    }

    private IEnumerator ChoiceTimer(float waitTime)
    {
        remainingTime = waitTime;
        
        while (remainingTime > 0)
        {
            UpdateTimerUI(remainingTime, waitTime);
            remainingTime -= updateTimerRate;
            yield return new WaitForSeconds(updateTimerRate);
        }

        uiFillImage.fillAmount = 0f;

        if (dialogueName == "sam")
        {
            DialogueState.GetInstance().samIgnored = true;
            Debug.Log($"Timer ended: {dialogueName} ignored: {DialogueState.GetInstance().samIgnored}");
        } 
        else if (dialogueName == "riley")
        {
            DialogueState.GetInstance().rileyIgnored = true;
            Debug.Log($"Timer ended: {dialogueName} ignored: {DialogueState.GetInstance().rileyIgnored}");
        }
        else
        {
            Debug.Log($"Timer ended but no person was ignored dialgoueName: {dialogueName}");
        }
    }

    private void UpdateTimerUI(float remainingTime, float duration)
    {
        uiFillImage.fillAmount = Mathf.InverseLerp(0, duration, remainingTime);
    }

    private void ResetTimer()
    {
        remainingTime = choiceTimerDuration;
        uiFillImage.fillAmount = 0f;
    }

    // Method for when making a choice which updates the ink story of the choice and then continues to next line of dialogue
    public void MakeChoice(int choiceIndex)
    {
        if (currentStory.currentChoices.Count != 0)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();

            // Stops choice timer
            if (timerEnabled)
            {
                ResetTimer();
                StopAllCoroutines();
            }
        }
        else
        {
            Debug.Log("No choices to make, you are probably too late");
        }
    }

    public void RefreshUI()
    {
        // Handling of tags in the dialogue
        HandleTags(currentStory.currentTags, false);

        if (previousMessages.Count > 1)
        {
            int index = 0;
            // Enabling and initializing all chat history frames and their texts
            foreach (GameObject message in messageHistory)
            {
                if (previousMessages.Count - 2 - index >= 0)
                {
                    messageHistory[index].gameObject.SetActive(true);
                    historyText[index].text = previousMessages[previousMessages.Count - 2 - index];

                    if (index == 0 && previousTags[previousTags.Count - 2 - index] == "left")
                    {
                        history1Animator.Play("HistoryLeft1");
                    }
                    else if (index == 0 && previousTags[previousTags.Count - 2 - index] == "right")
                    {
                        history1Animator.Play("HistoryRight1");
                    }
                    else if (index == 1 && previousTags[previousTags.Count - 2 - index] == "left")
                    {
                        history2Animator.Play("HistoryLeft2");
                    }
                    else if (index == 1 && previousTags[previousTags.Count - 2 - index] == "right")
                    {
                        history2Animator.Play("HistoryRight2");
                    }

                    index++;
                }
            }
        }
    }
}
