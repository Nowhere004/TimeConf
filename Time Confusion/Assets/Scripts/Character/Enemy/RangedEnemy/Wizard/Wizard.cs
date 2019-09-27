using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : BaseEnemy,IRangedAttack
{
    [SerializeField]
    private float rangedAttackAggro;
    public override bool IsInAttackRange => IsInRangedAttackRangeFunc();
    public float RangedAttackAggro => rangedAttackAggro;

    public override StateType GetAttackType()
    {
        return StateType.RangedAttack;
    }

    public bool IsInRangedAttackRangeFunc()
    {             
            if (Target != null && Mathf.Abs((transform.position.x - Target.transform.position.x)) <= rangedAttackAggro)
            {
                return true;
            }
            return false;  
    }
}
