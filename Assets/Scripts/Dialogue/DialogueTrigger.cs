using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private string dialogueName;

    // Public method used on button input to trigger a dialogue session
    public void StartDialogue()
    {
        DialogueState.GetInstance().currentDialogue = dialogueName;
        
        if (dialogueManager.dialogueIsPlaying == false)
        {
            dialogueManager.EnterDialogueMode(inkJSON);
        }
    }
}
