using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class WordSpawner : MonoBehaviour
{
    [SerializeField] private WordManager _wordManager;
    
    public GameObject wordPrefab;
    
    public Transform wordCanvas;
    private Transform RandomlyPickedWordSpawnPosition;
    public List<int> spawnPositionsTempIndexRange; 

        
    [SerializeField]
    private Transform TypeWord1_SpawnTransform;
    [SerializeField]
    private Transform TypeWord2_SpawnTransform;
    [SerializeField]
    private Transform TypeWord3_SpawnTransform;
    [SerializeField]
    private Transform TypeWord4_SpawnTransform;
    [SerializeField]
    private Transform TypeWord5_SpawnTransform;
    [SerializeField]
    private Transform TypeWord6_SpawnTransform;
    [SerializeField]
    private Transform TypeWord7_SpawnTransform;
    [SerializeField]
    private Transform TypeWord8_SpawnTransform;
    
    public WordDisplay SpawnWord(int index, string wordGroupTag)
    {
        switch (index) {
            case 0:
                
                RandomlyPickedWordSpawnPosition = TypeWord1_SpawnTransform;
                
                break;
            
            case 1:
                
                RandomlyPickedWordSpawnPosition = TypeWord2_SpawnTransform;
                
                break;
            
            case 2:
                RandomlyPickedWordSpawnPosition = TypeWord3_SpawnTransform;
                
                break;
            
            case 3:
                RandomlyPickedWordSpawnPosition = TypeWord4_SpawnTransform;
                
                break;
            
            case 4:                                                             // Only positioned five spawn transforms, therefore only uncommented till here.
                RandomlyPickedWordSpawnPosition = TypeWord5_SpawnTransform;
                
                break;      
            
            /*case 5:                                                         
                RandomlyPickedWordSpawnPosition = TypeWord6_SpawnTransform;
                break;
            case 6:
                RandomlyPickedWordSpawnPosition = TypeWord7_SpawnTransform;
                break;
            case 7:
                RandomlyPickedWordSpawnPosition = TypeWord8_SpawnTransform;
                break;*/
            default:
                // Handle cases where caseNumber is outside 1-8 range, if needed
                break;
        }

        GameObject wordObj = Instantiate(wordPrefab, wordCanvas);
        _wordManager.objectsToDestroy.Add(wordObj);
        wordObj.tag = wordGroupTag; //Deprecated
        wordObj.transform.position = RandomlyPickedWordSpawnPosition.position; 
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
