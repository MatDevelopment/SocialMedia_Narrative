using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex;

    private WordDisplay display;
    private WordManager _wordManager;
    
    public Word(string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;

        display = _display;
        display.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        // Remove the letter on screen
        display.RemoveLetter();
    }

    public bool WordTyped()     //Has the word been typed yet?
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            // Remove the word on screen
            display.RemoveWord();
        }

        return wordTyped;
    }
    
}
