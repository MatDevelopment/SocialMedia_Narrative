using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
public class FakeKeyboardTyping : MonoBehaviour
{
    [SerializeField] private InputAction anyKeyInput;
    [SerializeField] private InputActionAsset playerControls;
    
    [SerializeField] private string StringToFakeType;
    private string userFakeTypeString;
    
    private char[] StringFakeCharArray;

    private int fakeTypePressesRequired;
    private int currentUserTypePresses;

    [SerializeField] private bool isThereStringToType = false;

    private void Awake()
    {
        /*anyKeyInput.performed += FakeType;
        anyKeyInput.canceled -= FakeType;
        anyKeyInput.started -= FakeType;*/

        if (StringToFakeType.Length > 0)
        {
            isThereStringToType = true;
        }
        else if (StringToFakeType.Length <= 0)
        {
            isThereStringToType = false;
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
    
    private void Update()
    {
        FakeTyping();
    }

    private void FakeTyping()
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
    }
}
