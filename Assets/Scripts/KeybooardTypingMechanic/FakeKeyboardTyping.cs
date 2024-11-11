using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Random = System.Random;

public class FakeKeyboardTyping : MonoBehaviour
{
    [SerializeField] private InputAction anyKeyInput;
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private WordSpawner wordSpawner;
    [SerializeField] private WordManager wordManager;

    [SerializeField] public TextMeshProUGUI dialogueOptionText;
    
    [SerializeField] private string StringToFakeType;
    private string userFakeTypeString;

    [SerializeField]
    private string wordGroupTag;
    
    private char[] StringFakeCharArray;

    private int fakeTypePressesRequired;
    private int currentUserTypePresses;
    [FormerlySerializedAs("spawnMaximum")] private int wordSpawnMaximum;
    [SerializeField] private int wordAddedPerMathematicalDivision_Max5;
    public int wordsLeftToWrite;

    public List<string> wordListCurrentlyChecking;
    public List<Word> words;

    public bool hasActiveWord;
    public Word activeWord;

    [SerializeField] public bool isThereStringToType = false;
    

    private void Awake()
    {
        /*anyKeyInput.performed += FakeType;
        anyKeyInput.canceled -= FakeType;
        anyKeyInput.started -= FakeType;*/

        
        
        StartTypingRound();
        
    }

    private void StartTypingRound()
    {
        if (StringToFakeType.Length > 0)
        {
            isThereStringToType = true;
        }
        else if (StringToFakeType.Length <= 0)
        {
            isThereStringToType = false;
        }

        if (isThereStringToType)
        {
            //Debug.Log("String to type!");
            wordManager.inTypingRound = true;
            /*wordListCurrentlyChecking.Clear();
            words.Clear();*/
            SplitStringIntoWords(StringToFakeType, wordAddedPerMathematicalDivision_Max5);
            dialogueOptionText.text = StringToFakeType;
            StringToFakeType = "";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTypingRound();
        }
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

    void SplitStringIntoWords(string text,int _wordAddedPerMathematicalDivision_Max5)
    {
        /*string text = "'Oh, you can't help that,' said the Cat: 'we're all mad here. I'm mad. You're mad.'"*/;
        char[] punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
        var words_ = text.Split().Select(x => x.Trim(punctuation));

        int amountOfWordsInString = 0;
        
        foreach (string word in words_)
        {
            wordListCurrentlyChecking.Add(word);
            //print(word);
            amountOfWordsInString++;
        }
        print("Amount of words for " + gameObject.name + ": " + amountOfWordsInString);
        wordSpawnMaximum = amountOfWordsInString / _wordAddedPerMathematicalDivision_Max5;
        if (wordSpawnMaximum < 1)
        {
            wordSpawnMaximum = 1;
        }
        if (wordSpawnMaximum > 5)
        {
            wordSpawnMaximum = 5;
        }
        
        
        /*if (wordSpawnMaximum > 5)
        {
            wordSpawnMaximum = ;
        }
        else if (wordSpawnMaximum % _wordAddedPerMathematicalDivision_Max5 >= 0)
        {
            wordSpawnMaximum /= _wordAddedPerMathematicalDivision_Max5;
        }*/
        
        AddWordsToType(wordSpawnMaximum);
    }

    void AddWordsToType(int WordsAmount)
    {
        int loopsMaximum = WordsAmount;
        for (int i = 0; i < WordsAmount; i++)
        {
            AddWord(i, i);
            wordsLeftToWrite++;
        }
        
    }

    public void AddWord(int wordScreenPlacementIndex, int wordListIndex)
    {
        Word word = new Word(GetChosenWord(wordListIndex), wordSpawner.SpawnWord(wordScreenPlacementIndex, wordGroupTag));
        //Debug.Log(word.word);
        
        words.Add(word);
    }

    public string GetChosenWord(int wordlistIndex)
    {
        //int wordIndex = wordListCurrentlyChecking[wordlistIndex]
        // --------- RANDOM WORD PICKING MECHANIC ----------
        /*int randomWordIndex = UnityEngine.Random.Range(i, wordListCurrentlyChecking.Count);
        string randomWord = wordListCurrentlyChecking[randomWordIndex];
        wordListCurrentlyChecking.Remove(randomWord);*/
        
        string chosenWord = wordListCurrentlyChecking[wordlistIndex];
        
        if (chosenWord.Contains("’"))       
        {
            Debug.Log("Contains apostrophe!!!!!");
            string apostrophe = "’";
            int apostropheIndex = apostrophe.IndexOf(apostrophe, StringComparison.Ordinal);
            chosenWord = chosenWord.Remove(apostropheIndex + 1,1);
        }
        
        return chosenWord;
    }

    public void TypeLetter(char letter)
    {
        /*if (wordManager.finishedPickingADialogue == true)
        {
            wordsLeftToWrite = 0;
            wordListCurrent.Clear();
            words.Clear();
            wordManager.inTypingRound = false;
            isThereStringToType = false;
            wordManager.DestroyObjects();
            activeWord.word = "";

            wordManager.finishedPickingADialogue = false;
        }*/
        
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
                wordListCurrentlyChecking.Clear();
                words.Clear();
                wordManager.inTypingRound = false;
                isThereStringToType = false;
                wordManager.DestroyObjects();
                activeWord.word = "";
                //wordManager.finishedPickingADialogue = true;
            }
        }
        
        
    }
    
    
    
}
    


