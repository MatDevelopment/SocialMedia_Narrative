using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public FakeKeyboardTyping fakeKeyboardTyping;
    public WordManager wordManager;

    // Update is called once per frame
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
}
