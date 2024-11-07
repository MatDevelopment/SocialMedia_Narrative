using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    // Public method used on button input to trigger a dialogue session
    public void StartDialogue()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying == false)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }
}
