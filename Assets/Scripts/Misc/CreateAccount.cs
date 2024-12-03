using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateAccount : MonoBehaviour
{
    [Header("Show On Start")]
    [SerializeField] private bool showOnStart = true;

    [Header("UI Elements")]
    [SerializeField] private GameObject createAccountPanel;
    [SerializeField] private TextMeshProUGUI nameInput;

    private void Start()
    {
        if (showOnStart)
        {
            createAccountPanel.SetActive(true);
        }
    }

    public void CreateButton()
    {
        DialogueState.GetInstance().playerName = nameInput.text;
        createAccountPanel.SetActive(false);
    }

    public void SelectPlayerPortrait(string portraitName)
    {
        DialogueState.GetInstance().playerPortrait = portraitName;
    }
}
