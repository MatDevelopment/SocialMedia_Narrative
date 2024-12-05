using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset act1InkJSON;
    [SerializeField] private TextAsset act2AnxietyInkJSON;
    [SerializeField] private TextAsset act2LowSelfEsteemInkJSON;
    [SerializeField] private TextAsset act2GrindInkJSON;
    [SerializeField] private TextAsset act3InkJSON;
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
            if (DialogueState.GetInstance().act1_active == true && dialogueName == "sam")
            {
                dialogueManager.EnterDialogueMode(act1InkJSON);
            }
            else if (DialogueState.GetInstance().act2_active == true && dialogueName == "riley")
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
            else if (DialogueState.GetInstance().act3_active == true)
            {
                dialogueManager.EnterDialogueMode(act3InkJSON);
            }
        }
    }
}
