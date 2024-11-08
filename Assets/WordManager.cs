using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WordManager : MonoBehaviour
{
    // List of GameObjects to destroy
    public List<GameObject> objectsToDestroy;

    public bool inTypingRound;
    public bool finishedPickingADialogue;

    private void Awake()
    {
    }

    // Method to destroy each object in the list
    public void DestroyObjects()
    {
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null) // Check if the object still exists
                Destroy(obj);
        }
    }
}
