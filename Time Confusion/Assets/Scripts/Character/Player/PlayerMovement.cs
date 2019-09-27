using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private static PlayerMovement playerMovementInstance;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private Rigidbody2D playerRigidBody;
    private PlayerInput playerInput;
    private PlayerData playerData;
    private static bool isPlayerInADialogue=false;
    public PlayerAnimationData playerAnimation { get; private set; }
    public bool PlayerJump { get; set; }
    public bool PlayerLand { get; set; }
    public bool OnGround { get; private set; }
    public bool PlayerRoll { get; set; } = false;
    public static PlayerMovement PlayerMovementInstance {
        get {
            if (playerMovementInstance==null)
            {
                playerMovementInstance = GameObject.FindObjectOfType<PlayerMovement>(); 
            }
            return playerMovementInstance;
        }

    }

    private void Awake()
    {

        playerRigidBody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerData = GetComponent<PlayerData>();
        playerAnimation = GetComponent<PlayerAnimationData>();        
    }

    private void FixedUpdate()
    {
        if (!playerData.IsDead)
        {
            if (!isPlayerInADialogue)
            {
                MoveThePlayer();
                FlipPlayer();
            }
            else
            {
                PlayerInDialogueMovement();
            }
        }
        else {
            OnPlayerDeath();
        }



    }
    private void MoveThePlayer()
    {
        playerRigidBody.velocity = new Vector2((Time.fixedDeltaTime * movementSpeed) * playerInput.PlayerHorizontalInputValue, playerRigidBody.velocity.y);
        playerAnimation.PlayerAnimator.SetFloat(playerAnimation.m_SpeedParamIDFloat,Mathf.Abs(playerInput.PlayerHorizontalInputValue));
        GetAndRunPlayerInputData();
        OnGround = IsGrounded();
        playerAnimation.HandleAnimationLayers();
        PlayerLandFunc();     
    }

    private void PlayerInDialogueMovement()
    {
        playerRigidBody.velocity = Vector2.zero;
        playerAnimation.PlayerAnimator.SetFloat(playerAnimation.m_SpeedParamIDFloat, 0f);
    }

    public void PlayerJumpFunc()
    {
       
       if (PlayerJump && playerRigidBody.velocity.y==0)
        {           
            playerRigidBody.AddForce(new Vector2(0, jumpForce));
        }      
    }

    public void PlayerLandFunc()
    {
        if (playerRigidBody.velocity.y < 0)
        {          
           playerAnimation.PlayerAnimator.SetBool(playerAnimation.m_LandParamIDBoolean, true);
        }
    }


    private void GetAndRunPlayerInputData()
    {
        playerInput.RunPlayerInputData();
    }
    private void FlipPlayer()
    {
        if ((playerInput.PlayerHorizontalInputValue>0 &&!(playerData.isCharacterFacingRight)) || (playerInput.PlayerHorizontalInputValue<0 && playerData.isCharacterFacingRight))
        {
            playerData.ChangeCharacterDirection();
        }        
    }

    private bool IsGrounded()
    {
        if (playerRigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }

                }
            }
        }
        return false;

    }
   
    public static void SetIsInDialogue(bool isInADialogue)
    {
        isPlayerInADialogue = isInADialogue;
    }
    public void OnPlayerDeath()
    {
        playerRigidBody.velocity = Vector2.zero;
    }

}
