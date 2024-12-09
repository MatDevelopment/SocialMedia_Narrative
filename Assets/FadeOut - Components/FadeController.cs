using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    //Script Inspiration -> https://www.youtube.com/watch?v=Oadq-IrOazg

    //Get animator with fade animations and insert in inspector.
    public Animator fadeAnimator;

    //These are related to testing the methods of the script through number input.
    [Tooltip("While active: Fades can be tested. Press 1 to run FadeOut. Press 2 to run FadeIn. Press 3 to run ShowEndText.")]
    [SerializeField] private bool testFades = false;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI fadeTitle;
    [SerializeField] private TextMeshProUGUI fadeText;
    [SerializeField] private GameObject endingPanel;

    // Update is called once per frame
    void Update()
    {
        //Only allow to activate different functions with keyboard input if the testFades bool is true
        if (testFades == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                FadeOut();
                Debug.Log("Fading Out");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                FadeIn();
                Debug.Log("Fading In");
            }

            if (Input.GetKey(KeyCode.Alpha3))
            {
                ShowText();
                Debug.Log("Showing Text");
            }

            if (Input.GetKey(KeyCode.Alpha4))
            {
                HideText();
                Debug.Log("Hiding Text");
            }

            if (Input.GetKey(KeyCode.Alpha5))
            {
                StartCoroutine(FadeToEnd("The End", "Testing"));
                Debug.Log("Ending Function");
            }
        }
    }

    private void Start()
    {
        endingPanel.SetActive(false);
    }

    //Three different methods that can be called from anywhere (if needed) to start their respective animation.
    public void FadeOut()
    {
        fadeAnimator.SetTrigger("FadeOut");
    }

    public void FadeIn()
    {
        fadeAnimator.SetTrigger("FadeIn");
    }

    public void ShowText()
    {
        fadeAnimator.SetTrigger("ShowText");
    }

    public void HideText()
    {
        fadeAnimator.SetTrigger("HideText");
    }


    public void FadeInAfterTime(float delay)
    {
        Invoke(nameof(FadeIn), delay);
    }
    public void FadeOutAfterTime(float delay)
    {
        Invoke(nameof(FadeOut), delay);
    }

    public IEnumerator FadeToNewAct(string fadeControllerTitle, string fadeControllerText, bool samMessage = false, bool rileyMessage = false)
    {
        fadeTitle.text = fadeControllerTitle;
        fadeText.text = fadeControllerText;

        FadeOut();
        ShowText();
        yield return new WaitForSeconds(8);
        
        if (samMessage)
        {
            DialogueState.GetInstance().newMessageSam = true;
        }

        if (rileyMessage)
        {
            DialogueState.GetInstance().newMessageRiley = true;
        }

        HideText();
        FadeIn();
    }

    public IEnumerator FadeToEnd(string fadeControllerTitle, string fadeControllerText)
    {
        fadeTitle.text = fadeControllerTitle;
        fadeText.text = fadeControllerText;

        FadeOut();
        ShowText();
        yield return new WaitForSeconds(8);
        HideText();
        FadeIn();
        endingPanel.SetActive(true);
    }

    public void EndGameButtonClick()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }

    public void RetryButtonClick()
    {
        Debug.Log("Reloading Scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
