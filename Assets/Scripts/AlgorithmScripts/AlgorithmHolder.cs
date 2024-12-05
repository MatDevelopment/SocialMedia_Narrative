using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmHolder : MonoBehaviour
{
    public float angerScore = 0;
    public float stressScore = 0;
    public float grindScore = 0;

    private float lastStress;
    private float lastGrind;
    private float lastAnger;

    public void AddScore(float time, string algorithmCategory)
    {
        float roundedTime = Mathf.Round(time * 100f) / 100f;

        switch (algorithmCategory)
        {
            case "anger":
                angerScore += roundedTime;
                break;
            case "stress":
                stressScore += roundedTime;
                break;
            case "grind":
                grindScore += roundedTime;
                break;
            default:
                Debug.LogWarning($"Unknown color category: {algorithmCategory}");
                break;
        }
        Debug.Log($"Score Updated! Anger: {angerScore:F2}, Stress: {stressScore:F2}, Grind: {grindScore:F2}");
    }
}