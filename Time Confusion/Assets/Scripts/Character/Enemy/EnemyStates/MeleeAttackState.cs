using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : BaseEnemyState
{
    public override StateType stateType => StateType.MeleeAttack;
    private float attackTimer;
    private float attackDuration=1f;

    public override void EnterState(BaseEnemy enemy)
    {
        attackTimer = 0;
        this.enemy = enemy;
        enemy.EnemyAnimator.SetTrigger("attack");
    }

    public override void ExecuteState()
    {
        AfterAttacking();
    }

    public override void ExitState()
    {
       
    }

    private void AfterAttacking()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer>=attackDuration)
        {
            if (enemy.Target != null)
            {
                enemy.EnemyStateMachine.SwitchToNewState(StateType.Chase, enemy);
            }
            else
            {
                enemy.EnemyStateMachine.SwitchToNewState(StateType.Patrol, enemy);
            }
        }       
    }
}
