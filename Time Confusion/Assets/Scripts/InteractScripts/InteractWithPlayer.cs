using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class InteractWithPlayer : MonoBehaviour, IInteractable
{
    private BaseNPC baseNPC;
   

    public static event Action<BaseNPC> OnDialogueButtonPressed = delegate { }; 

    private void Awake()
    {      
        baseNPC = GetComponentInParent<BaseNPC>();
    }
    public void Interact()
    {
        OnDialogueButtonPressed(baseNPC);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            baseNPC.SetPlayerDialogueRange(true);
            baseNPC.interactUI.ShowandCloseTheInteractButton();
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            baseNPC.SetPlayerDialogueRange(true);
            baseNPC.interactUI.ShowandCloseTheInteractButton();

        }
    }
}
