using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationData : MonoBehaviour
{
    public Animator PlayerAnimator { get; private set; }
    public int m_RollParamIDTrigger { get; private set; }
    public int m_SpeedParamIDFloat { get; private set; }
    public int m_HitParamIDTrigger { get; private set; }
    public int m_DieParamIDTrigger { get; private set; }
    public int m_JumpParamIDTrigger { get; private set; }
    public int m_ResetParamIDTrigger { get; private set; }
    public int m_AttackParamIDTrigger { get; private set; }
    public int m_LandParamIDBoolean { get; private set; }
    private void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
        m_RollParamIDTrigger = Animator.StringToHash("roll");
        m_SpeedParamIDFloat = Animator.StringToHash("speed");
        m_HitParamIDTrigger = Animator.StringToHash("hit");
        m_DieParamIDTrigger = Animator.StringToHash("die");
        m_JumpParamIDTrigger = Animator.StringToHash("jump");
        m_ResetParamIDTrigger = Animator.StringToHash("reset");
        m_AttackParamIDTrigger = Animator.StringToHash("attack");
        m_LandParamIDBoolean = Animator.StringToHash("land");
       
    }
    public void HandleAnimationLayers()
    {
        if (!PlayerMovement.PlayerMovementInstance.OnGround)
        {
            PlayerAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            PlayerAnimator.SetLayerWeight(1, 0);
        }
    }


}
