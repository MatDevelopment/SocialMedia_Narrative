using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;


public class WordInput : MonoBehaviour
{
    public FakeKeyboardTyping fakeKeyboardTyping;
    public WordManager wordManager;
    private AudioManager audioManager;

    [SerializeField] private InputAction _apostrophePress;

    // Update is called once per frame

    private void Awake()
    {
        //_apostrophePress += ApostropheCheck(context.perfo);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (wordManager.inTypingRound == true)
        {
            foreach (char letter in Input.inputString)
            {
                float randomPitch = Random.Range(0.75f, 1.4f);
                audioManager.Play("KeyClick", randomPitch);
                fakeKeyboardTyping.TypeLetter(letter);
            }
            
        }
        
    }
    
    /*public void ApostropheCheck(InputAction.CallbackContext context)
    {
        return context;
    }*/
    
}
    
