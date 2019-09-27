using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float PlayerHorizontalInputValue{ get { return Input.GetAxisRaw("Horizontal"); }}
    public float PlayerVerticalInputValue { get { return Input.GetAxisRaw("Vertical"); } }
    private PlayerMovement playerMovement;
    private PlayerAnimationData playerAnimation;
    private PlayerData playerData;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimationData>();
        playerData = GetComponent<PlayerData>();
    }
    public void RunPlayerInputData()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && playerMovement.PlayerRoll)
        {
            playerAnimation.PlayerAnimator.SetTrigger(playerAnimation.m_RollParamIDTrigger);
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.PlayerJump)
        {
            playerAnimation.PlayerAnimator.SetTrigger(playerAnimation.m_JumpParamIDTrigger);
            playerMovement.PlayerJumpFunc();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnimation.PlayerAnimator.SetTrigger(playerAnimation.m_AttackParamIDTrigger);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(playerData.TakeDamage());
        }
    }

}
