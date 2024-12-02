using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WordManager : MonoBehaviour
{
    // List of GameObjects to destroy
    public List<GameObject> objectsToDestroy;

    public bool inTypingRound;
    //public bool finishedPickingADialogue;

    [SerializeField] private FakeKeyboardTyping DialogueOption1_GameObject;
    //[SerializeField] private FakeKeyboardTyping DialogueOption2_GameObject;
    //[SerializeField] private FakeKeyboardTyping DialogueOption3_GameObject;

    [SerializeField] private List<FakeKeyboardTyping> ListOfDialogueOptionGameObjects;
    
    

    private void Awake()
    {
        ListOfDialogueOptionGameObjects.Add(DialogueOption1_GameObject);
        //ListOfDialogueOptionGameObjects.Add(DialogueOption2_GameObject);
        //ListOfDialogueOptionGameObjects.Add(DialogueOption3_GameObject);
    }

    // Method to destroy each object in the list
    public void DestroyObjects()
    {
        foreach (var dialogueOption in ListOfDialogueOptionGameObjects)
        {
            dialogueOption.wordListCurrentlyChecking.Clear();
            dialogueOption.words.Clear();
            dialogueOption.wordsLeftToWrite = 0;
            inTypingRound = false;
            dialogueOption.isThereStringToType = false;
            dialogueOption.hasActiveWord = false;
            dialogueOption.activeWord.word = "";
            //dialogueOption.dialogueOptionText.text = "";
        }
        
        
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null) // Check if the object still exists
                Destroy(obj);
        }
        objectsToDestroy.Clear();
        
    }
}
