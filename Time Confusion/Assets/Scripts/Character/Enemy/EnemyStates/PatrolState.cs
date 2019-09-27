using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseEnemyState
{
    public override StateType stateType { get { return StateType.Patrol; } }
    private float patrolDuration;
    private float patrolTime;
    public override void EnterState(BaseEnemy enemy)
    {
        patrolTime = 0;
        patrolDuration = Random.Range(4,8);
        this.enemy = enemy;
        enemy.EnemyAnimator.SetTrigger("patrol");
        enemy.EnemyAnimator.SetFloat("speed",1);
      //  Debug.Log($"Duration : "+patrolDuration);
      //  Debug.Log($"Timer : "+patrolTime);
    }

    public override void ExecuteState()
    {
        EnemyPatrol();
    }
    public override void ExitState()
    {
       
    }

    private void EnemyPatrol()
    {
        Debug.Log("Patrolling");
        enemy.EnemyAnimator.SetFloat("speed", 1);
        patrolTime += Time.deltaTime;
        if (patrolTime >= patrolDuration)
        {
            enemy.EnemyStateMachine.SwitchToNewState(StateType.Idle, enemy);
        }
        else
        {
            CanChaseTarget();
            EmptyGround();
            enemy.EnemyMove();
        }
         
          
    }
    private void EmptyGround()
    {
        if (!enemy.EnemyGroundCheckerScript.GroundCheck())
        {
            enemy.EnemyDataScript.ChangeCharacterDirection();
        }
    }
    private void CanChaseTarget()
    {
        if (enemy.Target != null)
        {
            enemy.EnemyStateMachine.SwitchToNewState(StateType.Chase, enemy);        
        }
    }
}
