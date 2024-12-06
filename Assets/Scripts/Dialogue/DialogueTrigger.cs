using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset act1InkJSON;
    [SerializeField] private TextAsset act2IntroInkJSON;
    [SerializeField] private TextAsset act2AnxietyInkJSON;
    [SerializeField] private TextAsset act2LowSelfEsteemInkJSON;
    [SerializeField] private TextAsset act2GrindInkJSON;
    [SerializeField] private TextAsset act2EndInkJSON;
    [SerializeField] private TextAsset act3InkJSON;
    [SerializeField] private TextAsset act3IgnoredInkJSON;
    [SerializeField] private TextAsset act3EngagedInkJSON;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private string dialogueName;

    // Public method used on button input to trigger a dialogue session
    public void StartDialogue()
    {
        DialogueState.GetInstance().currentDialogue = dialogueName;

        // Removing nofitication icon when pressing the button
        if (dialogueName == "sam")
        {
            DialogueState.GetInstance().newMessageSam = false;
        } 
        else if (dialogueName == "riley")
        {
            DialogueState.GetInstance().newMessageRiley = false;
        }

        // Logic based on the DialogueState script for what ink file to start when pressing the button
        if (dialogueManager.dialogueIsPlaying == false)
        {
            if (DialogueState.GetInstance().currentAct == "act1-1" && dialogueName == "sam")
            {
                dialogueManager.EnterDialogueMode(act1InkJSON);
            }
            else if (DialogueState.GetInstance().currentAct == "act2-1" && dialogueName == "riley")
            {
                dialogueManager.EnterDialogueMode(act2IntroInkJSON);
            }
            else if (DialogueState.GetInstance().currentAct == "act2-2" && dialogueName == "riley")
            {
                if (DialogueState.GetInstance().finalTheme == "anxiety")
                {
                    dialogueManager.EnterDialogueMode(act2AnxietyInkJSON);
                }
                else if (DialogueState.GetInstance().finalTheme == "lowselfesteem")
                {
                    dialogueManager.EnterDialogueMode(act2LowSelfEsteemInkJSON);
                }
                else if (DialogueState.GetInstance().finalTheme == "grind")
                {
                    dialogueManager.EnterDialogueMode(act2GrindInkJSON);
                }
            }
            else if (DialogueState.GetInstance().currentAct == "act2-3")
            {
                dialogueManager.EnterDialogueMode(act2EndInkJSON);
            }
            else if (DialogueState.GetInstance().currentAct == "act3-1")
            {
                dialogueManager.EnterDialogueMode(act3InkJSON);
            }
            else if (DialogueState.GetInstance().currentAct == "act3-2" && dialogueName == "sam")
            {
                if (DialogueState.GetInstance().samIgnored)
                {
                    dialogueManager.EnterDialogueMode(act3IgnoredInkJSON);
                }
                else if (!DialogueState.GetInstance().samIgnored)
                {
                    dialogueManager.EnterDialogueMode(act3EngagedInkJSON);
                }
            }
            else if (DialogueState.GetInstance().currentAct == "act3-2" && dialogueName == "riley")
            {
                if (DialogueState.GetInstance().rileyIgnored)
                {
                    dialogueManager.EnterDialogueMode(act3IgnoredInkJSON);
                }
                else if (!DialogueState.GetInstance().rileyIgnored)
                {
                    dialogueManager.EnterDialogueMode(act3EngagedInkJSON);
                }
            }
            else
            {
                Debug.Log($"No current dialogue for: {dialogueName}");
            }
        }
    }
}
