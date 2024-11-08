using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WordInput : MonoBehaviour
{
    public FakeKeyboardTyping fakeKeyboardTyping;
    public WordManager wordManager;

    [SerializeField] private InputAction _apostrophePress;

    // Update is called once per frame

    private void Awake()
    {
        //_apostrophePress += ApostropheCheck(context.perfo);
    }

    void Update()
    {
        if (wordManager.inTypingRound == true)
        {
            foreach (char letter in Input.inputString)
            {
                fakeKeyboardTyping.TypeLetter(letter);
            }
            
        }
        
    }
    
    /*public void ApostropheCheck(InputAction.CallbackContext context)
    {
        return context;
    }*/
    
}
    
