using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

public class ProfileManager : MonoBehaviour, IPointerClickHandler
{
    //Main profile fields
    private TMP_Text characterText;
    private Animator PFPAnimator;
    private TMP_Text profileDescription;
    private GameObject profileDescriptionObject;
    private InputField profileDescriptionInput;
    private GameObject PDInputObject;
    private string descriptionWritten;
    private string whatPortrait;

    //Friend list fields
    private TMP_Text friendListHeader;
    private Animator samAnimator;
    private TMP_Text friendList1Name;
    private Image friendList1Status;
    private TMP_Text friend1StatusText;
    private Animator rileyAnimator;
    private TMP_Text friendList2Name;
    private Image friendList2Status;
    private TMP_Text friend2StatusText;
    private GameObject friendList2;

    private bool currentlyOnSam;
    private bool currentlyOnRiley;

    private GameObject friendFrame;
    private GameObject LPB;
    private GameObject friendButton;
    private GameObject myPanel;
    private GameObject currentChatPFP;


    void Start()
    {
        characterText = GameObject.Find("CharacterText").GetComponent<TMP_Text>();
        PFPAnimator = GameObject.Find("ProfilePictureHolder").GetComponent<Animator>();
        profileDescription = GameObject.Find("DescriptionText").GetComponent <TMP_Text>();
        profileDescriptionObject = GameObject.Find("DescriptionText");
        profileDescriptionInput = GameObject.Find("DescriptionToWriteIn").GetComponent<InputField>();
        PDInputObject = GameObject.Find("DescriptionToWriteIn");

        friendListHeader = GameObject.Find("FriendListText").GetComponent<TMP_Text>();
        samAnimator = GameObject.Find("SamPFPHolder").GetComponent<Animator>();
        friendList1Name = GameObject.Find("SamText").GetComponent<TMP_Text>();
        friendList1Status = GameObject.Find("SamStatus").GetComponent<Image>();
        friend1StatusText = GameObject.Find("SamStatusHere").GetComponent<TMP_Text>();

        rileyAnimator = GameObject.Find("RileyPFPHolder").GetComponent<Animator>();
        friendList2Name = GameObject.Find("RileyText").GetComponent<TMP_Text>();
        friendList2Status = GameObject.Find("RileyStatus").GetComponent<Image>();
        friend2StatusText = GameObject.Find("RileyStatusHere").GetComponent<TMP_Text>();
        friendList2 = GameObject.Find("RileyFriendListAddition");
        friendList2.SetActive(true);
        currentlyOnSam = false;
        currentlyOnRiley = false;

        friendFrame = GameObject.Find("ActiveFriendsFrame");
        LPB = GameObject.Find("Liked Posts Button");
        friendButton = GameObject.Find("Friends Button");
        myPanel = GameObject.Find("ProfilePanel");
        currentChatPFP = GameObject.Find("PlayerName");
;
    }

    private void Update()
    {
        EnsureEverythingIsFine();
    }

    public void StartProfile()
    {
        friendFrame.SetActive(false);
        LPB.SetActive(false);
        friendButton.SetActive(false);
        PFPAnimator.Play(whatPortrait);
        samAnimator.Play("sam");
        characterText.text = DialogueState.GetInstance().playerName;
        profileDescriptionObject.SetActive(false);
        PDInputObject.SetActive(true);
        friendListHeader.text = characterText.text + "'s friend list:";
        friendList1Name.text = "Sam";
        friendList1Status.color = Color.green;
        friend1StatusText.text = "online";
        friendList2Name.text = "Riley";
        friendList2Status.color = Color.red;
        friend2StatusText.text = "offline";
        friendList2.SetActive(true);
        currentlyOnSam = false;
        currentlyOnRiley = false;
        rileyAnimator.Play("riley");

    }

    public void SamsProfile()
    {
        if (currentlyOnSam == true || currentlyOnRiley == true)
        {
            StartProfile();
        }
        else
        {
            currentlyOnRiley = false;
            PFPAnimator.Play("sam");
            characterText.text = "Sam";
            profileDescription.text = "Hello I'm Sam!\n\nI love my 2 dogs Kessie & Buster, alongside cooking. My Italian food is TheBomb.com\n\nDream of becoming a doctor one day :)\n\nExcited to yap with you!";
            friendListHeader.text = "Sam's friend list:";
            samAnimator.Play(whatPortrait);
            currentlyOnSam = true;
            GetSimilarStuff();
        }
    }


    public void RileyProfile()
    {
        currentlyOnSam = false;
        PFPAnimator.Play("riley");
        characterText.text = "Riley";
        profileDescription.text = "A powerful aura is approaching...\n\nName is Riley, aka XtheRylstar26X for true G's\n\nHang with the best squad & don't associate with cringe\n\nDon't be a stranger, HMU if you got rizz ;)";
        friendListHeader.text = "Riley's friend list:";
        currentlyOnRiley = true;
        GetSimilarStuff();
    }

    public void GetSimilarStuff()
    {
        profileDescriptionObject.SetActive(true);
        PDInputObject.SetActive(false);
        friendFrame.SetActive(false);
        LPB.SetActive(false);
        friendButton.SetActive(false);
        friendList1Name.text = DialogueState.GetInstance().playerName;
        samAnimator.Play(whatPortrait);
        friendList1Status.color = Color.green;
        friend1StatusText.text = "online";
        friendList2.SetActive(false);

    }

    public void EnsureEverythingIsFine()
    {
        if (characterText.text == "Placeholder Name" || characterText.text == "Player")
        {
            characterText.text = DialogueState.GetInstance().playerName;
            friendListHeader.text = DialogueState.GetInstance().playerName + "'s friend list";
        }
        if (myPanel.activeInHierarchy)
        {
            friendFrame.SetActive(false);
            LPB.SetActive(false);
            friendButton.SetActive(false);
            currentChatPFP.SetActive(false);
            whatPortrait = DialogueState.GetInstance().playerPortrait;

        }
        else if (!myPanel.activeInHierarchy)
        {
            friendFrame.SetActive(true);
            LPB.SetActive(true);
            friendButton.SetActive(true);
            currentChatPFP.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        profileDescriptionInput.ActivateInputField();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        string descriptionWritten = profileDescriptionInput.text;
        Debug.Log("Player entered: " + descriptionWritten);
    }

    private IEnumerator INeedMainProfile()
    {
        while (!myPanel.activeInHierarchy)
        {
            yield return null; // Wait for the next frame
        }
        StartProfile();
    }

    public void ShowProfile()
    {
        DialogueState.GetInstance().currentDialogue = "profile";
        StartCoroutine(INeedMainProfile());
    }
}
