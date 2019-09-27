using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInput : MonoBehaviour
{
    private BaseNPC baseNpc;
    private InteractWithPlayer interactPlayer;

    private void Awake()
    {
        baseNpc = GetComponent<BaseNPC>();
        interactPlayer = GetComponentInChildren<InteractWithPlayer>();
    }
    void Update()
    {
        HandleNPCInput();
    }

    private void HandleNPCInput()
    {
        if (baseNpc.IsPlayerInDialogueRange && Input.GetKeyDown(KeyCode.E))
        {
            baseNpc.SetPlayerDialogueRange(false);
         //   Debug.Log($"Starting Conversation"+this.name);
            interactPlayer.Interact();
        }
    }
}
