using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseEnemyState
{
    public override StateType stateType { get { return StateType.Idle;} }
    private float idleTimer;
    private float idleDuration;

    public override void EnterState(BaseEnemy enemy)
    {
        idleTimer = 0;
        idleDuration = Random.Range(1,10);
        this.enemy = enemy;
    }

    public override void ExecuteState()
    {
        if (enemy.Target!=null)
        {
            enemy.EnemyStateMachine.SwitchToNewState(StateType.Chase,enemy);
        }
        EnemyIdle();
    }

    public override void ExitState()
    {
        
    }

    private void EnemyIdle()
    {
   //     Debug.Log("Idling");
        enemy.EnemyAnimator.SetFloat("speed",0);
        idleTimer += Time.deltaTime;
        if (idleTimer>=idleDuration)
        {
            enemy.EnemyStateMachine.SwitchToNewState(StateType.Patrol,enemy);
        }
    }
}
