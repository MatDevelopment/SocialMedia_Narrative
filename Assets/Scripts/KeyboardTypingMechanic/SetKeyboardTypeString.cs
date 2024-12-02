using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
    
public class SetKeyboardTypeString : MonoBehaviour
{
    [SerializeField] private FakeKeyboardTyping _fakeKeyboardTyping;
    
    public void SetTypeStringToChosenDialogueOption(int _chosenDialogue_index)
    {
        _fakeKeyboardTyping.chosenDialogue_index = _chosenDialogue_index;
        
        string dialogueText = GetComponentInChildren<TextMeshProUGUI>().text;
        
        _fakeKeyboardTyping.StartTypingRound(dialogueText);
        
    }
}
