using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset act1_inkJSON;
    [SerializeField] private TextAsset act2_inkJSON;
    [SerializeField] private TextAsset act3_inkJSON;
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
            if (DialogueState.GetInstance().act1_active == true)
            {
                dialogueManager.EnterDialogueMode(act1_inkJSON);
            }
            else if (DialogueState.GetInstance().act2_active == true)
            {
                dialogueManager.EnterDialogueMode(act2_inkJSON);
            }
            else if (DialogueState.GetInstance().act3_active == true)
            {
                dialogueManager.EnterDialogueMode(act3_inkJSON);
            }
        }
    }
}
