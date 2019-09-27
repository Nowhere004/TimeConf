using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogueDisplayer:MonoBehaviour
{
    
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private Image speakerImage;
    [SerializeField] private TextMeshProUGUI dialogueText;
    public void UpdateTheDialogueBox(string speakerName, Sprite speakerImage, string dialogueText)
    {
        this.speakerName.text = speakerName;
        this.speakerImage.sprite = speakerImage;
        this.dialogueText.text = dialogueText;
    }
    public void ActivateDialogPanel()
    {
        dialoguePanel.SetActive(true);
    }
    public void DeActivateDialogPanel()
    {
        dialoguePanel.SetActive(false);
    }  
}
