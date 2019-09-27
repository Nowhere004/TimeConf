using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine: MonoBehaviour
{
    private Dictionary<StateType, BaseEnemyState> availableStates;

    public BaseEnemyState CurrentState { get; private set; }
    public event Action<BaseEnemyState> OnStateChanged;

    public void SetStates(Dictionary<StateType,BaseEnemyState> states)
    {
        availableStates = states;
    }

    private void Update()
    {
       if (CurrentState==null)
        {
            CurrentState = availableStates[StateType.Idle];
        }
        CurrentState.ExecuteState();       
    }

    public void SwitchToNewState(StateType nextState,BaseEnemy enemy)
    {
        if(CurrentState!=null)
        CurrentState.ExitState();
        CurrentState = availableStates[nextState];
        CurrentState.EnterState(enemy);
       // OnStateChanged?.Invoke(CurrentState);
     
    }

}
