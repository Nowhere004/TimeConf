using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyState
{
    protected BaseEnemy enemy;
    public abstract StateType stateType{get;}
   public abstract void ExecuteState();
    public abstract void EnterState(BaseEnemy enemy);
    public abstract void ExitState();

}
   
