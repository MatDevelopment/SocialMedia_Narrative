using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    //Main profile fields
    private TMP_Text characterText;
    private Image profilePicture;
    private TMP_Text profileDescription;

    //Friend list fields
    private TMP_Text friendListHeader;
    private Image friendList1PFP;
    private TMP_Text friendList1Name;
    private Image friendList1Status;
    private TMP_Text friend1StatusText;
    private Image friendList2PFP;
    private TMP_Text friendList2Name;
    private Image friendList2Status;
    private TMP_Text friend2StatusText;
    private GameObject friendList2;

    private bool currentlyOnSam;
    private bool currentlyOnRiley;


    void Start()
    {
        characterText = GameObject.Find("CharacterText").GetComponent<TMP_Text>();
        profilePicture = GameObject.Find("ProfilePictureHolder").GetComponent<Image>();
        profileDescription = GameObject.Find("DescriptionText").GetComponent <TMP_Text>();

        friendListHeader = GameObject.Find("FriendListText").GetComponent<TMP_Text>();
        friendList1PFP = GameObject.Find("SamPFPHolder").GetComponent<Image>();
        friendList1Name = GameObject.Find("SamText").GetComponent<TMP_Text>();
        friendList1Status = GameObject.Find("SamStatus").GetComponent<Image>();
        friend1StatusText = GameObject.Find("SamStatusHere").GetComponent<TMP_Text>();

        friendList2PFP = GameObject.Find("RileyPFPHolder").GetComponent<Image>();
        friendList2Name = GameObject.Find("RileyText").GetComponent<TMP_Text>();
        friendList2Status = GameObject.Find("RileyStatus").GetComponent<Image>();
        friend2StatusText = GameObject.Find("RileyStatusHere").GetComponent<TMP_Text>();
        friendList2 = GameObject.Find("RileyFriendListAddition");
        friendList2.SetActive(true);
        currentlyOnSam = false;
        currentlyOnRiley = false;

}

public void YourProfile()
    {
        characterText.text = "TBD";
        profileDescription.text = "I'm Me";
        friendListHeader.text = "Your friend list:";
        friendList1Name.text = "Sam";
        friendList1Status.color = Color.green;
        friend1StatusText.text = "online";
        friendList2Name.text = "Riley";
        friendList2Status.color = Color.red;
        friend2StatusText.text = "offline";
        friendList2.SetActive(true);
        currentlyOnSam = false;
        currentlyOnRiley = false;
    }

    public void SamsProfile()
    {
        if (currentlyOnSam || currentlyOnRiley == true)
        {
            YourProfile();
        }
        else
        {
            characterText.text = "Sam";
            profileDescription.text = "I'm Sam";
            friendListHeader.text = "Sam's friend list:";
            friendList1Name.text = "Your name";
            friendList1Status.color = Color.green;
            friend1StatusText.text = "online";
            friendList2.SetActive(false);
            currentlyOnSam = true;
        }
    }

    public void RileyProfile()
    {
        characterText.text = "Riley";
        profileDescription.text = "I'm Riley";
        friendListHeader.text = "Riley's friend list:";
        friendList1Name.text = "Your name";
        friendList1Status.color = Color.green;
        friend1StatusText.text = "online";
        friendList2.SetActive(false);
        currentlyOnRiley = true;
    }
}
