using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    
    private void Start()
    {
        
    }

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.blue;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }
    
    //IMPLEMENT DESTROY GAMEOBJECT WHEN UNITY EVENT IS INVOKED AFTER CHOOSING A DIALOGUE OPTION
}
