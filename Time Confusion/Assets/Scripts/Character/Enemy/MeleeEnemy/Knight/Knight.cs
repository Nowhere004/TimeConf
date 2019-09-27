using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : BaseEnemy, IMeleeAttack
{
    [SerializeField]
    private float meleeAttackAggro;
    public float MeleeAttackAggro => meleeAttackAggro;
    public override bool IsInAttackRange => IsInMeleeAttackRangeFunc();
    public bool IsInMeleeAttackRangeFunc()
    {
        if (Target!=null && Mathf.Abs((transform.position.x-Target.transform.position.x))<=meleeAttackAggro)
        {
            return true;
        }
        return false;
    }

    public override StateType GetAttackType()
    {
        return StateType.MeleeAttack;
    }

}
