using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmHolder : MonoBehaviour
{
    private float redScore = 0;
    private float blueScore = 0;
    private float yellowScore = 0;

    public void AddScore(float time, string colorCategory)
    {
        // Round time to two decimal places
        float roundedTime = Mathf.Round(time * 100f) / 100f;

        // Update score based on color category
        switch (colorCategory)
        {
            case "Red":
                redScore += roundedTime;
                break;
            case "Blue":
                blueScore += roundedTime;
                break;
            case "Yellow":
                yellowScore += roundedTime;
                break;
            default:
                Debug.LogWarning($"Unknown color category: {colorCategory}");
                break;
        }

        // Log updated scores
        Debug.Log($"Score Updated! Red: {redScore:F2}, Blue: {blueScore:F2}, Yellow: {yellowScore:F2}");
    }
}