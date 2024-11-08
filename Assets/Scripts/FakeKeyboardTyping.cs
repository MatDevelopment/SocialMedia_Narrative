using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Random = System.Random;

public class FakeKeyboardTyping : MonoBehaviour
{
    [SerializeField] private InputAction anyKeyInput;
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private WordSpawner wordSpawner;
    [SerializeField] private WordManager wordManager;
    
    [SerializeField] private string StringToFakeType;
    private string userFakeTypeString;

    [SerializeField]
    private string wordGroupTag;
    
    private char[] StringFakeCharArray;

    private int fakeTypePressesRequired;
    private int currentUserTypePresses;
    [SerializeField] private int spawnMaximum;
    private int wordsLeftToWrite;

    public List<string> wordListCurrent;
    public List<Word> words;

    private bool hasActiveWord;
    private Word activeWord;

    [SerializeField] private bool isThereStringToType = false;
    

    private void Awake()
    {
        /*anyKeyInput.performed += FakeType;
        anyKeyInput.canceled -= FakeType;
        anyKeyInput.started -= FakeType;*/

        if (StringToFakeType.Length > 0)
        {
            isThereStringToType = true;
        }
        else if (StringToFakeType.Length <= 0)
        {
            isThereStringToType = false;
        }
        
        StartTypingRound();
        
    }

    private void StartTypingRound()
    {
        wordManager.inTypingRound = true;
        wordListCurrent.Clear();
        words.Clear();
        SplitStringIntoWords(StringToFakeType);
        StringToFakeType = "";
    }
    
    /*
    private void OnEnable()
    {
        anyKeyInput.Enable();
    }

    private void OnDisable()
    {
        anyKeyInput.Disable();
        anyKeyInput.performed -= FakeType;
    }

    private void FakeType(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("TYPErrrrrrrrrrrrrrrr");
        }

        if (context.canceled)
        {
            Debug.Log("UP");
        }
    }*/
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTypingRound();
        }
    }

    /*private void FakeTyping()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame && isThereStringToType == true)
        {
            StringFakeCharArray = StringToFakeType.ToCharArray();
            fakeTypePressesRequired = StringToFakeType.Length;
            //Debug.Log("TYPING");

            userFakeTypeString.Insert(currentUserTypePresses,StringFakeCharArray[currentUserTypePresses].ToString());
            currentUserTypePresses++;
            
            Debug.Log(userFakeTypeString);
        }

        if (currentUserTypePresses >= fakeTypePressesRequired && isThereStringToType == true)
        {
            Debug.Log("DONE TYPING");
        }
    }*/

    void SplitStringIntoWords(string text)
    {
        /*string text = "'Oh, you can't help that,' said the Cat: 'we're all mad here. I'm mad. You're mad.'"*/;
        char[] punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
        var words_ = text.Split().Select(x => x.Trim(punctuation));
        
        foreach (string word in words_)
        {
            wordListCurrent.Add(word);
            //print(word);
        }
        AddWordsToType(spawnMaximum);
    }

    void AddWordsToType(int WordsAmount)
    {
        int randomIndexMaximum = WordsAmount;
        for (int i = 0; i < WordsAmount; i++)
        {
            AddWord(i);
            wordsLeftToWrite++;
        }
        
    }

    public void AddWord(int wordScreenPlacementIndex)
    {
        Word word = new Word(GetRandomWord(), wordSpawner.SpawnWord(wordScreenPlacementIndex, wordGroupTag));
        Debug.Log(word.word);
        
        words.Add(word);
    }

    public string GetRandomWord()
    {
        int randomWordIndex = UnityEngine.Random.Range(0, wordListCurrent.Count);
        string randomWord = wordListCurrent[randomWordIndex];
        wordListCurrent.Remove(randomWord);
        
        return randomWord;
    }

    public void TypeLetter(char letter)
    {
        if (wordManager.finishedPickingADialogue == true)
        {
            wordsLeftToWrite = 0;
            wordListCurrent.Clear();
            words.Clear();
            wordManager.inTypingRound = false;
            isThereStringToType = false;
            wordManager.DestroyObjects();
            activeWord.word = "";

            wordManager.finishedPickingADialogue = false;
        }
        if (hasActiveWord)
        {
            // Check if letter was next
                //Remove it from the word
                if (activeWord.GetNextLetter() == letter)
                {
                    activeWord.TypeLetter();
                }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            wordsLeftToWrite--;
            if (wordsLeftToWrite <= 0)
            {
                if (gameObject.transform.name == "DialogueOption1")
                {
                    Debug.Log("DialogueOption 1 chosen");
                }
                else if (gameObject.transform.name == "DialogueOption2")
                {
                    Debug.Log("DialogueOption 2 chosen");
                }
                else if (gameObject.transform.name == "DialogueOption3")
                {
                    Debug.Log("DialogueOption 3 chosen");
                }
                
                wordsLeftToWrite = 0;
                wordListCurrent.Clear();
                words.Clear();
                wordManager.inTypingRound = false;
                isThereStringToType = false;
                wordManager.DestroyObjects();
                activeWord.word = "";
                wordManager.finishedPickingADialogue = true;
            }
        }
        
        
    }
    
    
    
}
    


