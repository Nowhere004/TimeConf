using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseEnemyState
{
    public override StateType stateType { get { return StateType.Chase; } }
    public override void EnterState(BaseEnemy enemy)
    {
        this.enemy = enemy;
        enemy.EnemyAnimator.SetTrigger("chase");
        enemy.SetMovSpeed(enemy.MovSpeed * 1.5f);
        Debug.Log(enemy.MovSpeed);
    }

    public override void ExecuteState()
    {
            
            if (enemy.Target != null)
            {
            if (!(enemy.IsInAttackRange))
                EnemyChase();
            else
                PerformAttack();
            }
            else
            {
                enemy.EnemyStateMachine.SwitchToNewState(StateType.Patrol, enemy);
                enemy.SetMovSpeed(enemy.MovSpeed / 1.5f);
            } 
    }

    public override void ExitState()
    {
        
    }
    private void PerformAttack()
    {
        enemy.EnemyStateMachine.SwitchToNewState(enemy.GetAttackType(), enemy);
        enemy.SetMovSpeed(enemy.MovSpeed / 1.5f);
    }
    private void EnemyChase()
    {
        enemy.EnemyAnimator.SetFloat("speed", 1);
      //  Debug.Log("I am Chasing the Target");
        Debug.Log(enemy.FindTargetsDirection());
        enemy.EnemyMove();
        enemy.ChangeDirectionAccordingToTheTarget();
        
    }
}
