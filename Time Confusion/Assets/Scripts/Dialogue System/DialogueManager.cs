using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private DialogueDisplayer dialogueDisplayer;
    private BaseNPC basenpc;
    private Conversation[] conversations;
    private int conversationCount;
    private int lineCounter;
    private void Awake()
    {
        
        dialogueDisplayer = GetComponent<DialogueDisplayer>();
        InteractWithPlayer.OnDialogueButtonPressed += OnNPCDialogueTriggered;
    }
    public void OnNPCDialogueTriggered(BaseNPC basenpc)
    {
        this.basenpc = basenpc;   
        StartConversation();
    }

    private void StartConversation()
    {
        PlayerMovement.SetIsInDialogue(true);
        lineCounter = 0;
        conversations = basenpc.GetConversations();
        if (basenpc.ConversationCount == conversations.Length)
        {
            basenpc.ConversationCount = conversations.Length-1;
        }
        conversationCount = basenpc.ConversationCount;  
        dialogueDisplayer.ActivateDialogPanel();
        dialogueDisplayer.UpdateTheDialogueBox(conversations[conversationCount].lines[lineCounter].speaker.name, conversations[conversationCount].lines[lineCounter].speaker.portrait, conversations[conversationCount].lines[lineCounter].text);
        lineCounter++;
    }
    public void ContinueTheConversation()
    {
        if (lineCounter<conversations[conversationCount].lines.Length)
        {
            dialogueDisplayer.UpdateTheDialogueBox(conversations[conversationCount].lines[lineCounter].speaker.name, conversations[conversationCount].lines[lineCounter].speaker.portrait, conversations[conversationCount].lines[lineCounter].text);
            lineCounter++;
        }
        else
        {
            EndOfTheConversation();
        }
    }

    private void EndOfTheConversation()
    {
        PlayerMovement.SetIsInDialogue(false);
        dialogueDisplayer.DeActivateDialogPanel();      
        basenpc.ConversationCount++;
        basenpc.SetPlayerDialogueRange(true);
    }
}
