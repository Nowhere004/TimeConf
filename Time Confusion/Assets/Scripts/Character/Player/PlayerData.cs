using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : CharacterData
{   
    public override bool IsDead => healthStat.CurrentVal<=0;
    private PlayerAnimationData playerAnimator;
    private bool isPlayerHit = false;
    [SerializeField]
    private float hitTime;
    protected override void Start()
    {
        base.Start();
        playerAnimator = PlayerMovement.PlayerMovementInstance.playerAnimation;
    }
    public override IEnumerator TakeDamage()
    {
        if (!isPlayerHit)
        {             
        healthStat.CurrentVal -= 1;
        if (!IsDead)
        {
                playerAnimator.PlayerAnimator.SetTrigger(playerAnimator.m_HitParamIDTrigger);
                isPlayerHit = true;
                yield return new WaitForSeconds(hitTime);
                isPlayerHit = false;
        }
        else
        {
                playerAnimator.PlayerAnimator.SetLayerWeight(1,0);
                playerAnimator.PlayerAnimator.SetTrigger(playerAnimator.m_DieParamIDTrigger);
                Death();
        }
        }
        yield return null;
    }
    public override void Death()
    {
        
    }

   

}
