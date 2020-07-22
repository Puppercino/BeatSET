using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class InterfaceManager : MonoBehaviour
{
    [Header("Base Interface Settings")]
    public CanvasGroup targetCanvasGroup;

    [Header("Dialog Box Settings")]
    public CanvasGroup dialogBox;
    public Text dialogBoxTitle;
    public Text dialogBoxMessage;
    public bool dialogConfirmed;

    private void Start()
    {
        targetCanvasGroup.alpha = 1;

        dialogBox.alpha = 0;
        dialogBox.interactable = false;
        dialogBox.blocksRaycasts = false;

    }

    public void ShowDialog()
    {
        StartCoroutine(DialogManager());
        Debug.Log("Coroutine for DialogBox started.");
    }

    public void ConfirmDialog() // Apply this function to the OK Button.
    {
        dialogConfirmed = true;
    }

    private IEnumerator DialogManager()
    {
        dialogBox.alpha = 1;
        dialogBoxTitle.text = "3";
        dialogBoxMessage.text = "e";
        dialogBox.interactable = true;
        dialogBox.blocksRaycasts = true;
        
        yield return WaitForConfirmation();
        
        dialogBox.alpha = 0;
        dialogBox.interactable = false;
        dialogBox.blocksRaycasts = false;

        IEnumerator WaitForConfirmation()
        {
            dialogConfirmed = false;
            while (!dialogConfirmed)
            {
                yield return null;
            }
            
        }
    }
}