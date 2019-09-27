using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseNPC : MonoBehaviour
{
    [SerializeField]
    protected Conversation[] conversations;
    public int ConversationCount { get; set; }
    public InteractUI interactUI { get; private set; }
    public bool IsPlayerInDialogueRange { get; private set; } = false;


    private void Start()
    {   
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(),FindObjectOfType<PlayerMovement>().GetComponent<Collider2D>());
        interactUI = new InteractUI(this);
    }

    public Conversation[] GetConversations()
    {
        return conversations;
    }
    public void SetPlayerDialogueRange(bool diaRange)
    {
        IsPlayerInDialogueRange = diaRange;
    }
}
