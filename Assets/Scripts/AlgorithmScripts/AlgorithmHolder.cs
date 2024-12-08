using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmHolder : MonoBehaviour
{
    public float anixetyScore = 0;
    public float esteemScore = 0;
    public float grindScore = 0;

    private float lastEsteem;
    private float lastGrind;
    private float lastAnixety;

    public void AddScore(float time, string algorithmCategory)
    {
        float roundedTime = Mathf.Round(time * 100f) / 100f;

        switch (algorithmCategory)
        {
            case "anixety":
                anixetyScore += roundedTime;
                break;
            case "esteem":
                esteemScore += roundedTime;
                break;
            case "grind":
                grindScore += roundedTime;
                break;
            default:
                Debug.LogWarning($"Unknown color category: {algorithmCategory}");
                break;
        }
        Debug.Log($"Score Updated! Anixety: {anixetyScore:F2}, Esteem: {esteemScore:F2}, Grind: {grindScore:F2}");
    }

        public Dictionary<string, float> FinalScore()
    {
        anixetyScore = lastAnixety;
        lastGrind = grindScore;
        lastEsteem = esteemScore;

        return new Dictionary<string, float>
        {
            { "anixety", lastAnixety },
            { "esteem", lastEsteem},
            { "grind", lastGrind }
        };
    }

}